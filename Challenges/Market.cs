using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenges.User;

namespace Challenges
{
    public static class Market
    {
        public static List<Item> AllItems { get; private set; } = new List<Item>();
        public static List<Item> SoldItems { get; private set; } = new List<Item>();
        public enum PurchaseResult { SUCCESS, INSUFFICIENT_FUNDS, ALREADY_OWNED, ALREADY_SOLD }
        public enum ItemCategory { UNCATEGORISED, APPLIANCE, BOARD_GAME, FOOD }

        public static Item ListItem(Item item, ItemCategory category)
        {
            item.Category = category;
            AllItems.Add(item);
            return item;
        }

        public static List<Item> FilterItems(ItemCategory category)
        {
            return AllItems.Where(x => x.Category == category).ToList();
        }

        public static PurchaseResult PurchaseItem(int itemid, User buyer, User seller)
        {
            return PurchaseItem(GetItemById(itemid), buyer, seller);
        }

        public static PurchaseResult PurchaseItem(Item item, User buyer, User seller)
        {
            if (buyer.Balance < item.Price) return PurchaseResult.INSUFFICIENT_FUNDS;
            else if (SoldItems.Contains(item)) return PurchaseResult.ALREADY_SOLD;
            else if (item.Owner == buyer.UserId) return PurchaseResult.ALREADY_OWNED;
            else
            {
                AllItems.Remove(item);
                SoldItems.Add(item);
                item.ReassignOwner(buyer);
                buyer.UpdateBalance(-(double)item.Price);
                return PurchaseResult.SUCCESS;
            }
        }

        public static Item GetItemById(int itemid)
        {
            if(AllItems.Count > 0 && AllItems != null) return AllItems.FirstOrDefault(item => item.ItemId == itemid);
            else throw new Exception("No items currently for sale");
        }
    }
}

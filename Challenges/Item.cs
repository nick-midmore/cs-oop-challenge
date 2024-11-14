using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace Challenges
{
    public class Item
    {
        public int ItemId { get; }
        public int Owner { get; private set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime DateListed { get; }
        public static int ItemsCreated { get; private set; }

        public Item(User seller, string name, int price, string description)
        {
            Owner = seller.UserId;
            Name = name;
            Price = price;
            Description = description;
            DateListed = DateTime.Now;
            ItemsCreated++;
            ItemId = ItemsCreated;
        }

        public string GetPrettyDateListed()
        {
            return this.DateListed.Humanize();
        }

        public int ReassignOwner(User user)
        {
            this.Owner = user.UserId;
            return this.Owner;
        }

        public static void ResetItemsCount() => ItemsCreated = 0;
    }
}

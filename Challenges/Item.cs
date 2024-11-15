using Humanizer;

namespace Challenges;

public abstract class Item
{
    public int ItemId { get; }
    public int Owner { get; private set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public Market.ItemCategory Category { get; set; } = Market.ItemCategory.UNCATEGORISED;
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

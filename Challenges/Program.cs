namespace Challenges;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //Item item = new Item("me", "testitem", 14, "desc");

        //Console.WriteLine(item.GetPrettyDateListed());
        //User test = new User("test", "test@test.com");
        Appliance app1 = new Appliance(new User("test1", "test1@test.com"), "nametest1", 12, "test1@test.com");
        Appliance app2 = new Appliance(new User("test2", "email2@email.com"), "app2", 42, "appliance 2");
        Food food = new Food(new User("test3", "test3@test.com"), "nametest3", 12, "test3@test.com");
        Food food2 = new Food(new User("test4", "test3@test.com"), "nametest3", 12, "test3@test.com");
        Food food3 = new Food(new User("test5", "test3@test.com"), "nametest3", 12, "test3@test.com");
        BoardGame bg = new BoardGame(new User("test2", "email2@email.com"), "bg1", 23, "bg1 test");

        Market.ListItem(app1, Market.ItemCategory.APPLIANCE);
        Market.ListItem(app2, Market.ItemCategory.APPLIANCE);
        Market.ListItem(food, Market.ItemCategory.FOOD);
        Market.ListItem(food2, Market.ItemCategory.FOOD);
        Market.ListItem(food3, Market.ItemCategory.FOOD);
        Market.ListItem(bg, Market.ItemCategory.BOARD_GAME);
    }
}

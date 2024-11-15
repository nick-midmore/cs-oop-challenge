namespace Challenges;

public class BoardGame : Item, IEdible
{
    public BoardGame(User seller, string name, int price, string description) 
        :base(seller, name, price, description)
    {
    }

    public void Eat(User user)
    {
        Console.WriteLine($"{user.Username} has eaten {Name}");
    }
}

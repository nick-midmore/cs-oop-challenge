using System.Text.RegularExpressions;

namespace Challenges;

public class User
{
    public int UserId { get; private set; }
    public string Username { get; }
    public string Email { get; }
    public double Balance { get; private set; }
    //public List<Item> ItemsForSale { get; set; } = new List<Item>();
    public static int AccountsCreated { get; set; }

    public User(string username, string email)
    {
        if (!String.IsNullOrEmpty(username)) Username = username;
        else throw new ArgumentNullException("Username can not be empty!");

        bool isValid = Regex.IsMatch(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
        if (isValid) Email = email;
        else throw new ArgumentNullException("Email can not be empty!");

        Balance = 0;
        AccountsCreated++;
        UserId = AccountsCreated;
    }

    public void UpdateBalance(double amount) => Balance += amount;

    public static void ResetAccountsCount() => AccountsCreated = 0;
}


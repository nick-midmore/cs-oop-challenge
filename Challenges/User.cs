using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Humanizer;

namespace Challenges;

public class User
{
    public int UserId { get; private set; }
    public string Username { get; }
    public string Email { get; }
    public double Balance { get; private set; }
    public List<Item> ItemsForSale { get; set; } = new List<Item>();
    public static int AccountsCreated { get; set; }
    public enum PurchaseResult { SUCCESS, INSUFFICIENT_FUNDS, ALREADY_OWNED }

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

    public Item ListItem(string name, int price, string description)
    {
        Item newItem = new Item(this, name, price, description);
        ItemsForSale.Add(newItem);
        return newItem;
    }

    public PurchaseResult PurchaseItem(Item item, User seller)
    {
        if(Balance < item.Price) return PurchaseResult.INSUFFICIENT_FUNDS;
        else if(ItemsForSale.Contains(item)) return PurchaseResult.ALREADY_OWNED;
        else
        {
            UnlistItem(seller, item);
            Balance -= (double)item.Price;
            return PurchaseResult.SUCCESS;
        }
    }

    public void UnlistItem(User user, Item item) => user.ItemsForSale.Remove(item);
}


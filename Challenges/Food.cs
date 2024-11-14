using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class Food : Item, IEdible
    {
        public Food(User seller, string name, int price, string description) : base(seller, name, price, description)
        {
        }

        public void Eat(User user)
        {
            Console.WriteLine($"{user.Username} has eaten {Name}");
        }
    }
}

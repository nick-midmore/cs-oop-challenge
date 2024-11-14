using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class Appliance : Item
    {
        public Appliance(User seller, string name, int price, string description) : base(seller, name, price, description)
        {
        }
    }
}

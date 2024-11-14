using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class BoardGame : Item
    {
        public BoardGame(User seller, string name, int price, string description) : base(seller, name, price, description)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Card
    {
        public NameCards CardName { get; set; }
        public Suits CardSuit { get; set; }
        public int Value { get; set; }

        public Card(NameCards nc, Suits s)
        {
            CardName = nc;
            CardSuit = s;
            Value = (int)nc;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Player
    {
        public int balance;
        public int bet;
        public List<Card> Cards { get; set; }

        public List<Card> GetCard(Deck deck, int count)
        {
            List<Card> list = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                Card t = deck.GetCard();
                Cards.Add(t);
                list.Add(t);
            }
            return list;
        }

        public Player()
        {
            balance = 100;
            bet = 0;
            Cards = new List<Card>();
        }

        public int GetPoints()
        {
            int sum = 0;

            foreach (Card val in Cards)
            {
                sum += val.Value;
            }
            return sum;
            
        }

    }
}

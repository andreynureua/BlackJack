using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Deck
    {
        private static List<Card> _cards;

        public Deck()
        {
            CreateDeck();
            Mix();
        }

        private void CreateDeck()
        {
            _cards = new List<Card>();
            foreach (NameCards nc in Enum.GetValues(typeof(NameCards)))
            {
                foreach (Suits s in Enum.GetValues(typeof(Suits)))
                {
                    _cards.Add(new Card(nc, s));
                }
            }
        }

        public void Mix()
        {
            Random rnd = new Random();

            for (int i = 0; i < _cards.Count; i++)
            {
                Card tmp = _cards[i];
                _cards.RemoveAt(i);
                _cards.Insert(rnd.Next(_cards.Count), tmp);
            }
        }

        public Card GetCard()
        {
            Card tmp = _cards[_cards.Count - 1];
            _cards.RemoveAt(_cards.Count - 1);
            return tmp;

        }

    }
}

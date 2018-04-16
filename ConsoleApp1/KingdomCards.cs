using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class KingdomCards
    {
        public static List<string> GetCards()
        {
            List<string> Cards = new List<string>();

            Cards.BasicCards();
            Cards.ShuffleCards();
            Cards = Cards.GetRange(0, 10);

            return Cards;
        }
    }
}

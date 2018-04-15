using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class Stack
    {
        // Properties
        public List<string> Cards { get; set; }
        
        // Method
        public List<string> AddCards(string Card)
        {
            int i = BasicSet.CardsAmount(Card);
            List<string> cards = new List<string>();
            if (i != 0)
            {
                for (int j = 1; j <= i; j++)
                {
                    cards.Add(Card);
                }
            }
            return cards;
        }
                
        // Instance constructor
        public Stack(string Card)
        {
            Cards = new List<string>();
            Cards = AddCards(Card);
        }
    }
}

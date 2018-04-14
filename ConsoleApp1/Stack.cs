using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class Stack
    {
        // Properties
        public List<string> Cards { get; set; }
        public string Name { get; set; }

        // Method
        public List<string> AddCardsToStack(string Card)
        {
            int i = BasicSet.CardsAmount(Card);

            for (int j = 1; j <= i; j++)
            {
                Cards.Add(Card);
            }

            return Cards;
        }
                
        // Instance constructor
        public Stack(String name)
        {
            Cards = new List<string>();
            Name = name;
        }
    }
}

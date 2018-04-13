using System;
using System.Text;
using System.Collections.Generic;

namespace Dominion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> KingdomCards = new List<string>();

            KingdomCards.BasicCards();
            KingdomCards.ShuffleCards();
            KingdomCards = KingdomCards.GetRange(0, 10);

            int i = 1;
            foreach (string Card in KingdomCards)
            {
                Stack stack = new Stack("Stack" + i);
                stack.AddCardsToStack(Card);
                i++;
            }
            
            foreach (string Card in KingdomCards)
            {
                if (Card == "Witch")
                {
                    Stack Curse = new Stack("Curse");
                    Curse.AddCardsToStack(Card);
                }
            }
        }
    }

    public class Stack
    {
        // Properties
        public string Name { get; set; }
        public List<string> Cards { get; set; }
        
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
        public Stack(string name)
        {
            Name = name;
            Cards = new List<string>();
        }
    }
}
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

            foreach (string card in KingdomCards)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey();
        }
    }

    public class Stack
    {
        // Properties
        public string Name { get; set; }
        public List<string> Cards { get; set; }
        
        // Method
        public List<string> AddCardsToStack()
        {
            return Cards;
        }

        // Instance constructor
        public Stack(string name)
        {
            Name = name;
        }
    }
}
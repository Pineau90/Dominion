using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class Stack
    {
        // Properties
        public List<string> Cards { get; set; }

        // Method to create all stacks based on the cards in the list
        public static List<Stack> Stacks(List<Card> Cards)
        {
            Cards.AddRange(Card.BasicCards());

            List<Stack> Stacks = new List<Stack>();

            foreach (Card card in Cards)
            {
                Stacks.Add(new Stack { Cards = AddCards(card) });
            }

            return Stacks;
        }

        // Method to add cards to a stack based on the card as input
        public static List<Card> AddCards(Card Card)
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
        public Stack() { }

        public Stack(Card Card)
        {
            Cards = AddCards(Card);
        }
    }
}

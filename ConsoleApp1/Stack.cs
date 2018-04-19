using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class Stack
    {
        // Properties
        public List<Card> Cards { get; set; }

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
            List<Card> Cards = new List<Card>();

            if (Card.Type.Contains("Victory") && !Card.Type.Contains("Curse"))
            {
                switch (Player.NumOfPlayers)
                {
                    case 2:
                        Cards = AmountCards(Card, 8);
                        break;
                    case 3:
                        Cards = AmountCards(Card, 10);
                        break;
                    case 4:
                        Cards = AmountCards(Card, 12);
                        break;
                }
            }
            else if (Card.Type.Contains("Curse"))
            {
                switch (Player.NumOfPlayers)
                {
                    case 2:
                        Cards = AmountCards(Card, 10);
                        break;
                    case 3:
                        Cards = AmountCards(Card, 20);
                        break;
                    case 4:
                        Cards = AmountCards(Card, 30);
                        break;
                }
            }
            else if (Card.Name.Contains("Copper") || Card.Name.Contains("Silver") || Card.Name.Contains("Gold"))
            {
                switch (Card.Name)
                {
                    case "Copper":
                        Cards = AmountCards(Card, 60);
                        break;
                    case "Silver":
                        Cards = AmountCards(Card, 40);
                        break;
                    case "Gold":
                        Cards = AmountCards(Card, 30);
                        break;
                }
            }
            else if (Card.Name.Contains("Trash"))
            {
                Cards.Add(Card);
            }
            else
            {
                Cards = AmountCards(Card, 10);
            }

            return Cards;
        }

        // returns the amount of cards
        public static List<Card> AmountCards(Card Card, int Amount)
        {
            List<Card> Cards = new List<Card>();

            for (int i = 1; i <= Amount; i++)
            {
                Cards.Add(Card);
            }

            return Cards;
        }

        // Instance constructor
        public Stack() { }
    }
}

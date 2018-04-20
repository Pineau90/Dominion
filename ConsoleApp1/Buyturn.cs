using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominion
{
    public static class Buyturn
    {
        public static void BuyTurn(this List<Player> Players, int Player)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Cards in your hand:");
                foreach (Card card in Players[Player].Hand)
                {
                    Console.Write("{0}     ", card.Name);
                }

                List<Card> TreasureCards = new List<Card>();
                foreach (Card card in Players[Player].Hand)
                {
                    if (card.Type.Contains("Treasure"))
                    {
                        TreasureCards.Add(card);
                    }
                }

                if (TreasureCards.Count == 0 && Players[Player].Gold == 0)
                {
                    Players[Player].Buys = 0;
                    Console.WriteLine("\n");
                    Console.Write("No treasure card in hand and no gold to spend. Press a key to end your turn");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                
                do
                {
                    Console.WriteLine("\n");
                    Console.Write("Enter an index number between 1 and {0} of the card to play: ", Players[Player].Hand.Count);
                    int index = GetTrIndex(Players, Player);
                    Players.PlayTreasure(Player, index);

                    for (int i = 1; i <= TreasureCards.Count; i++)
                    {
                        TreasureCards.Remove(TreasureCards.First());
                    }

                    foreach (Card card in Players[Player].Hand)
                    {
                        if (card.Type.Contains("Treasure"))
                        {
                            TreasureCards.Add(card);
                        }
                    }
                    Console.WriteLine(TreasureCards.Count - 1);
                }
                while (TreasureCards.Count != 0);

                Players[Player].Buys--;

            }
            while (Players[Player].Buys != 0);
        }

        public static int GetTrIndex(List<Player> Players, int Player)
        {
            int index;

            try
            {
                index = Convert.ToInt32(Console.ReadLine())-1;
                Card card = Players[Player].Hand[index];
                if (!(card.Type.Contains("Treasure")))
                {
                    throw new Exception("No action card selected to play, select another card");
                }
            }
            catch
            {
                Console.Clear();
                foreach (Card card in Players[Player].Hand)
                {
                    Console.Write("{0}     ", card.Name);
                }
                Console.WriteLine();
                Console.WriteLine("Enter a valid number between 1 and {0}", Players[Player].Hand.Count);
                return GetTrIndex(Players, Player);
            }
            return index;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominion
{
    public static class Buyturn
    {
        public static void BuyTurn(this List<Player> Players, int Player, List<Stack> Stacks)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Cards in your hand:");
                Players[Player].ShowHand();

                int TreasureCards = 0;
                foreach (Card card in Players[Player].Hand)
                {
                    if (card.Type.Contains("Treasure"))
                    {
                        TreasureCards++;
                    }
                }

                if (TreasureCards == 0 && Players[Player].Gold == 0)
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
                    int index = GetTrIndex(Players, Player);
                    Players.PlayTreasure(Player, index);

                    TreasureCards = 0;
                    foreach (Card card in Players[Player].Hand)
                    {
                        if (card.Type.Contains("Treasure"))
                        {
                            TreasureCards++;
                        }
                    }                    
                }
                while (TreasureCards != 0);

                // Buy cards has to be done
                Players[Player].Buys--;

            }
            while (Players[Player].Buys != 0);
        }

        public static int GetTrIndex(List<Player> Players, int Player)
        {
            int index;

            Players[Player].ShowHand();
            Console.Write("Enter an index number between 1 and {0} of the card to play: ", Players[Player].Hand.Count);

            try
            {
                index = Convert.ToInt32(Console.ReadLine())-1;
                Card card = Players[Player].Hand[index];
                if (!(card.Type.Contains("Treasure")))
                {
                    throw new Exception("No treasure card selected. Select another card to play.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n{0}", ex.Message);
                Console.WriteLine("Press key to continue");
                Console.ReadKey();
                return GetTrIndex(Players, Player);
            }
            return index;
        }
    }
}

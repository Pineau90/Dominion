using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominion
{
    public static class Actionturn
    {
        public static void ActionTurn(this List<Player> Players, int Player)
        {
            Players[Player].Actions = 1;
            Players[Player].Buys = 1;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Cards in your hand:");
                foreach (Card card in Players[Player].Hand)
                {
                    Console.Write("{0}     ", card.Name);
                }

                List<Card> ActionCards = new List<Card>();
                foreach (Card card in Players[Player].Hand)
                {
                    if (card.Type.Contains("Action"))
                    {
                        ActionCards.Add(card);
                    }
                }
                
                if (ActionCards.Count == 0)
                {
                    Players[Player].Actions = 0;
                    Console.WriteLine("\n");
                    Console.Write("No action card in hand. Press a key to go to buy phase");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

                Console.WriteLine("\n");
                Console.Write("Enter an index number between 1 and {0} of the card to play: ", Players[Player].Hand.Count);
                int index = GetIndex(Players, Player);
                Players.PlayAction(Player, index);

            } while (Players[Player].Actions != 0);
            
            Console.ReadKey();
        }

        public static int GetIndex(List<Player> Players, int Player)
        {
            int index;

            try
            {
                index = Convert.ToInt32(Console.ReadLine())-1;
                Card card = Players[Player].Hand[index];
                if (!(card.Type.Contains("Action")))
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
                return GetIndex(Players, Player);
            }
            return index;
        }
    }
}

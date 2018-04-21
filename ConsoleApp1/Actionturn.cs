using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominion
{
    public static class Actionturn
    {
        public static void ActionTurn(this List<Player> Players, int Player, List<Stack> Stacks)
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
                Players.PlayAction(Player, index, Stacks);

            } while (Players[Player].Actions != 0);
            
            Console.ReadKey();
        }

        public static int GetIndex(List<Player> Players, int Player)
        {
            int index;

            Players[Player].ShowHand();
            Console.Write("Enter an index number between 1 and {0} of the card to play: ", Players[Player].Hand.Count);

            try
            {
                index = Convert.ToInt32(Console.ReadLine())-1;
                Card card = Players[Player].Hand[index];
                if (!(card.Type.Contains("Action")))
                {
                    throw new Exception("No action card selected. Select another card to play.");
                }                
            }
            catch (Exception ex)
            {                
                Console.WriteLine("\n{0}", ex.Message);
                Console.WriteLine("Press key to continue");
                Console.ReadKey();
                return GetIndex(Players, Player);
            }
            return index;
        }
    }
}

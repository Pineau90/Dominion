using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Dominion
{
    class Program
    {   
        static void Main(string[] args)
        {
            // Set 10 cards to play with
            List<string> Cards = KingdomCards.GetCards();

            // Set a list of stacks to play with
            List<Stack> Stacks = Stack.Stacks(Cards);

            // Calls the function to set the number of players
            Player.SetNumPlayers();

            // Creates the amount of players set before
            List<Player> Players = Player.SetPlayers();
            


            // Plays the game
            int i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("{0}'s turn", Players[i].Name);
                // Draw cards to hand and remove from drawpile
                Players[i].Hand = Players[i].DrawPile.GetRange(0, 5);

                // Action turn
                Console.WriteLine();
                Console.WriteLine("Cards in your hand:");
                foreach (string card in Players[i].Hand)
                {
                    Console.WriteLine(card);
                }
                // Offer choice to play or not to play if applicable
                Console.ReadKey();
                i++;
            } while (i <= Player.NumOfPlayers - 1);
        }
    }    
}
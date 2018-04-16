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
                Console.WriteLine("{0}'s turn", Players[i].Name);

                i++;
            } while (i <= Player.NumOfPlayers - 1);

            Console.ReadKey();
        }
    }    
}
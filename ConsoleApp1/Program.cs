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
            // Calls the function to set the number of players
            Player.SetNumPlayers();

            // Creates the amount of players set before
            List<Player> Players = Player.SetPlayers();
            Console.Clear();

            // Select 10 kingdom cards
            List<Card> Cards = Card.BasicKingdom();
            Cards.ShuffleCards();
            Console.Write("Shuffling cards");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Clear();         
            Cards = Cards.GetRange(0, 10);
            
            // Set a list of stacks to play with
            List<Stack> Stacks = Stack.Stacks(Cards);
            
            // Plays the game
            int i = 0;
            int Turn = 1;

            do
            {
                if (Turn == 1)
                {
                    Players.DrawCards(5, i, "Hand");
                }
                Console.Clear();
                Console.WriteLine("{0}'s turn", Players[i].Name);

                // Action turn
                Players.ActionTurn(i, Stacks);
                Players.BuyTurn(i, Stacks);

                // Check if piles are empty for ending the game
                // update victory points
                
                Console.WriteLine(Players[i].Gold);
                Console.ReadKey();
                i++;

            } while (i < Player.NumOfPlayers);

            Console.ReadKey();
        }
    }    
}
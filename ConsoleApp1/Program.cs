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
            Console.WriteLine("Shuffling cards...");
            System.Threading.Thread.Sleep(3000);
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
                Console.WriteLine();
                Console.WriteLine("Cards in your hand:");
                foreach (Card card in Players[i].Hand)
                {
                    Console.WriteLine(card.Name);
                }
                // Offer choice to play or not to play if applicable
                Console.WriteLine();
                Console.WriteLine("Cards in your drawpile");
                foreach (Card card in Players[i].DrawPile)
                {
                    Console.WriteLine(card.Name);
                }
                Console.ReadKey();
                i++;
            } while (i <= Player.NumOfPlayers - 1);

            Console.Clear();

            foreach (Stack stack in Stacks)
            {
                Console.WriteLine(stack.Cards.First().Name + ": " + stack.Cards.Count);
            }
            Console.ReadKey();
        }
    }    
}
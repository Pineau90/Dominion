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
            List<string> Cards = KingdomCards.GetCards();
            List<Stack> Stacks = Stack.Stacks(Cards);            
            int NumOfPlayers = Player.SetNumPlayers();
            List<Player> Players = Player.SetPlayers();

            Console.Clear();
            foreach (Stack stack in Stacks)
            {
                Console.WriteLine(stack.Cards.First() + ": " + stack.Cards.Count());
            }

            Console.ReadKey();            
        }
    }    
}
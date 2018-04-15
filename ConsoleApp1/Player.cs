using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class Player
    {         
        // Properties
        public string Name { get; set; }
        public List<string> Hand { get; set; }
        public List<string> DrawPile { get; set; }
        public List<string> DiscardPile { get; set; }
        public List<string> InPlay { get; set; }
        public int VictoryPoints { get; set; }

        // Method
        public void StartDeck()
        {
            for (int i = 1; i <= 7; i++)
            {
                DrawPile.Add("Copper");
            }
            for (int i = 1; i <= 3; i++)
            {
                DrawPile.Add("Estate");
            }
            DrawPile.ShuffleCards();
        }

        // Instance constructor
        public Player(string name)
        {
            Name = name;
            Hand = new List<string>();
            DrawPile = new List<string>();
            DiscardPile = new List<string>();
            InPlay = new List<string>();
            VictoryPoints = 0;
        }
    }
}

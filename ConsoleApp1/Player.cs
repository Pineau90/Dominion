using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominion
{
    public class Player
    {
        // Properties
        public static int NumOfPlayers;
        public static string SetName;

        public string Name { get; set; }
        public List<string> Hand { get; set; }
        public List<string> DrawPile { get; set; }
        public List<string> DiscardPile { get; set; }
        public List<string> InPlay { get; set; }
        public int VictoryPoints { get; set; }
                
        // Method to set the cards in the startdeck
        public static List<string> StartDeck()
        {
            List<string> Cards = new List<string>();

            for (int i = 1; i <= 7; i++)
            {
                Cards.Add("Copper");
            }

            for (int i = 1; i <= 3; i++)
            {
                Cards.Add("Estate");
            }

            Cards.ShuffleCards();
            return Cards;
        }

        // Method to set the number of players
        public static void SetNumPlayers()
        {
            Console.Write("Set number of players (2-4):");
            try
            {
                NumOfPlayers = Convert.ToInt32(Console.ReadLine());
                if (!(NumOfPlayers >= 2 && NumOfPlayers <= 4))
                {
                    throw new FormatException("Please enter a number between 2 and 4");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                SetNumPlayers();
            }
        }

        // Method to set the players
        public static List<Player> SetPlayers()
        {            
            List<Player> Players = new List<Player>();

            for (int i = 1; i <= NumOfPlayers; i++)
            {
                Players.Add(new Player { Name = SetPlayerName(i), DrawPile = StartDeck(), Hand = new List<string>(), DiscardPile = new List<string>(), InPlay = new List<string>(), VictoryPoints = 0 });
            }
            
            return Players;
        }

        // Method to set the players name
        public static string SetPlayerName(int PlayerNum)
        {
            Console.Write("Enter a name for player{0}: ", PlayerNum);
            SetName = Convert.ToString(Console.ReadLine());
            if (!Regex.IsMatch(SetName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                Console.WriteLine("Please enter a valid name");
                SetPlayerName(PlayerNum);
            }

            return SetName;
        }

        // Instance constructor
        public Player() { }

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

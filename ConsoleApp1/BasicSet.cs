using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class Card
    {
        // Card name
        public string Name { get; set; }
        // Card types
        public List<string> Type { get; set; }
        // Card price
        public int Price { get; set; }
        // Card Victory points
        public int VicotryPoints { get; set; }

        // Method to create BasicCards
        public static List<Card> BasicCards()
        {
            List<Card> Cards = new List<Card>();

            Cards.Add(new Card { Name = "Copper", Type = { "Treasure" }, Price = 0});
            Cards.Add(new Card { Name = "Silver", Type = { "Treasure" }, Price = 3});
            Cards.Add(new Card { Name = "Gold", Type = { "Treasure" }, Price = 6});
            Cards.Add(new Card { Name = "Trash", Type = { "Trash" } });
            Cards.Add(new Card { Name = "Estate", Type = { "Victory"}, Price = 2, VicotryPoints = 1});
            Cards.Add(new Card { Name = "Duchy", Type = { "Victory" }, Price = 5, VicotryPoints = 3 });
            Cards.Add(new Card { Name = "Province", Type = { "Victory" }, Price = 8, VicotryPoints = 6 });
            Cards.Add(new Card { Name = "Curse", Type = { "Victory", "Curse" }, Price = 0, VicotryPoints = -1 });

            return Cards;
        }

        public static List<Card> BasicKingdom()
        {
            List<Card> Cards = new List<Card>();

            Cards.Add(new Card { Name = "Adventurer", Type = { "Action" }, Price = 6 });
            Cards.Add(new Card { Name = "Artisan", Type = { "Action" }, Price = 6 });
            Cards.Add(new Card { Name = "Bandit", Type = { "Action", "Attack" }, Price = 5 });
            Cards.Add(new Card { Name = "Bureaucrat", Type = { "Action", "Attack" }, Price = 4 });
            Cards.Add(new Card { Name = "Cellar", Type = { "Action" }, Price = 2 });
            Cards.Add(new Card { Name = "Chancellor", Type = { "Action" }, Price = 3 });
            Cards.Add(new Card { Name = "Chapel", Type = { "Action" }, Price = 2 });
            Cards.Add(new Card { Name = "Counsil Room", Type = { "Action" }, Price = 5 });
            Cards.Add(new Card { Name = "Feast", Type = { "Action" }, Price = 4 });
            Cards.Add(new Card { Name = "Festival", Type = { "Action" }, Price = 5 });
            Cards.Add(new Card { Name = "Gardens", Type = { "Victory" }, Price = 4 });
            Cards.Add(new Card { Name = "Harbringer", Type = { "Action" }, Price = 3 });
            Cards.Add(new Card { Name = "Laboratory", Type = { "Action" }, Price = 5 });
            Cards.Add(new Card { Name = "Library", Type = { "Action" }, Price = 5 });
            Cards.Add(new Card { Name = "Market", Type = { "Action" }, Price = 5 });
            Cards.Add(new Card { Name = "Merchant", Type = { "Action" }, Price = 3 });
            Cards.Add(new Card { Name = "Militia", Type = { "Action", "Attack" }, Price = 4 });
            Cards.Add(new Card { Name = "Mine", Type = { "Action" }, Price = 5 });

            return Cards;
        }

        // Method to create BasicKingdom
        
        
        // Instance constructor
        public Card() { }

        public Card(string name)
        {
            Name = name;
            Type = new List<string>();
            Price = new int();
            VicotryPoints = new int();
        }        
    }
}

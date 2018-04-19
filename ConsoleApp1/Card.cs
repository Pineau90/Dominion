using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public class Card
    {
        // Properties
        public string Name { get; set; }
        public List<string> Type { get; set; }
        public int Price { get; set; }
        public int VicotryPoints { get; set; }

        // Method to return amount of cards

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
            Cards.Add(new Card { Name = "Moat", Type = { "Action", "Reaction" }, Price = 2 });
            Cards.Add(new Card { Name = "Moneylender", Type = { "Action" }, Price = 4 });
            Cards.Add(new Card { Name = "Poacher", Type = { "Action" }, Price = 4 });
            Cards.Add(new Card { Name = "Remodel", Type = { "Action" }, Price = 4 });
            Cards.Add(new Card { Name = "Sentry", Type = { "Action" }, Price = 5 });
            Cards.Add(new Card { Name = "Smithy", Type = { "Action" }, Price = 4 });
            Cards.Add(new Card { Name = "Spy", Type = { "Action", "Attack" }, Price = 4 });
            Cards.Add(new Card { Name = "Thief", Type = { "Action", "Attack" }, Price = 4 });
            Cards.Add(new Card { Name = "Throne Room", Type = { "Action" }, Price = 4 });
            Cards.Add(new Card { Name = "Vassal", Type = { "Action" }, Price = 3 });
            Cards.Add(new Card { Name = "Village", Type = { "Action" }, Price = 3 });
            Cards.Add(new Card { Name = "Witch", Type = { "Action", "Attack" }, Price = 5 });
            Cards.Add(new Card { Name = "Woodcutter", Type = { "Action" }, Price = 3 });
            Cards.Add(new Card { Name = "Workshop", Type = { "Action" }, Price = 3 });
                      
            return Cards;
        }
        
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

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
                
        // Method to create BasicCards
        public static List<Card> BasicCards()
        {
            List<Card> Cards = new List<Card>();

            Cards.Add(new Card { Name = "Copper", Type = new List<string>(new string[] { "Treasure" }), Price = 0, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Silver", Type = new List<string>(new string[] { "Treasure" }), Price = 3, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Gold", Type = new List<string>(new string[] { "Treasure" }), Price = 6, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Trash", Type = new List<string>(new string[] { "Trash" }), Price = 0, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Estate", Type = new List<string>(new string[] { "Victory" }), Price = 2, VicotryPoints = 1 });
            Cards.Add(new Card { Name = "Duchy", Type = new List<string>(new string[] { "Victory" }), Price = 5, VicotryPoints = 3 });
            Cards.Add(new Card { Name = "Province", Type = new List<string>(new string[] { "Victory" }), Price = 8, VicotryPoints = 6 });
            Cards.Add(new Card { Name = "Curse", Type = new List<string>(new string[] { "Victory", "Curse" }), Price = 0, VicotryPoints = -1 });

            return Cards;
        }

        public static List<Card> BasicKingdom()
        {
            List<Card> Cards = new List<Card>();

            Cards.Add(new Card { Name = "Adventurer", Type = new List<string>(new string[] { "Action" }), Price = 6, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Artisan", Type = new List<string>(new string[] { "Action" }), Price = 6, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Bandit", Type = new List<string>(new string[] { "Action", "Attack" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Bureaucrat", Type = new List<string>(new string[] { "Action", "Attack" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Cellar", Type = new List<string>(new string[] { "Action" }), Price = 2, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Chancellor", Type = new List<string>(new string[] { "Action" }), Price = 3, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Chapel", Type = new List<string>(new string[] { "Action" }), Price = 2, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Counsil Room", Type = new List<string>(new string[] { "Action" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Feast", Type = new List<string>(new string[] { "Action" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Festival", Type = new List<string>(new string[] { "Action" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Gardens", Type = new List<string>(new string[] { "Victory" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Harbringer", Type = new List<string>(new string[] { "Action" }), Price = 3, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Laboratory", Type = new List<string>(new string[] { "Action" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Library", Type = new List<string>(new string[] { "Action" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Market", Type = new List<string>(new string[] { "Action" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Merchant", Type = new List<string>(new string[] { "Action" }), Price = 3, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Militia", Type = new List<string>(new string[] { "Action", "Attack" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Mine", Type = new List<string>(new string[] { "Action" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Moat", Type = new List<string>(new string[] { "Action", "Reaction" }), Price = 2, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Moneylender", Type = new List<string>(new string[] { "Action" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Poacher", Type = new List<string>(new string[] { "Action" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Remodel", Type = new List<string>(new string[] { "Action" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Sentry", Type = new List<string>(new string[] { "Action" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Smithy", Type = new List<string>(new string[] { "Action" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Spy", Type = new List<string>(new string[] { "Action", "Attack" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Thief", Type = new List<string>(new string[] { "Action", "Attack" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Throne Room", Type = new List<string>(new string[] { "Action" }), Price = 4, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Vassal", Type = new List<string>(new string[] { "Action" }), Price = 3, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Village", Type = new List<string>(new string[] { "Action" }), Price = 3, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Witch", Type = new List<string>(new string[] { "Action", "Attack" }), Price = 5, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Woodcutter", Type = new List<string>(new string[] { "Action" }), Price = 3, VicotryPoints = 0 });
            Cards.Add(new Card { Name = "Workshop", Type = new List<string>(new string[] { "Action" }), Price = 3, VicotryPoints = 0 });
                      
            return Cards;
        }
        
        // Instance constructor
        public Card() { }      
    }
}

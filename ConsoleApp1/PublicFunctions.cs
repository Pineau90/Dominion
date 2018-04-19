using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace Dominion
{
    public static class PublicFunctions
    {    
        public static IList<Card> ShuffleCards(this IList<Card> Cards)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = Cards.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
            return Cards;
        }

        public static void DrawCards(this List<Player> Players, int Amount, int Player, string Type)
        {
            switch (Type)
            {
                case "Hand":
                    if (Amount > Players[Player].DrawPile.Count + Players[Player].DiscardPile.Count)
                    {
                        Amount = Players[Player].DrawPile.Count + Players[Player].DiscardPile.Count;
                    }
                    for (int i = 1; i <= Amount; i++)
                    {
                        if (Players[Player].DrawPile.Count == 0)
                        {
                            Players.DrawCards(i, Player, "DrawPile");
                        }
                        Players[Player].Hand.Add(Players[Player].DrawPile.First());
                        Players[Player].DrawPile.Remove(Players[Player].DrawPile.First());
                    }
                    break;
                case "DrawPile":
                    if (Amount > Players[Player].DiscardPile.Count)
                    {
                        Amount = Players[Player].DiscardPile.Count;
                    }
                    for (int i = 1; i <= Amount; i++)
                    {
                        
                        Players[Player].DrawPile.Add(Players[Player].DiscardPile.First());
                        Players[Player].DiscardPile.Remove(Players[Player].DiscardPile.First());

                    }
                    break;
            }
            
        }
    }
}

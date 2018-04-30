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
            if (!Cards.Any())
            {
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
            }
            return Cards;
        }

        public static void DrawCards(this List<Player> Players, int Amount, int Player, string Type)
        {
            int drawpile = 0;
            int discardpile = 0;

            foreach (Card i in Players[Player].DrawPile)
            {
                drawpile++;
            }
            
            foreach (Card i in Players[Player].DiscardPile)
            {
                discardpile++;
            }

            switch (Type)
            {
                case "Hand":
                    if (Amount > drawpile + discardpile)
                    {
                        Amount = drawpile + discardpile;
                    }
                    for (int i = 1; i <= Amount; i++)
                    {
                        if (drawpile == 0)
                        {
                            Players.DrawCards(i, Player, "DrawPile");
                        }
                        Players[Player].Hand.Add(Players[Player].DrawPile.First());
                        Players[Player].DrawPile.Remove(Players[Player].DrawPile.First());
                    }
                    break;
                case "DrawPile":
                    if (Amount > discardpile)
                    {
                        Amount = discardpile;
                    }
                    for (int i = 1; i <= Amount; i++)
                    {
                        
                        Players[Player].DrawPile.Add(Players[Player].DiscardPile.First());
                        Players[Player].DiscardPile.Remove(Players[Player].DiscardPile.First());

                    }
                    break;
            }
            
        }

        public static void ShowHand(this Player player)
        {
            Console.Clear();
            Console.WriteLine("Cards in {0}'s hand: \n", player.Name);
            foreach(Card card in player.Hand)
            {
                Console.Write("{0}     ", card.Name);
            }
            Console.WriteLine("\n");
        }

        /*
        public static int GetCardIndex(this List<Player> Players, int Player, string pile, string type, string value, List<Stack> Stacks)
        {
            int ReturnIndex = 0;
            int i = 0;
            List<int> CardIndex = new List<int>();

            i = 0;
            ReturnIndex = 0;
            CardIndex.Clear();

            switch (pile)
            {
                case "Hand":
                    foreach (Card card in Players[Player].Hand)
                    {
                        if (type == "Name")
                        {
                            if (card.Name == value)
                            {
                                Console.Write("{0}. {1}     ", i, card.Name);
                                CardIndex.Add(i);
                                i++;
                            }
                        }

                        if (type == "Type")
                        {
                            if (card.Type.Contains(value))
                            {
                                Console.Write("{0}. {1}     ", i, card.Name);
                                CardIndex.Add(i);
                                i++;
                            }
                        }
                    }
                    break;
                case "Stack":
                    foreach (Stack stack in Stacks)
                    {
                        if (type == "Value")
                        {
                            if (card.Name == value)
                            {
                                Console.Write("{0}. {1}     ", i, card.Name);
                                CardIndex.Add(i);
                                i++;
                            }
                        }

                        if (type == "Type")
                        {
                            if (card.Type.Contains(value))
                            {
                                Console.Write("{0}. {1}     ", i, card.Name);
                                CardIndex.Add(i);
                                i++;
                            }
                        }
                    }
                    break;
            }
            
            return ReturnIndex;
        } */
    }
}

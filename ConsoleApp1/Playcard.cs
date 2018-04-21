﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominion
{
    public static class Playcard
    {
        public static void PlayAction(this List<Player> Players, int Player, int Card, List<Stack> Stacks)
        {
            Card card = Players[Player].Hand[Card];

            Players[Player].Hand.Remove(card);
            Players[Player].InPlay.Add(card);
            Players[Player].Actions--;

            switch (card.Name)
            {
                case "Adventurer":
                    int AdventurerTreasure = 0;
                    Card AdventurerCard;
                    do
                    {
                        AdventurerCard = Players[Player].DrawPile.First();
                        Players[Player].DrawPile.Remove(Players[Player].DrawPile.First());

                        if (AdventurerCard.Type.Contains("Treasure"))
                        {
                            AdventurerTreasure++;
                            Players[Player].Hand.Add(AdventurerCard);
                        }
                        else
                        {
                            Players[Player].DiscardPile.Add(AdventurerCard);
                        }
                    }
                    while (AdventurerTreasure < 2);
                    break;
                case "Artisan":
                    int Artisani = 0;
                    Card ArtisanCard;
                    List<int> ArtisanCards = new List<int>();
                    int ArtisanIndex;
                    bool ArtisanException = true;

                    foreach (Stack stack in Stacks)
                    {
                        Artisani++;
                        ArtisanCard = stack.Cards.First();                        
                        if (stack.Cards.First().Price <= 5 && stack.Cards.First().Name != "Trash" && !(stack.Cards.First().Type.Contains("Curse")))
                        {
                            Console.Write("{0}: {1}     ", Artisani, ArtisanCard.Name);
                            ArtisanCards.Add(Artisani);
                        }                        
                    }

                    do
                    {
                        try
                        {
                            Console.Write("\nEnter the number in front of the card you want to add to your hand: ");
                            ArtisanIndex = Convert.ToInt32(Console.Read())-1;
                            if (!(ArtisanCards.Contains(ArtisanIndex)))
                            {
                                throw new Exception("");
                            }
                            ArtisanCard = Stacks[Artisani].Cards.First();
                            Stacks[Artisani].Cards.Remove(Stacks[Artisani].Cards.First());
                            Players[Player].Hand.Add(ArtisanCard);
                            ArtisanException = false;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid entry, enter a number from the list.");
                        }
                    }
                    while (ArtisanException == true);

                    Console.Clear();
                    Artisani = 0;
                    ArtisanCards.Clear();

                    Console.WriteLine("Select a card to put from your hand onto your deck.\n");
                    foreach (Card ArtisanCard2 in Players[Player].Hand)
                    {
                        Artisani++;
                        ArtisanCards.Add(Artisani);
                        Console.Write("{0}. {1}     ", Artisani, ArtisanCard2.Name);
                    }
                    Console.WriteLine("\n");

                    ArtisanException = false;
                    do
                    {
                        try
                        {
                            Console.Write("\nEnter the number in front of the card to put on top of your deck:");
                            ArtisanIndex = Convert.ToInt32(Console.Read())-1;
                            if (!(ArtisanCards.Contains(ArtisanIndex)))
                            {
                                throw new Exception("");
                            }
                            ArtisanCard = Players[Player].Hand[ArtisanIndex];
                            Players[Player].Hand.Remove(Players[Player].Hand[ArtisanIndex]);
                            Players[Player].DrawPile.Insert(0, ArtisanCard);
                            ArtisanException = false;
                        }
                        catch
                        {
                            Console.Write("Invalid entry, enter a valid number from the list: ");
                        }

                    }
                    while (ArtisanException == true);
                    break;
                case "Bandit":
                    break;
                case "Bureaucrat":
                    break;
                case "Cellar":
                    break;
                case "Chancellor":
                    break;
                case "Chapel":
                    break;
                case "Council Room":
                    break;
                case "Feast":
                    break;
                case "Festival":
                    break;
                case "Harbringer":
                    break;
                case "Laboratory":
                    break;
                case "Library":
                    break;
                case "Market":
                    break;
                case "Merchant":
                    break;
                case "Militia":
                    break;
                case "Mine":
                    break;
                case "Moat":
                    break;
                case "Moneylender":
                    break;
                case "Poacher":
                    break;
                case "Remodel":
                    break;
                case "Sentry":
                    break;
                case "Smithy":
                    break;
                case "Spy":
                    break;
                case "Thief":
                    break;
                case "Throne Room":
                    break;
                case "Vassal":
                    break;
                case "Village":
                    break;
                case "Witch":
                    break;
                case "Woodcutter":
                    break;
                case "Workshop":
                    break;
            }
        }

        public static void PlayTreasure(this List<Player> Players, int Player, int Card)
        {
            Card card = Players[Player].Hand[Card];

            Players[Player].Hand.Remove(card);
            Players[Player].InPlay.Add(card);

            Console.WriteLine(card.Name);
            switch (card.Name)
            {
                case "Copper":
                    Players[Player].Gold += 1;
                    break;
                case "Silver":
                    Players[Player].Gold += 2;
                    break;
                case "Gold":
                    Players[Player].Gold += 3;
                    break;
            }
            Console.WriteLine(Players[Player].Gold);
            Console.ReadKey();
            
        }

        public static void PlayReaction(this List<Player> Players, int Player, int Card)
        {

        }
    }
}

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
                            ArtisanIndex = Convert.ToInt32(Console.Read()) - 1;
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
                            ArtisanIndex = Convert.ToInt32(Console.Read()) - 1;
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

                    Card BanditCard;
                    int BanditIndex;
                    List<int> BanditList = new List<int>();
                    int Banditi = 0;

                    foreach (Stack BanditStack in Stacks)
                    {
                        if (BanditStack.Cards.First().Name == "Gold")
                        {
                            BanditIndex = Banditi;
                        }
                        Banditi++;
                    }

                    BanditCard = Stacks[Banditi].Cards.First();
                    Stacks[Banditi].Cards.Remove(Stacks[Banditi].Cards.First());
                    Players[Player].DiscardPile.Add(BanditCard);

                    Banditi = 0;
                    foreach (Player player in Players)
                    {
                        if (!(Banditi == Player))
                        {
                            BanditList.Add(Banditi);
                        }
                        Banditi++;
                    }

                    List<Card> ReactionCards = new List<Card>();
                    bool BanditAttack = true;
                    foreach (int i in BanditList)
                    {
                        int k = 0;

                        foreach (Card BanditCard2 in Players[i].Hand)
                        {
                            if (BanditCard2.Type.Contains("Reaction"))
                            {
                                ReactionCards.Add(BanditCard2);
                                k++;
                            }
                        }                        
                        
                        if (k != 0)
                        {
                            BanditAttack = Reactionturn.PlayReaction(Players, i, Stacks);
                        }

                        if (BanditAttack == true)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                BanditCard = Players[i].DrawPile.First();
                                Players[i].DrawPile.Remove(Players[i].DrawPile.First());

                                if (BanditCard.Type.Contains("Treasure") && !(BanditCard.Name == "Copper"))
                                {
                                    Stacks[GetStackIndex(Stacks, "Trash")].Cards.Add(BanditCard);
                                }
                                else
                                {
                                    Players[i].DiscardPile.Add(BanditCard);
                                }
                            }
                        }
                    }

                    break;

                case "Bureaucrat":

                    Card BureaucratCard;
                    int Bureaucrati = 0;
                    List<int> BureaucratIndex = new List<int>();
                    bool BureaucratException;

                    BureaucratCard = Stacks[GetStackIndex(Stacks, "Silver")].Cards.First();
                    Stacks[GetStackIndex(Stacks, "Silver")].Cards.Remove(Stacks[GetStackIndex(Stacks, "Silver")].Cards.First());
                    Players[Player].DrawPile.Insert(0, BureaucratCard);

                    foreach(Player player in Players)
                    {
                        if (!(Bureaucrati == Player))
                        {
                            BureaucratIndex.Add(Bureaucrati);
                        }
                        Bureaucrati++;
                    }

                    foreach (int i in BureaucratIndex)
                    {
                        Bureaucrati = 0;
                        foreach(Card BureaucratCard2 in Players[i].Hand)
                        {
                            if (BureaucratCard2.Type.Contains("Victory"))
                            {
                                Console.Write("{0}. {1}     ", Bureaucrati, BureaucratCard2.Name);
                                Bureaucrati++;
                            }
                        }
                        
                        if (Bureaucrati == 0)
                        {
                            break;
                        }

                        Console.Write("\n\nEnter the number in front of the card you want to put on top of your deck: ");
                        BureaucratException = true;
                        do
                        {
                            try
                            {
                                Bureaucrati = Convert.ToInt32(Console.ReadLine());
                                if (!(BureaucratIndex.Contains(Bureaucrati)))
                                {
                                    throw new Exception("");
                                }
                                BureaucratException = false;
                                BureaucratCard = Players[i].Hand[Bureaucrati];
                                Players[i].Hand.Remove(Players[i].Hand[Bureaucrati]);
                                Players[i].DrawPile.Insert(0, BureaucratCard);
                            }
                            catch
                            {
                                Console.Write("\n\nEnter a valid number: ");
                            }
                        } while (BureaucratException == true);
                    }

                    break;

                case "Cellar":

                    int Cellari = 0;
                    int Cellarj = 0;
                    bool CellarException = true;
                    string CellarString;
                    Card CellarCard;

                    Players[Player].Actions++;

                    for (Cellari = 0; Cellari <= Players[Player].Hand.Count; Cellari++)
                    {
                        CellarCard = Players[Player].Hand[Cellari];

                        do
                        {
                            try
                            {
                                Console.Write("Do you want to discard {0} from your hand? (y/n): ", CellarCard.Name);
                                CellarString = Console.ReadLine();
                                
                                if (CellarString == "y" || CellarString == "Y")
                                {
                                    Players[Player].DiscardPile.Add(CellarCard);
                                    Players[Player].Hand.Remove(Players[Player].Hand[Cellari]);
                                    Cellarj++;
                                    CellarException = false;
                                }
                                else if (CellarString == "n" || CellarString == "N")
                                {
                                    CellarException = false;
                                }
                                else
                                {
                                    throw new Exception("");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Pick y to discard the card or n to keep the card in your hand.\n");
                            }
                        } while (CellarException == true);
                    }

                    Players.DrawCards(Cellarj, Player, "Hand");

                    break;

                case "Chancellor":

                    string ChancellorString;
                    bool ChancellorException = true;
                    Players[Player].Gold += 2;

                    do
                    {
                        try
                        {
                            Console.Write("Do you want to add your drawpile to your discard pile? (y/n): ");
                            ChancellorString = Console.ReadLine();

                            if (ChancellorString == "y" || ChancellorString == "Y")
                            {
                                Players[Player].DiscardPile.AddRange(Players[Player].DrawPile);
                                Players[Player].DrawPile.Clear();
                                ChancellorException = false;
                            }
                            else if (ChancellorString == "n" || ChancellorString == "N")
                            {
                                ChancellorException = false;
                            }
                            else
                            {
                                throw new Exception("");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enter y or n!");
                        }
                    } while (ChancellorException == true);
                    
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

        public static bool PlayReaction(this List<Player> Players, int Player, int Card)
        {
            bool NotCancelAttack = true;
            Card card = Players[Player].Hand[Card];

            switch (card.Name)
            {
                case "Moat":
                    NotCancelAttack = false;
                    break;
            }

            return NotCancelAttack;
        }

        public static int GetPlayerIndex(List<Player> Players, int Player)
        {
            int i = 0;
            List<int> iList = new List<int>();
            int PlayerIndex = 0;
            bool PlayerException = true;

            Console.WriteLine("Available players to select: \n");
            foreach (Player player in Players)
            {
                if (!(i == Player))
                {
                    Console.WriteLine("{0}. {1}", i, player.Name);
                    iList.Add(i);
                }
                i++;
            }

            do
            {
                try
                {
                    Console.Write("\nEnter the number in front of the Player you want to select: ");
                    PlayerIndex = Convert.ToInt32(Console.Read());
                    if (!(iList.Contains(PlayerIndex)))
                    {
                        throw new Exception("");
                    }
                    PlayerException = false;
                }
                catch
                {
                    Console.Write("Invalid entry, enter a valid number from the list: ");
                }
            }
            while (PlayerException == true);

            iList.Clear();
            return PlayerIndex;
        }

        public static int GetStackIndex(List<Stack> Stacks, String StackName)
        {
            int i = 0;
            int j = 0;

            foreach (Stack stack in Stacks)
            {
                if (stack.Cards.First().Name == StackName)
                {
                    j = i;
                }
                i++;
            }

            return j;
        }
    }
}

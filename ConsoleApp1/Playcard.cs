using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominion
{
    public static class Playcard
    {
        public static int AddSilver;

        public static void PlayAction(this List<Player> Players, int Player, int Card, List<Stack> Stacks)
        {
            Card card = Players[Player].Hand[Card];

            Players[Player].Hand.Remove(card);
            Players[Player].InPlay.Add(card);
            Players[Player].Actions--;

            AddSilver = 0;

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

                    int Chapeli;
                    int ChapelIndex;
                    bool ChapelException = true;
                    string ChapelString;
                    Card ChapelCard;

                    for (Chapeli = 1; Chapeli <= 4; Chapeli++)
                    {
                        do
                        {
                            try
                            {
                                Players[Player].ShowHand();
                                Console.Write("Do you want to trash a card from your hand? (y/n): ");
                                ChapelString = Console.ReadLine();

                                if (ChapelString == "y" || ChapelString == "Y")
                                {
                                    do
                                    {
                                        try
                                        {
                                            Console.Write("Enter the indexnumber of the card to trash: ");
                                            ChapelIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                                            ChapelCard = Players[Player].Hand[ChapelIndex];
                                            Players[Player].Hand.Remove(Players[Player].Hand[ChapelIndex]);
                                            Stacks[GetStackIndex(Stacks, "Trash")].Cards.Add(ChapelCard);
                                            ChapelException = false;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Enter a valid number.");
                                        }
                                    } while (ChapelException == true);
                                }
                                else if (ChapelString == "n" || ChapelString == "N")
                                {
                                    ChapelException = false;
                                }
                                else
                                {
                                    throw new Exception("");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Enter y or n.");
                            }

                        } while (ChapelException == true);
                    }

                    break;

                case "Council Room":

                    Players.DrawCards(4, Player, "Hand");
                    Players[Player].Buys++;

                    for (int i = 0; i <= Players.Count() - 1; i++)
                    {
                        if (i != Player)
                        {
                            Players.DrawCards(1, i, "Hand");
                        }
                    }

                    break;

                case "Feast":

                    int Feasti = 0;
                    List<int> FeastCards = new List<int>();
                    Card FeastCard;
                    int FeastIndex = 0;
                    bool FeastException = true;

                    Players[Player].InPlay.Remove(card);
                    Stacks[GetStackIndex(Stacks, "Trash")].Cards.Add(card);

                    foreach (Stack stack in Stacks)
                    {
                        Feasti++;
                        FeastCard = stack.Cards.First();
                        if (stack.Cards.First().Price <= 5 && stack.Cards.First().Name != "Trash" && !(stack.Cards.First().Type.Contains("Curse")))
                        {
                            Console.Write("{0}: {1}     ", Feasti, FeastCard.Name);
                            FeastCards.Add(Feasti);
                        }
                    }

                    do
                    {
                        try
                        {
                            Console.Write("\nEnter the number in front of the card you want to add to your discardpile: ");
                            FeastIndex = Convert.ToInt32(Console.Read()) - 1;
                            if (!(FeastCards.Contains(FeastIndex)))
                            {
                                throw new Exception("");
                            }
                            FeastCard = Stacks[Feasti].Cards.First();
                            Stacks[Feasti].Cards.Remove(Stacks[Feasti].Cards.First());
                            Players[Player].DiscardPile.Add(FeastCard);
                            FeastException = false;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid entry, enter a number from the list.");
                        }
                    }
                    while (FeastException == true);

                    break;

                case "Festival":

                    Players[Player].Actions += 2;
                    Players[Player].Buys++;
                    Players[Player].Gold += 2;

                    break;

                case "Harbringer":

                    bool HarbringerException = true;
                    int Harbringeri = 0;
                    List<int> HarbringerIndex = new List<int>();
                    Card HarbringerCard;

                    Players.DrawCards(1, Player, "Hand");
                    Players[Player].Actions++;
                    
                    foreach (Card HarbringerCard2 in Players[Player].DiscardPile)
                    {
                        Console.Write("{0}. {1}     ", Harbringeri, HarbringerCard2.Name);
                        HarbringerIndex.Add(Harbringeri);
                        Harbringeri++;
                    }

                    do
                    {
                        try
                        {
                            Console.Write("\nEnter the number of card you want to put from your discardpile to the top of your deck: ");
                            Harbringeri = Convert.ToInt32(Console.ReadLine());
                            if (HarbringerIndex.Contains(Harbringeri))
                            {
                                HarbringerCard = Players[Player].DiscardPile[Harbringeri];
                                Players[Player].DiscardPile.Remove(Players[Player].DiscardPile[Harbringeri]);
                                Players[Player].DrawPile.Insert(0, HarbringerCard);
                                HarbringerException = false;
                            }
                            else
                            {
                                throw new Exception("");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid entry, enter a valid indexnumber.");
                        }

                    } while (HarbringerException == true);

                    break;

                case "Laboratory":

                    Players.DrawCards(2, Player, "Hand");
                    Players[Player].Actions++;

                    break;

                case "Library":

                    Card LibraryCard;

                    do
                    {
                        Players.DrawCards(1, Player, "Hand");
                        LibraryCard = Players[Player].Hand.Last();

                        if (LibraryCard.Type.Contains("Action"))
                        {
                            Players[Player].Hand.Remove(Players[Player].Hand.Last());
                            Players[Player].DiscardPile.Add(LibraryCard);
                        }

                    } while (Players[Player].Hand.Count < 7);

                    break;

                case "Market":

                    Players.DrawCards(1, Player, "Hand");
                    Players[Player].Actions++;
                    Players[Player].Buys++;
                    Players[Player].Gold++;

                    break;

                case "Merchant":

                    Players.DrawCards(1, Player, "Hand");
                    Players[Player].Actions++;

                    AddSilver++;

                    break;

                case "Militia":

                    Players[Player].Gold += 2;
                    
                    List<Card> MilitiaCards = new List<Card>();
                    bool MilitiaAttack = true;
                    int Militiai = 0;
                    int Militiaj = 0;
                    List<int> MilitiaIndex = new List<int>();
                    int Militiak = 0;
                    bool MilitiaException = true;

                    foreach (Player player in Players)
                    {
                        if (Militiai != Player)
                        {                            
                            do
                            {
                                MilitiaIndex.Clear();
                                Console.WriteLine("Select a reaction card to Play: ");
                                foreach (Card MilitiaCard in Players[Militiai].Hand)
                                {
                                    if (MilitiaCard.Type.Contains("Reaction"))
                                    {
                                        Console.Write("{0}. {1}     ", Militiaj, MilitiaCard.Name);
                                        MilitiaIndex.Add(Militiaj);
                                        Militiaj++;
                                    }
                                }

                                if (!MilitiaIndex.Any())
                                {
                                    do
                                    {
                                        try
                                        {
                                            Militiak = Convert.ToInt32(Console.Read());
                                            if (MilitiaIndex.Contains(Militiak))
                                            {
                                                MilitiaAttack = Players.PlayReaction(Militiai, Militiak);
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Enter a valid number to play a reaction.");
                                        }

                                    } while (MilitiaException == true);
                                }

                                if (MilitiaAttack == false)
                                {
                                    break;
                                }

                                Militiaj = 0;
                                MilitiaIndex.Clear();
                                MilitiaException = true;
                                Console.WriteLine("Select a card to discard:");
                                foreach (Card MilitiaCard in Players[Militiai].Hand)
                                {
                                    Console.Write("{0}. {1}     ", Militiaj, MilitiaCard.Name);
                                    MilitiaIndex.Add(Militiaj);
                                    Militiaj++;
                                }

                                Console.Write("Enter an indexnumber of the card to discard: ");
                                do
                                {
                                    try
                                    {                                        
                                        Militiak = Convert.ToInt32(Console.Read()) - 1;
                                        if (MilitiaIndex.Contains(Militiak))
                                        {
                                            Players[Militiai].DiscardPile.Add(Players[Militiai].Hand[Militiak]);
                                            Players[Militiai].Hand.Remove(Players[Militiai].Hand[Militiak]);
                                            MilitiaException = false;
                                        }
                                        else
                                        {
                                            throw new Exception("");
                                        }
                                    }
                                    catch
                                    {
                                        Console.Write("\nEnter a valid number for a Reaction: ");
                                    }
                                } while (MilitiaException == true);

                            } while (Players[Player].Hand.Count <= 3);
                        }

                        Militiai++;
                    }
                    
                    break;

                case "Mine":

                    bool MineException = true;
                    List<int> MineIndex = new List<int>();
                    int Minei = 0;
                    Card MineCard2;

                    Console.WriteLine("Select a treasure card to trash: ");

                    foreach (Card MineCard in Players[Player].Hand)
                    {
                        if (MineCard.Type.Contains("Treasure"))
                        {
                            Console.Write("{0}. {1}     ", Minei, MineCard.Name);
                            MineIndex.Add(Minei);
                            Minei++;
                        }
                    }

                    Console.Write("\nEnter the number of the card to trash: ");
                    do
                    {                        
                        try
                        {
                            Minei = Convert.ToInt32(Console.Read());
                            if (MineIndex.Contains(Minei))
                            {
                                Minei = Players[Player].Hand[Minei].Price;
                                MineCard2 = Players[Player].Hand[Minei];
                                Players[Player].Hand.Remove(Players[Player].Hand[Minei]);
                                Stacks[GetStackIndex(Stacks, "Trash")].Cards.Add(MineCard2);
                                MineException = false;
                            }
                            else
                            {
                                throw new Exception("");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Enter a valid indexnumber of the treasure card to trash");
                        }
                    } while (MineException == true);


                    int Minej = 0;
                    MineIndex.Clear();

                    Console.WriteLine("Select a treasure card to get:");
                    foreach (Stack stack in Stacks)
                    {
                        if (stack.Cards.First().Type.Contains("Treasure") && stack.Cards.First().Price <= Minei + 3)
                        {
                            Console.Write("{0}. {1}     ", Minej, stack.Cards.First().Name);
                            MineIndex.Add(Minej);
                        }
                    }
                    
                    MineException = true;
                    Console.Write("Enter an indexnumber to add to your deck: ");
                    do
                    {
                        try
                        {
                            Minei = Convert.ToInt32(Console.Read());
                            if (MineIndex.Contains(Minei))
                            {
                                MineCard2 = Stacks[Minei].Cards.First();
                                Stacks[Minei].Cards.Remove(Stacks[Minei].Cards.First());
                                Players[Player].DiscardPile.Add(MineCard2);
                                MineException = false;
                            }
                            else
                            {
                                throw new Exception("");
                            }
                        }
                        catch
                        {
                            Console.Write("Enter a valid indexnumber.\n");
                        }
                    } while (MineException == true);

                    break;

                case "Moat":

                    Players.DrawCards(2, Player, "Hand");

                    break;

                case "Moneylender":

                    bool MoneylenderException = true;
                    int Moneylenderi = 0;
                    List<int> MoneylenderIndex = new List<int>();

                    foreach(Card MoneylenderCard2 in Players[Player].Hand)
                    {
                        if (MoneylenderCard2.Name == "Copper")
                        {
                            Console.Write("{0}. {1}     ");
                            MoneylenderIndex.Add(Moneylenderi);
                            Moneylenderi++;
                        }
                    }

                    if (!MoneylenderIndex.Any())
                    {
                        break;
                    }

                    Console.Write("\nEnter the indexnumber of the copper card to discard: ");

                    do
                    {
                        try
                        {
                            Moneylenderi = Convert.ToInt32(Console.Read());
                            if (MoneylenderIndex.Contains(Moneylenderi))
                            {
                                Stacks[GetStackIndex(Stacks, "Trash")].Cards.Add(Players[Player].Hand[Moneylenderi]);
                                Players[Player].Hand.Remove(Players[Player].Hand[Moneylenderi]);
                                Players[Player].Gold += 3;
                                MoneylenderException = false;
                            }
                            else
                            {
                                throw new Exception("");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enter a valid indexnumber");
                        }

                    } while (MoneylenderException == true);

                    break;

                case "Poacher":

                    Players.DrawCards(1, Player, "Hand");
                    Players[Player].Actions++;
                    Players[Player].Gold++;



                    break;

                case "Remodel":
                    break;

                case "Sentry":

                    Players.DrawCards(1, Player, "Hand");
                    Players[Player].Actions++;

                    break;

                case "Smithy":

                    Players.DrawCards(3, Player, "Hand");

                    break;

                case "Spy":

                    Players.DrawCards(1, Player, "Hand");
                    Players[Player].Actions++;

                    break;

                case "Thief":
                    break;

                case "Throne Room":
                    break;

                case "Vassal":

                    Players[Player].Gold += 2;

                    break;

                case "Village":

                    Players.DrawCards(1, Player, "Hand");
                    Players[Player].Actions += 2;

                    break;

                case "Witch":

                    Players.DrawCards(2, Player, "Hand");

                    break;

                case "Woodcutter":

                    Players[Player].Buys++;
                    Players[Player].Gold += 2;

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
                    Players[Player].Gold += AddSilver;
                    AddSilver = 0;
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

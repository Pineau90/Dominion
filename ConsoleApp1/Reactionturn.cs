using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public static class Reactionturn
    {
        public static bool PlayReaction(List<Player> Players, int Player, List<Stack> Stacks)
        {
            int i = 0;
            List<int> iList = new List<int>();
            string ReactionYN;
            bool CancelAttack = false;

            foreach (Card card in Players[Player].Hand)
            {
                if (card.Type.Contains("Reaction"))
                {
                    Console.Write("{0}. {1}     ", i, card.Name);
                    iList.Add(i);
                }
                i++;
            }

            bool ReactionException = true;
            Console.Write("\n\nDo you want to play a reaction (y/n)? ");
            do
            {
                try
                {

                    ReactionYN = Console.ReadLine();
                    if (!(ReactionYN == "y" || ReactionYN == "Y" || ReactionYN == "n" || ReactionYN == "N"))
                    {
                        throw new Exception("");
                    }
                    
                    if (ReactionYN == "y" || ReactionYN == "Y")
                    {
                        int PlayIndex = 0;
                        List<int> ListPlayIndex = new List<int>();

                        Console.WriteLine("\nSelect reaction card to play: \n");
                        foreach(Card card in Players[Player].Hand)
                        {
                            if (card.Type.Contains("Reaction"))
                            {
                                Console.Write("{0}. {1}", PlayIndex, card.Name);
                                ListPlayIndex.Add(PlayIndex);
                            }
                            PlayIndex++;
                        }

                        bool PlayReactionException = true;                        
                        PlayIndex = 0;
                        Console.Write("\nEnter the number in front of the card to play as reaction: ");
                        do
                        {
                            try
                            {
                                PlayIndex = Convert.ToInt32(Console.Read());
                                if (!(ListPlayIndex.Contains(PlayIndex)))
                                {
                                    throw new Exception("");
                                }
                                PlayReactionException = false;
                                CancelAttack = Playcard.PlayReaction(Players, Player, PlayIndex);                                
                            }
                            catch
                            {
                                Console.Write("\nSelect a reaction card to play.");
                            }
                        } while (PlayReactionException == true);

                        //Select card to play and play it, maybe cancel out the attacks effect
                    }
                    ReactionException = false;
                }
                catch
                {
                    Console.Write("Invalid entry, enter y or n");
                }
            }
            while (ReactionException == true);
            
            return CancelAttack;
        }
    }
}

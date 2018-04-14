using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Dominion
{
    class Program
    {        
        static void Main(string[] args)
        {
            List<string> KingdomCards = new List<string>();

            KingdomCards.BasicCards();
            KingdomCards.ShuffleCards();
            KingdomCards = KingdomCards.GetRange(0, 10);

            Stack Stack0 = new Stack(KingdomCards[0]);
            Stack0.AddCardsToStack(KingdomCards[0]);

            Stack Stack1 = new Stack(KingdomCards[1]);
            Stack1.AddCardsToStack(KingdomCards[1]);

            Stack Stack2 = new Stack(KingdomCards[2]);
            Stack2.AddCardsToStack(KingdomCards[2]);

            Stack Stack3 = new Stack(KingdomCards[3]);
            Stack3.AddCardsToStack(KingdomCards[3]);

            Stack Stack4 = new Stack(KingdomCards[4]);
            Stack4.AddCardsToStack(KingdomCards[4]);

            Stack Stack5 = new Stack(KingdomCards[5]);
            Stack5.AddCardsToStack(KingdomCards[5]);

            Stack Stack6 = new Stack(KingdomCards[6]);
            Stack6.AddCardsToStack(KingdomCards[6]);

            Stack Stack7 = new Stack(KingdomCards[7]);
            Stack7.AddCardsToStack(KingdomCards[7]);

            Stack Stack8 = new Stack(KingdomCards[8]);
            Stack8.AddCardsToStack(KingdomCards[8]);

            Stack Stack9 = new Stack(KingdomCards[9]);
            Stack9.AddCardsToStack(KingdomCards[9]);
                        
            Stack Curse = new Stack("Curse");
            Curse.AddCardsToStack(Curse.Name);
                                 
            Stack Estate = new Stack("Estate");
            Estate.AddCardsToStack(Estate.Name);

            Stack Duchy = new Stack("Duchy");
            Duchy.AddCardsToStack(Duchy.Name);
            
            Stack Province = new Stack("Province");
            Province.AddCardsToStack(Province.Name);

            Stack Copper = new Stack("Copper");
            Copper.AddCardsToStack(Copper.Name);

            Stack Silver = new Stack("Silver");
            Silver.AddCardsToStack(Silver.Name);

            Stack Gold = new Stack("Gold");
            Gold.AddCardsToStack(Gold.Name);

            Stack Trash = new Stack("Trash");

            Player Player1 = new Player("Pascal");
            Player1.StartHand();

            Player Player2 = new Player("Nicky");
            Player2.StartHand();
        }
    }    
}
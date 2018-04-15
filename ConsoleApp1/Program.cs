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
            Stack Stack1 = new Stack(KingdomCards[1]);
            Stack Stack2 = new Stack(KingdomCards[2]);
            Stack Stack3 = new Stack(KingdomCards[3]);
            Stack Stack4 = new Stack(KingdomCards[4]);
            Stack Stack5 = new Stack(KingdomCards[5]);
            Stack Stack6 = new Stack(KingdomCards[6]);
            Stack Stack7 = new Stack(KingdomCards[7]);
            Stack Stack8 = new Stack(KingdomCards[8]);
            Stack Stack9 = new Stack(KingdomCards[9]);
            Stack Curse = new Stack("Curse");
            Stack Estate = new Stack("Estate");
            Stack Duchy = new Stack("Duchy");
            Stack Province = new Stack("Province");
            Stack Copper = new Stack("Copper");
            Stack Silver = new Stack("Silver");
            Stack Gold = new Stack("Gold");
            Stack Trash = new Stack("Trash");
            
            Player Player1 = new Player("Pascal");
            Player1.StartDeck();

            Player Player2 = new Player("Nicky");
            Player2.StartDeck();
            
        }
    }    
}
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
                string value = Cards[k].Name;
                Cards[k] = Cards[n];
                Cards[n].Name = value;
            }
            return Cards;
        }        
    }
}

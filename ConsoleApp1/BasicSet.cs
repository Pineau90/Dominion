using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public static class BasicSet
    {
        public static List<string> BasicCards(this List<string> Cards)
        {
            Cards.Add("Adventurer");
            Cards.Add("Artisan");
            Cards.Add("Bandit");
            Cards.Add("Bureaucrat");
            Cards.Add("Cellar");
            Cards.Add("Chancellor");
            Cards.Add("Chapel");
            Cards.Add("Council Room");
            Cards.Add("Feast");
            Cards.Add("Festival");
            Cards.Add("Gardens");
            Cards.Add("Harbringer");
            Cards.Add("Laboratory");
            Cards.Add("Library");
            Cards.Add("Market");
            Cards.Add("Merchant");
            Cards.Add("Militia");
            Cards.Add("Mine");
            Cards.Add("Moat");
            Cards.Add("Moneylender");
            Cards.Add("Poacher");
            Cards.Add("Remodel");
            Cards.Add("Sentry");
            Cards.Add("Smithy");
            Cards.Add("Spy");
            Cards.Add("Thief");
            Cards.Add("Throne Room");
            Cards.Add("Vassal");
            Cards.Add("Village");
            Cards.Add("Witch");
            Cards.Add("Woodcutter");
            Cards.Add("Workshop");

            return Cards;
        }

        public static int CardsAmount(this string Card)
        {
            int i;
            if (Card == "Gardens" | Card == "Estate" | Card == "Duchy" | Card == "Province")
            {
                i = 8;
                return i;
            }
            else if (Card == "Copper")
            {
                i = 60;
                return i;
            }
            else if (Card == "Silver")
            {
                i = 40;
                return i;
            }
            else if (Card == "Gold")
            {
                i = 30;
                return i;
            }
            else
            {
                i = 10;
                return i;
            }
        }
    }
}

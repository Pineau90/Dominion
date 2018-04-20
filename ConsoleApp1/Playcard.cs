using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public static class Playcard
    {
        public static void PlayAction(this List<Player> Players, int Player, int Card)
        {
            Card card = Players[Player].Hand[Card];

            Players[Player].Hand.Remove(card);
            Players[Player].InPlay.Add(card);
            Players[Player].Actions--;

            switch (card.Name)
            {
                case "Adventurer":
                    break;
                case "Artisan":
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

            switch (card.Name)
            {
                case "Copper":
                    break;
                case "Silver":
                    break;
                case "Gold":
                    break;
            }
            
        }

        public static void PlayReaction(this List<Player> Players, int Player, int Card)
        {

        }
    }
}

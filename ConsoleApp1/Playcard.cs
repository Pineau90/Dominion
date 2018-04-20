using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
    public static class Playcard
    {
        public static void PlayCard(this List<Player> Players, int Player, int Card)
        {
            Players[Player].InPlay.Add(Players[Player].Hand[Card]);
            Players[Player].Actions--;
            Players[Player].Hand.Remove(Players[Player].Hand[Card]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code
{
    public class Tasks
    {
       public static Dictionary<string, string> BestResultPlayer(List<Player> players)
       {
            Dictionary<string, string> BestPlayer = new Dictionary<string, string>();
            double BestResult = 0;
            foreach(var player in players)
                if(player.KD() > BestResult)
                {
                    BestResult = player.KD();
                    BestPlayer.Add(player.Name, player.LastName);
                }
            return BestPlayer;
       }
        public static List<Player> UniversalPlayers(List<Player> players)
        {
            List<Player> Filtered = new List<Player>();
            foreach(var player in players)
            {
                if(player is CSPlayer && player is LoLPlayer)
                {
                    Filtered.Add(player);
                }
            }
            return Filtered;
        }
        public static List<Player> TeamOfSpesificPlayers(List<Player> players, int MinKills, int MaxDeaths)
        {
            var Team = new List<Player>();
            var CounterStrikePlayer = players.Where(a => a is CSPlayer).Where(a => ((CSPlayer)a).Deaths < MaxDeaths);
            var LeaguePlayer = players.Where(b => b is LoLPlayer).Where(b => ((LoLPlayer)b).Kills > MinKills);
            Team.AddRange(CounterStrikePlayer);
            Team.AddRange(LeaguePlayer);
            return Team;
        }
       /* public static List<Player> SortedPlayers(List<Player> players)
        {
            var Sorted = new List<Player>();
            var SortedCSPlayers = players.Where(a => a is CSPlayer).OrderBy(a => ((CSPlayer)a).KD);
            var SortedLoLPlayers = players.Where(a => a is LoLPlayer).OrderBy(a => ((LoLPlayer)a).KD);
            Sorted.AddRange(SortedCSPlayers);
            Sorted.AddRange(SortedLoLPlayers);
            return Sorted;
        }*/
    }
}
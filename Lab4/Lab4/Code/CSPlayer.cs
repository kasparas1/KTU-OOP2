using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code
{
    public class CSPlayer : Player
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public string FavGun { get; set; }
        public CSPlayer(int wheelNumber, DateTime date, string name, string lastName, string team, int kills, int deaths, string favGun) : base(wheelNumber, date, name, lastName, team)
        {
            Kills = kills;
            Deaths = deaths;
            FavGun = favGun;
        }
        public override double KD()
        {
            return Kills / Deaths;
        }
        public override string ToCSVLine()
        {
            return string.Join(";", WheelNumber, Date, Name, LastName, Team, Kills, Deaths, FavGun, "");
        }
    }
}
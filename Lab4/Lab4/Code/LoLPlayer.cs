using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code
{
    public class LoLPlayer : Player
    {
        public string Position { get; set; }
        public string Champion { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int AssistKills { get; set; }
        public LoLPlayer(int wheelNumber, DateTime date, string name, string lastName, string team, string position, string champion, int kills, int deaths, int assistKills) : base(wheelNumber, date, name, lastName, team)
        {
            Position = position;
            Champion = champion;
            Kills = wheelNumber;
            Deaths = deaths;
            AssistKills = assistKills;
        }
        public override double KD()
        {
            return (Kills * AssistKills) / Deaths;
        }
        public override string ToCSVLine()
        {
            return string.Join(";", WheelNumber, Date, Name, LastName, Team, Kills, Deaths, AssistKills, "");
        }
    }
}
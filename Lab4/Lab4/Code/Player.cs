using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code
{
    public abstract class Player
    {
        public int WheelNumber { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        private Player[] Players;
        public int Count { get; private set; }
        public Player(int wheelNumber, DateTime date, string name, string lastName, string team)
        {
            WheelNumber = wheelNumber;
            Date = date;
            Name = name;
            LastName = lastName;
            Team = team;
        }
        public abstract double KD();
        public abstract string ToCSVLine();
        public void AddPlayer(Player a)
        {
            Players[Count] = a;
            Count++;
        }
        public Player GetPlayer(int index)
        {
            return Players[index];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code
{
    public class Tornument
    {
        private Player[] Players;
        public int Count { get; private set; }
        public Tornument()
        {
            
        }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Code
{
    public class Scorpion
    {
        public int Size { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public Scorpion(int size, int i, int j)
        {
            Size = size;
            I = i;
            J = j;
        }
    }
}
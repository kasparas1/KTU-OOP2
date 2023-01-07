using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace lab1.Code
{
    public class ReadingNPrinting
    {
        public static Scorpion ReadData(string filename)
        {
            string[] AllLines = File.ReadAllLines(filename);
            int Size = int.Parse(AllLines[0]);
            int[] i = new int[40];
            int[] j = new int[40];
            for (int x = 0; x < Size; x++)
            {
                int z = 0;
                foreach(char line in AllLines[x])
                {
                    if (line == '+')
                    {
                        i[z] = x;
                        j[z] = x;
                    }
                    else if (line != '-' || line != '*')
                        throw new Exception($"Netinkama komanda: '{line}'");
                    z++;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

using System.Text;
using System.Collections;

namespace Lab4.Code
{

    public class ReadingNPrinting
    {
        public static IEnumerable<string> ReadLines(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    if (line.Length > 0)
                        yield return line;
            }
        }
        private static void PrintTableRow(StreamWriter writer, List<string> cells, List<int> widths)
        {
            for (int i = 0; i < widths.Count; i++)
            {
                if (widths[i] < 0)
                    writer.Write("| {0} ", cells[i].PadRight(-widths[i]));
                else
                    writer.Write("| {0} ", cells[i].PadLeft(widths[i]));
            }
            writer.WriteLine("|");
        }
        private static IEnumerable<Tuple<object, List<String>>> PrintTable(StreamWriter writer, string header, IEnumerable list, params string[] columns)
        {
            // 0. Collect all the rows
            List<List<string>> rows = new List<List<string>>();
            foreach (object item in list)
            {
                List<string> row = new List<string>();
                yield return Tuple.Create(item, row);
                rows.Add(row);
            }

            // 1. Determine the width of each column
            List<int> widths = new List<int>();
            int totalWidth = 3 * (columns.Length - 1);
            for (int i = 0; i < columns.Length; i++)
            {
                int width = columns[i].Length;
                foreach (var row in rows)
                {
                    width = Math.Max(row[i].Length, width);
                }
                widths.Add(width);
                totalWidth += width;
            }

            // If the header is longer than the body, make the last column wider.
            // So the table is a nice rectangle when output to the file
            if (header.Length > totalWidth)
            {
                widths[widths.Count - 1] += (header.Length - totalWidth);
                totalWidth = header.Length;
            }

            totalWidth += 2 * 2;

            // 2. Adjust widths to account for aligning
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i][0] == '-')
                {
                    widths[i] = -widths[i];
                    columns[i] = columns[i].Substring(1);
                }
            }

            // 3. Display the table
            writer.WriteLine(new string('-', totalWidth));
            writer.WriteLine("| {0} |", header.PadRight(totalWidth - 4));
            writer.WriteLine(new string('-', totalWidth));
            PrintTableRow(writer, new List<string>(columns), widths);
            writer.WriteLine(new string('-', totalWidth));
            if (rows.Count > 0)
            {
                foreach (var row in rows)
                {
                    PrintTableRow(writer, row, widths);
                }
            }
            else
            {
                writer.WriteLine("| {0} |", "Nėra".PadRight(totalWidth - 4));
            }
            writer.WriteLine(new string('-', totalWidth));

            writer.WriteLine();
        }
        public static List<Player> ReadPlayers(string filename)
        {
            var players = new List<Player>();
            string[] Lines = File.ReadAllLines(filename);
            int WheelNumber = int.Parse(Lines[0]);
            var date = DateTime.Parse(Lines[1].Trim());
            foreach (var line in Lines)
            {
                if (line.Contains(";"))
                {
                    string[] parts = line.Split(';');
                    if (parts.Length != 6 && parts.Length != 8)
                    {
                        throw new Exception($"Invalid number of values given: '{line}'");
                    }

                    string name = parts[0].Trim();
                    string lastName = parts[1].Trim();
                    string Team = parts[2].Trim();
                    System.Diagnostics.Debug.WriteLine(name);
                    if (parts.Length == 8)
                    {
                        string Position = parts[3].Trim();
                        string Champion = parts[4].Trim();
                        int kills = int.Parse(parts[5]);
                        int deaths = int.Parse(parts[6]);
                        int assistKills = int.Parse(parts[7]);
                        players.Add(new LoLPlayer(WheelNumber, date, name, lastName, Team, Position, Champion, kills, deaths, assistKills));
                    }
                    else if (parts.Length == 6)
                    {
                        int kills = int.Parse(parts[3]);
                        int deaths = int.Parse(parts[4]);
                        string favGun = parts[5].Trim();
                        players.Add(new CSPlayer(WheelNumber, date, name, lastName, Team, kills, deaths, favGun));
                    }
                }
            }
            
            return players;
        }
        public static List<List<Player>> ReadPlayersDir(string directory, string pattern = "*.txt")
        {
            if (!Directory.Exists(directory))
            {
                throw new Exception(string.Format("Directory '{0}' not found", directory));
            }
            var merged = new List<List<Player>>();
            foreach (var filename in Directory.GetFiles(directory, pattern))
            {
                merged.Add(ReadPlayers(filename));
            }
            return merged;
        }
        public static void PrintBestPlayer(StreamWriter writer, List<Player> players,string header)
        {
            foreach (var print in PrintTable(writer, header, players, "Vardas", "pavarde", "Komanda"))
            {
                Player player = (Player)print.Item1;
                List<string> row = print.Item2;
                row.Add(player.Name);
                row.Add(player.LastName);
                row.Add(player.Team);
            }

        }
        public static void PrintPlayersToCSV(StreamWriter writer, List<Player> players, string Title)
        {
            foreach (var print in PrintTable(writer, Title, players, "Pavarde", "Vardas", "Grupe"))
            {
                writer.WriteLine(Title);
                writer.Write(string.Join(";", "Rato Numeris", "Data", "Vardas", "Pavarde", "Komanda", "Nuzudimai", "Mirys", "Dalivavimas Nuzudimuose",  "Megstamiausias ginklas"));
                foreach (var player in players)
                {
                    
                    writer.WriteLine(player.ToCSVLine());
                }
            }
        }

    }
    
}
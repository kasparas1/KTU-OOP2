using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Linq.Expressions;
using System.Collections;

namespace Lab5.Code
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
        public static List<Electorate> ReadElectorate(string FileName)
        {
            var electorate = new List<Electorate>();
            var lines = File.ReadLines(FileName);
            DateTime Date = DateTime.Parse(lines.First());
            foreach (var line in lines.Skip(1))
            {
                string[] parts = line.Split(',');
                string LastName = parts[0];
                string Name = parts[1];
                int ArrivalHour = int.Parse(parts[2]);
                int ArrivalMinute = int.Parse(parts[3]);
                int ConsultationTime = int.Parse(parts[4]);
                electorate.Add(new Electorate(Date, LastName, Name, ArrivalHour, ArrivalMinute, ConsultationTime));
            }
            return electorate;
        }
        public static List<Seimas> ReadSeimas(string FileName)
        {
            var seimas = new List<Seimas>();
            foreach (var line in File.ReadLines(FileName))
            {
                string[] parts = line.Split(',');
                string SMLastName = parts[0];
                string SMName = parts[1];
                DateTime Date = DateTime.Parse(parts[2]);
                int StartHours = int.Parse(parts[3]);
                int StartMinutes = int.Parse(parts[4]);
                int EndHours = int.Parse(parts[5]);
                int EndMinutes = int.Parse(parts[6]);
                seimas.Add(new Seimas(SMLastName, SMName, Date, StartHours, StartMinutes, EndHours, EndMinutes));
            }
            return seimas;
        }
        public static void PrintElectorate(StreamWriter writer, List<Electorate> electorates, string header)
        {
            foreach (var print in PrintTable(writer, header, electorates, "Vardas", "pavarde"))
            {
                Electorate electorate = (Electorate)print.Item1;
                List<string> row = print.Item2;
                row.Add(electorate.LastName);
                row.Add(electorate.Name);
                
            }

        }
        public static void PrintSeimas(StreamWriter writer, List<Seimas> seimas, string header)
        {
            foreach (var print in PrintTable(writer, header, seimas, "Vardas", "pavarde"))
            {
                Seimas s = (Seimas)print.Item1;
                List<string> row = print.Item2;
                row.Add(s.SMLastName);
                row.Add(s.SMName);

            }

        }
    }


}
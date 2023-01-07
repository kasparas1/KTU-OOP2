using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Collections;
namespace Lab2
{
    public class ReadingNPrinting
    {
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
        public static StudentList ReadStudentInfo(string FileName)
        {
           StudentList studentMs = new StudentList();
            string[] Lines = File.ReadAllLines(FileName);
            foreach (string Line in Lines)
            {
                string[] Parts = Line.Split(',');
                string Module = Parts[0];
                string LastName = Parts[1];
                string Name = Parts[2];
                string Group = Parts[3];
                studentMs.AddToEnd(new StudentM(Module, LastName, Name, Group));
            }
            return studentMs;
        }
        public static ModuleList ReadModuleInfo(string FileName)
        {
            ModuleList moduleList = new ModuleList();
            string[] Lines = File.ReadAllLines(FileName);
            foreach(string Line in Lines)
            {
                string[] Parts = Line.Split(',');
                string ModuleName = Parts[0];
                string LecturerLName = Parts[1];
                string LecturerName = Parts[2];
                int Credits = int.Parse(Parts[3]);
                moduleList.AddToEnd(new ModuleInfo(ModuleName, LecturerLName, LecturerName, Credits));
            }
            return moduleList;
        }
        public static void PrintStudents(StreamWriter writer, StudentList students, string header)
        {
            foreach (var print in PrintTable(writer, header, students, "Modulio pavadinimas", "Pavarde", "Vardas", "Grupe"))
            {
                StudentM student = (StudentM)print.Item1;
                List<string> row = print.Item2;
                row.Add(student.Module);
                row.Add(student.LastName);
                row.Add(student.Name);
                row.Add(student.Group);
            }
        }
        public static void PrintSelectedStudents(StreamWriter writer, StudentList students, string header)
        {
            foreach (var print in PrintTable(writer, header, students, "Grupe"))
            {
                StudentM student = (StudentM)print.Item1;
                List<string> row = print.Item2;
                row.Add(student.Group);
            }
        }
        public static void PrintSpecStudents(StreamWriter writer, StudentList students, string header)
        {
            foreach (var print in PrintTable(writer, header, students, "Pavarde", "Vardas", "Grupe"))
            {
                StudentM student = (StudentM)print.Item1;
                List<string> row = print.Item2;
                row.Add(student.LastName);
                row.Add(student.Name);
                row.Add(student.Group);
            }
        }
        public static void PrintModules(StreamWriter writer, ModuleList modules, string header)
        {
            foreach(var print in PrintTable(writer, header, modules, "Modulio pavadinimas", "Pavarde", "Vardas", "Kreditai"))
            {
                ModuleInfo module = (ModuleInfo)print.Item1;
                List<string> row = print.Item2;
                row.Add(module.ModuleName);
                row.Add(module.LecturerLName);
                row.Add(module.LecturerName);
                row.Add(String.Format("{0}", module.Credits));
            }
        }
        public static void PrintSelectedModules(StreamWriter writer, ModuleList modules, string header)
        {
            foreach (var print in PrintTable(writer, header, modules, "Modulio pavadinimas", "Kreditai"))
            {
                ModuleInfo module = (ModuleInfo)print.Item1;
                List<string> row = print.Item2;
                row.Add(module.ModuleName);
                row.Add(String.Format("{0}", module.Credits));
            }
        }

    } 
}
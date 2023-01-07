using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            //FindControl("ResultsDiv").Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Module = TextBox1.Text;

            //FindControl("ResultsDiv").Visible = true;

            StudentList students = ReadingNPrinting.ReadStudentInfo(@"D:\Users\Creepertvlt\Desktop\KTU\Coding\GUI C#\Lab2\U7a.txt");
            ModuleList modules = ReadingNPrinting.ReadModuleInfo(@"D:\Users\Creepertvlt\Desktop\KTU\Coding\GUI C#\Lab2\U7b.txt");

            ModuleList mostPopularModules = Tasks.FilterModulesByLector(modules);
            StudentList StudentsWhoDidintChoose = Tasks.IfModuleIsSelectedByStudents(modules, students);
            StudentList SpecStudentList = Tasks.StudentsWithSpecificModule(Module, students);

            ShowModules(Table1, modules);
            ShowStudents(Table2, students);
            ShowMostPopulerModules(Table3, mostPopularModules);
            ShowStudentsWhoDidintChoose(Table4, StudentsWhoDidintChoose);
            ShowStudentsList(Table5, SpecStudentList);

            using (StreamWriter writer = new StreamWriter(@"D:\Users\Creepertvlt\Desktop\KTU\Coding\GUI C#\Lab2\Rez.txt"))
            {
                ReadingNPrinting.PrintStudents(writer, students, "Informacija apie studentus");
                ReadingNPrinting.PrintModules(writer, modules, "Informacija apie modulius");
                //ReadingNPrinting.PrintStudents(writer, SpesificModules, "ss apie modulius");
                ReadingNPrinting.PrintSelectedModules(writer, mostPopularModules, "Informacija apie destytoja kuris turi daugiausiai moduliu");
                ReadingNPrinting.PrintSelectedStudents(writer, StudentsWhoDidintChoose, "Studentai kurie pasirinko to destytojo modulius");
                ReadingNPrinting.PrintSpecStudents(writer, SpecStudentList, "Studentu sarasas pagal moduli");
            }
        }
        public IEnumerable<Tuple<object, TableRow>> ShowTable(Table table, IEnumerable list, params string[] columns)
        {
            TableRow header = new TableRow();
            foreach (string column in columns)
            {
                header.Cells.Add(new TableCell { Text = column });
            }
            table.Rows.Add(header);

            int n = 0;
            foreach (object item in list)
            {
                TableRow row = new TableRow();
                yield return Tuple.Create(item, row);
                table.Rows.Add(row);
                n++;
            }

            if (n == 0)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = "Nėra", ColumnSpan = columns.Length });
                table.Rows.Add(row);
            }
        }
        public void ShowMostPopulerModules(Table table, ModuleList modules)
        {
            foreach (var tuple in ShowTable(table, modules, "Modulio pavadinimas", "Kreditai"))
            {
                ModuleInfo module = (ModuleInfo)tuple.Item1;
                TableRow row = tuple.Item2;
                row.Cells.Add(new TableCell { Text = module.ModuleName });
                row.Cells.Add(new TableCell { Text = module.Credits.ToString() });
            }
        }
        public void ShowModules(Table table, ModuleList modules)
        {
            foreach (var tuple in ShowTable(table, modules, "Modulio pavadinimas", "Pavarde", "Vardas", "Kreditai"))
            {
                ModuleInfo module = (ModuleInfo)tuple.Item1;
                TableRow row = tuple.Item2;
                row.Cells.Add(new TableCell { Text = module.ModuleName });
                row.Cells.Add(new TableCell { Text = module.LecturerLName });
                row.Cells.Add(new TableCell { Text = module.LecturerName });
                row.Cells.Add(new TableCell { Text = module.Credits.ToString() });
            }
        }
        public void ShowStudents(Table table, StudentList Students)
        {
            foreach (var tuple in ShowTable(table, Students, "Modulio pavadinimas", "Pavarde", "Vardas", "Grupe"))
            {
                StudentM student = (StudentM)tuple.Item1;
                TableRow row = tuple.Item2;
                row.Cells.Add(new TableCell { Text = student.Module });
                row.Cells.Add(new TableCell { Text = student.LastName });
                row.Cells.Add(new TableCell { Text = student.Name });
                row.Cells.Add(new TableCell { Text = student.Group });
            }
        }
        public void ShowStudentsWhoDidintChoose(Table table, StudentList Students)
        {
            foreach (var tuple in ShowTable(table, Students,  "Grupe"))
            {
                StudentM student = (StudentM)tuple.Item1;
                TableRow row = tuple.Item2;
                row.Cells.Add(new TableCell { Text = student.Group });
            }
        }
        public void ShowStudentsList(Table table, StudentList Students)
        {
            foreach (var tuple in ShowTable(table, Students, "Pavarde", "Vardas", "Grupe"))
            {
                StudentM student = (StudentM)tuple.Item1;
                TableRow row = tuple.Item2;
                row.Cells.Add(new TableCell { Text = student.LastName });
                row.Cells.Add(new TableCell { Text = student.Name });
                row.Cells.Add(new TableCell { Text = student.Group });
            }
        }
    }
}
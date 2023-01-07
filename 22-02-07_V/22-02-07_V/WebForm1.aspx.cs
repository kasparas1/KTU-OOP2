using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _22_02_07_V
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private bool Button2Pressed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("-");
                for (int i = 14; i <= 25; i++)
                    DropDownList1.Items.Add(i.ToString());
            }
            TableRow row = new TableRow();
            TableCell Name = new TableCell();
            Name.Text = "<b>Vardas</b>";
            row.Cells.Add(Name);
            TableCell lastName = new TableCell();
            lastName.Text = "<b>Pavarde</b>";
            row.Cells.Add(lastName);
            TableCell school = new TableCell();
            school.Text = "<b>Mokykla</b>";
            row.Cells.Add(school);
            TableCell age = new TableCell();
            age.Text = "<b>Amzius</b>";
            row.Cells.Add(age);
            TableCell language = new TableCell();
            language.Text = "<b>Prog. Kalbos zinojimas</b>";
            row.Cells.Add(language);
            Table1.Rows.Add(row);
            if (Session["users"] != null)
            {
                string[] participants = ((string)Session["users"]).Split(';');
                foreach (string participant in participants)
                {
                    string[] parts = participant.Split('|');
                    InsertRecord(parts[0], parts[1], parts[2], parts[3], parts[4]);
                }
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Name = TextBox1.Text;
            string LastName = TextBox2.Text;
            string School = TextBox3.Text;
            string Age = DropDownList1.Text;
            string Language = " ";
            foreach (ListItem item in CheckBoxList1.Items)
                if (item.Selected)
                    Language += item.Text + " ";
            Language = Language.TrimEnd();

            string participant = String.Join("|", Name, LastName, School, Age, Language);
            if (Session["users"] == null)
            {
                Session["users"] = participant;
            }
            else
            {
                Session["users"] += ";" + participant;
            }
            InsertRecord(Name, LastName, School, Age, Language);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label7.Text = String.Format("Dalyvių kiekis: {0}", 0);
            Session.Clear();
        }
        private void InsertRecord( string Name, string LastName, string School, string Age, string Language)
        {
            TableCell name = new TableCell();
            TableRow row = new TableRow();
            name.Text = TextBox1.Text;
            row.Cells.Add(name);
            TableCell lastName = new TableCell();
            lastName.Text = TextBox2.Text;
            row.Cells.Add(lastName);
            TableCell school = new TableCell();
            school.Text = TextBox3.Text;
            row.Cells.Add(school);
            TableCell age = new TableCell();
            age.Text = DropDownList1.Text;
            row.Cells.Add(age);
            TableCell language = new TableCell();
            language.Text = CheckBoxList1.Text;
            row.Cells.Add(language);
            Label7.Text = String.Format("Dalyvių kiekis: {0}", Table1.Rows.Count);
            
            Table1.Rows.Add(row);

        }  
    }
}
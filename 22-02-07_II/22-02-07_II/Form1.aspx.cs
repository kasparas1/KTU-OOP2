using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace _22_02_07_II
{
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double H = double.Parse(TextBox1.Text, CultureInfo.InvariantCulture);
            double R = double.Parse(TextBox2.Text, CultureInfo.InvariantCulture);
            double r = double.Parse(TextBox3.Text, CultureInfo.InvariantCulture);
            double V = (1.0 / 3) * 3.14 * H * (R * R + R * r + r * r);
            TextBox4.Text = V.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Lab4.Code;
using System.Collections;

namespace Lab4
{
    public partial class Forma : System.Web.UI.Page
    {
        //private List<List<Code.Player>> playerss = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string[] playerFiles = { "Players1.txt", "Players2.txt", "Players3.txt" };
            //foreach (string name in playerFiles)
            //{
            //    string filename = Server.MapPath($"App_Data/{name}");
            //    if (!File.Exists(filename))
            //    {
            //        InOutUtils.GenerateFakeActors(filename);
            //    }
            //}
            //File.Delete(Server.MapPath("App_Data/Rezultatai.txt"));
            //try
            //{
            //    actorss = InOutUtils.ReadActorsDir(Server.MapPath("App_Data"));
            //}
            //catch (Exception ex)
            //{
            //    Label5.Text = ex.Message;
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (playerss == null) return;
            int MinKills = int.Parse(TextBox1.Text);
            int MaxDeaths = int.Parse(TextBox2.Text);

            List<Player> players = ReadingNPrinting.ReadPlayers(Server.MapPath("App_Data/Player1.txt"));
            System.Diagnostics.Debug.WriteLine(players);
            System.Diagnostics.Debug.WriteLine("labas, ka tu");
            var BestPlayer = Tasks.BestResultPlayer(players);
            var UniversalPlayer = Tasks.UniversalPlayers(players);
            var SpecificPlayers = Tasks.TeamOfSpesificPlayers(players, MinKills, MaxDeaths);
            //var Sorted = Tasks.SortedPlayers(players);


            // ReadingNPrinting.PrintPlayersToCSV("App_data/Visi.csv", Sorted, "Surikiuoti visi zaidejai");

            using (StreamWriter writer = new StreamWriter(Server.MapPath("AppData/rez.txt")))
            {
                ReadingNPrinting.PrintPlayersToCSV(writer , players, "Visi Zaidejai");
                ReadingNPrinting.PrintPlayersToCSV(writer , UniversalPlayer, "Universalus zaidejai");
                ReadingNPrinting.PrintPlayersToCSV(writer , SpecificPlayers, "Specific Players");
            }
        }
       
    }
}
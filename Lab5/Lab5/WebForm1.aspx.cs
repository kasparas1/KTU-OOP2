using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab5.Code;

namespace Lab5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<List<Electorate>> Electorates;
        List<Seimas> Seimass;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime Date = Calendar1.SelectedDate;
            

            List<Seimas> seimas = ReadingNPrinting.ReadSeimas(Server.MapPath("App_Data/Duom2.txt"));
            List<Electorate> electorates = ReadingNPrinting.ReadElectorate(Server.MapPath("App_Data/Duom.txt"));
            //List<Electorate> Consultation = Tasks.FindAvrageConsultationTime(seimas, electorates);
            /* .Where(s => s.SubscriptionStart <= month && month < s.SubscriptionStart + s.SubscriptionLength)
                .Join(Publications, s => s.SubscriptionID, p => p.ID, (s, p) => new {
                    p.Publisher,
                    Income = p.PricePerMonth * s.SubscriptionLength
                }).
                .Select(x => new {
                    Publisher = x.Key,
                    Income = x.Sum(s => s.Income)
                }).ToDictionary(x => x.Publisher, x => x.Income);
*/
            var electoratess = Electorates.SelectMany(x => x).ToList();
            var Consultation = electoratess.Where(s => s.Date == Date).Join(Seimass, s => s.LastName, p => p.SMLastName, (s, p) => new
            {
                p.SMLastName,
                Time = ((s.ArrivalHour * 60) + s.ArrivalMinute) >= ((p.StartHours * 60) + p.StartMinutes) && ((s.ArrivalHour * 60) + s.ArrivalMinute + s.ConsultationTime) <= ((p.EndHours * 60) + p.EndMinutes),
            }).Select(x => new
            {
                SMLastName = x.Key,
                Time = x.Avrage(s => s.Time),
            }).ToDictionary(x => x.SMLastName, x => x.Time);
            /*.Select(x => new {
                Publisher = x.Key,
                Income = x.Sum(s => s.Income),
                Publications = x.GroupBy(p => p.Publication).Select(b => new {
                    ID = b.Key,
                    Income = b.Sum(c => c.Income)
                }).ToDictionary(b => b.ID, b => b.Income)
            }).OrderBy(x => x.Income)
            .ThenBy(x => x.Publisher)
            .Select(x => Tuple.Create(x.Publisher, x.Income, x.Publications))
            .ToList();*/

            using (StreamWriter writer = new StreamWriter(Server.MapPath("App_Data/rez.txt")))
            {
                ReadingNPrinting.PrintElectorate(writer, Consultation, "ss");
                ReadingNPrinting.PrintSeimas(writer, seimas, "a");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            
               
        }
    }
}
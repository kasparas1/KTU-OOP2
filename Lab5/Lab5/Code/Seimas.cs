using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Code
{
     
    public class Seimas
    {
        public string SMLastName { get; set; }
        public string SMName { get; set; }
        public DateTime Date { get; set; }
        public int StartHours { get; set; }
        public int StartMinutes { get; set; }
        public int EndHours { get; set; }
        public int EndMinutes { get; set; }
        public Seimas(string SMlastname, string SMname, DateTime date, int startHours, int startMinutes, int endHours, int endMinutes)
        {
            SMLastName = SMlastname;
            SMName = SMname;
            Date = date;
            StartHours = startHours;
            StartMinutes = startMinutes;
            EndHours = endHours;
            EndMinutes = endMinutes;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Code
{
   

    public class Electorate
    {
        public DateTime Date { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int ArrivalHour { get; set; }
        public int ArrivalMinute { get; set; }
        public int ConsultationTime { get; set; }
        public Electorate(DateTime date, string lastName, string name, int arrivalHour, int arrivalMinute, int consultationTime)
        {
            Date = date;
            LastName = lastName;
            Name = name;
            ArrivalHour = arrivalHour;
            ArrivalMinute = arrivalMinute;
            ConsultationTime = consultationTime;
        }
        
    }
}
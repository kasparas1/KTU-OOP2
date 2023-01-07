using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Lab5.Code
{
    public class Tasks
    {
        public static IEnumerable<Electorate> FindConsultations(int StartHours, int StartMinutes, int EndHours, int EndMinutes, List<Electorate> electorates)
        {
            IEnumerable <Electorate> Consultations = new List<Electorate>();
            Consultations = electorates.Where(n => n.ArrivalHour >= StartHours && n.ArrivalMinute >= StartMinutes && n.ArrivalHour <= EndHours && (n.ArrivalMinute + n.ConsultationTime) <= EndMinutes);
            return Consultations;
        }
        public static List<Electorate> FindAvrageConsultationTime(List<Seimas> seimas, List<Electorate> Electorates)
        {
            List< Electorate > A= new List<Electorate>();
            foreach (var s in seimas)
            {
                var Consultations = FindConsultations(s.StartHours, s.StartMinutes, s.EndHours, s.EndMinutes, Electorates);
                A.AddRange(Consultations);
            }  
            return A;
        }
    }
    //var incomes = subscribers
    //            .Where(s => s.SubscriptionStart <= month && month < s.SubscriptionStart + s.SubscriptionLength)
    //            .Join(Publications, s => s.SubscriptionID, p => p.ID, (s, p) => new {
    //                p.Publisher,
    //                Income = p.PricePerMonth * s.SubscriptionLength
    //            }).GroupBy(x => x.Publisher)
    //            .Select(x => new {
    //                Publisher = x.Key,
    //                Income = x.Sum(s => s.Income)
    //            }).ToDictionary(x => x.Publisher, x => x.Income);
    //var Sorted = new List<Player>();
    //var SortedCSPlayers = players.Where(a => a is CSPlayer).OrderBy(a => ((CSPlayer)a).KD);
    //var SortedLoLPlayers = players.Where(a => a is LoLPlayer).OrderBy(a => ((LoLPlayer)a).KD);
    //Sorted.AddRange(SortedCSPlayers);
    //        Sorted.AddRange(SortedLoLPlayers);
    //        return Sorted;
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NapolniRD;
using System.Timers;

namespace NapolniRD
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {


            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10000;
            aTimer.Enabled = true;

            Console.ReadLine();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            RDEntities db = new RDEntities();
            Random r = new Random();
            TestDatas zadnji = (from x in db.TestDatas
                                orderby x.Id descending
                                select x).FirstOrDefault();
            TestDatas nov = new TestDatas();
            for (int k=1; k<6;k++)
            {
                nov.IdPostaje = k;
                if (zadnji.Dan!=30)
                {
                    nov.Dan = zadnji.Dan + 1;
                    nov.Mesec = zadnji.Mesec;
                    nov.Leto = zadnji.Leto;
                }
                else
                {
                    nov.Dan = 1;
                    if (zadnji.Mesec!=12)
                    {
                        nov.Mesec = zadnji.Mesec + 1;
                        nov.Leto = zadnji.Leto;
                    }
                    else
                    {
                        nov.Mesec = 1;
                        nov.Leto = zadnji.Leto + 1;
                    }
                }
                nov.Podatek1 = r.Next(5, 20) + r.Next(5, 20) + r.Next(5, 20);
                nov.Podatek2 = r.Next(2, 10) + r.Next(2, 10) + r.Next(2, 10);
                db.TestDatas.Add(nov);
                db.SaveChanges();
                Console.WriteLine(nov.IdPostaje+" - "+nov.Dan+". "+nov.Mesec+". "+nov.Leto+" - "+nov.Podatek1+" - "+nov.Podatek2);
            }            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NapolniRD;

namespace NapolniRD
{
    class Program
    {
        static void Main(string[] args)
        {
            RDEntities db = new RDEntities();
            Random r = new Random();

            for (int k=0; k<10; k++)  //leto
            {
                TestDatas nov = new TestDatas();
                nov.Leto = k + 2018;
                for(int l=1;l<13; l++)   //mesec
                {
                    nov.Mesec = l;
                    for(int j=1;j<31;j++)   //dan
                    {
                        nov.Dan = j;
                        for(int p=1;p<6;p++)   //postaje
                        {
                            nov.IdPostaje = p;
                            nov.Podatek1 = r.Next(5, 20) + r.Next(5, 20) + r.Next(5, 20);
                            nov.Podatek2 = r.Next(2, 10) + r.Next(2, 10) + r.Next(2, 10);
                            db.TestDatas.Add(nov);
                            db.SaveChanges();
                            Console.WriteLine(nov.IdPostaje + " " + nov.Dan + " " + nov.Mesec + " " + nov.Leto);
                        }
                    }
                    
                }
            }
            db.SaveChanges();
            Console.ReadLine();
        }
    }
}

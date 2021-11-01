using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ScanApp.db.Database;
using ScanApp.db.Model;

namespace ScanApp
{
    class Program
    {
       
        static void Main(string[] args)
        {

            using (var db = new ExContext())
            {

                //db.ResetDB();

                Stopwatch watch = new();
                watch.Start();

                //var test = db.Apps.Count();

                Console.WriteLine("Scanning...");
                Scanner s = new(db);
                s.Scan(93);
                //db.Filters.Add(new ScanApp.db.Model.Filter("E02250", "eProduct.CSVLoader.eProduct.CSVCashbookLoader"));
                //db.SaveChanges();


                var query = from a in db.Apps
                            orderby a.Name
                            select a;
                Console.WriteLine("All apps in database");
                foreach (var app in query)
                {
                   
                    Console.WriteLine(app.Name + " ---  ID: " + app.AppId + " --- Exceptions: " + db.GetExceptionsByAppId(app.AppId).Count);
                }
                Console.WriteLine("\n\n\nTime elapsed: " + watch.ElapsedMilliseconds);
            }
        }
    }
}

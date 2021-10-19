using Scan_console_app.Database;
using Scan_console_app.Model;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Scan_console_app
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
                //ScannerNoDb s = new ScannerNoDb(db);
                //s.Scan(-20);
                Scanner s = new(db);
                s.Scan(35);
                Console.WriteLine("Scanning...");


                var query = from a in db.Apps
                            orderby a.Name
                            select a;
                Console.WriteLine("All apps in database");
                foreach (var app in query)
                {
                    Console.WriteLine(app.Name + " ---  ID: " + app.AppId + " --- Exceptions: " + db.GetExceptionsByApp(app).Count);
                }
                Console.WriteLine("\n\n\nTime elapsed: " + watch.ElapsedMilliseconds);
            }
        }
    }
}

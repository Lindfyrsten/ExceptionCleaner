
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ScanApp.db.Database;
using ScanApp.db.Model;

namespace ScanApp
{
    class Scanner
    {
        private readonly ExContext Db;
        public Scanner(ExContext Db)
        {
            this.Db = Db;
        }
        /// <summary>
        /// Scans logs for exceptions and stores them in DB
        /// </summary>
        /// <param name="days">How many days back to scan the logs</param>
        public void Scan(int days)
        {
            DateTime now = DateTime.Now;
            //DateTime lastScan;
            //if (Db.ScanInfos.Any()){
            //    lastScan = Db.ScanInfos.Last().Date;
            //}
            var regex = new Regex(@"\d{4}-\d{2}-\d{2}|\d{8}"); // regex of yyyy-mm-dd and yyyymmdd
            string[] formats = { "yyyy-MM-dd", "yyyyMMdd" };
            foreach (var folder in Directory.EnumerateDirectories(@"C:\testdata\"))
            {
                App app = new(Path.GetFileName(folder));
                App a = Db.AddApp(app);
                var filterValues = GetFilters(a.Name);
                foreach (var file in Directory.EnumerateFiles(folder, "*.log", SearchOption.AllDirectories))
                {
                    int index = 1; //line index
                    string filenameWithoutPath = Path.GetFileName(file); // gets filename with System.IO.Path
                    foreach (Match m in regex.Matches(filenameWithoutPath.ToString()))
                    {
                        if (DateTime.TryParseExact(m.Value, formats, null, DateTimeStyles.None, out DateTime dt)) //parsing regex matches to datetime
                            if (dt.CompareTo(now.AddDays(-days)) > 0)
                            {
                                foreach (string line in File.ReadLines(file)) // iterate and read all lines in file
                                {
                                    if (line.Contains("Exception")) // check each line for "Exception"
                                    {
                                        bool filtered = false;
                                        
                                        if (filterValues.Any())
                                        {
                                            foreach (var filter in filterValues)
                                            {
                                                if (line.Contains(filter.Value)) { filtered = true; }
                                            }

                                        }
                                        if (!filtered)
                                        {
                                        StringBuilder sb = new();
                                        int prelines = 3;
                                        if (index <= 3) {
                                                prelines = index - 1;
                                        }
                                        foreach (string preline in File.ReadLines(file).Skip((index -1) - prelines).Take(prelines)) { // read up to 3 previous lines prior to exception
                                            sb.Append(preline); // save each in stringbuilder
                                        }
                                        Console.WriteLine(index + ": " + line);
                                        db.Model.Exception ex = new(a.AppId, index, line, dt, sb.ToString(), filenameWithoutPath);
                                        Db.AddException(ex);
                                        }
                                    }
                                    index++; // add to index to keep track of line number
                                }
                            }
                    }
                }
            }
            RegisterScan();
        }

        private List<db.Model.Filter> GetFilters(string AppName)
        {
            var filters = Db.Filters.Where(f => f.AppName == AppName).ToList();
            return filters;
        }

        private void RegisterScan()
        {
            var ex = Db.Exceptions;
            var scans = Db.ScanInfos.ToList();
            int exTotal = ex.Count();
            int exSinceLastScan;
            if (scans.Any())
            {
                ScanInfo lastScan = scans.Last();
                exSinceLastScan = exTotal - lastScan.ExTotal;
            }
            else { exSinceLastScan = exTotal; }


            // Performance mæssigt noget lort. Overvej at fjerne
            var exLast24 = 0;
            foreach (var e in ex)
            {
                if (e.Date >= DateTime.Now.AddDays(-1))
                {
                    exLast24++;
                }
            }
            var s = new ScanInfo(DateTime.Now, exLast24, exSinceLastScan, exTotal);
            Db.ScanInfos.Add(s);
            Db.SaveChanges();
        }
    }
}

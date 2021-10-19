
using Scan_console_app.Database;
using Scan_console_app.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scan_console_app
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
            var regex = new Regex(@"\d{4}-\d{2}-\d{2}|\d{8}"); // regex of yyyy-mm-dd and yyyymmdd
            string[] formats = { "yyyy-MM-dd", "yyyyMMdd" };
            foreach (var folder in Directory.EnumerateDirectories(@"C:\testdata\"))
            {
                App app = new(Path.GetFileName(folder));
                App a = Db.AddApp(app);
                foreach (var file in Directory.EnumerateFiles(folder, "*.log", SearchOption.AllDirectories))
                {
                    int index = 0; //line index
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
                                        StringBuilder sb = new();
                                        foreach (string preline in File.ReadLines(file).Skip(index - 3).Take(3)) { // read 3 previous lines prior to exception - can and probably will break if exception is found in the first 3 lines. Need to test and solve.
                                            sb.Append(preline); // save each in stringbuilder
                                        }
                                        Model.Exception ex = new(a.AppId, index, line, dt, sb.ToString(), filenameWithoutPath);
                                        Db.AddException(ex);
                                    }
                                    index++; // add to index to keep track of line number
                                }
                            }
                    }
                }
            }
        }
    }
}

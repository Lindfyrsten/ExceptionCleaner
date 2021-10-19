using Scan_console_app.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan_console_app.Database
{
    class ExContext : System.Data.Entity.DbContext
    {
        public  DbSet<App> Apps { get; set; }
        public  DbSet<Model.Exception> Exceptions { get; set; }

        public ExContext() : base("kristian_test") { }//Database.SetInitializer(new DropCreateDatabaseAlways<DbContext>()); }

        public App AddApp(App a)
        {
            Console.WriteLine("\t" + a.Name);
            foreach (var app in Apps)
            {
                if (app.Name == a.Name)
                {
                    return app;
                }
            }
            Apps.Add(a);
            SaveChanges();
            return a;
        }

        public List<Model.Exception> GetExceptions()
        {
            return Exceptions.ToList();
        }

        public void AddException(Model.Exception e)
        {
            Exceptions.Add(e);
            SaveChanges();
        }

        public List<Model.Exception> GetExceptionsByApp(App a)
        {
            return Exceptions.Where(e => e.AppId == a.AppId).ToList();
        }

        //public List<App> GetApps()
        //{
        //    return Apps.Include("Exceptions").ToList();
        //}

        //public App GetAppByName(string Name)
        //{
        //    return Apps.Where(a => a.Name == Name).Include(x => x.Exceptions).FirstOrDefault();
        //}

        //
        public void ResetDB()
        {
            Console.WriteLine("Resetting DB...");
            Apps.RemoveRange(Apps);
            //Exceptions.RemoveRange(Exceptions);
            SaveChanges();
        }
    }
}

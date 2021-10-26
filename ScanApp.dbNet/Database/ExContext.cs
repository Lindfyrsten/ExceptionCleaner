using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScanApp.db.Model;

namespace ScanApp.db.Database
{
    public class ExContext : DbContext
    {
        public  DbSet<App> Apps { get; set; }
        public  DbSet<Model.Exception> Exceptions { get; set; }
        public DbSet<Filter> Filters { get; set; }

        public DbSet<ScanInfo> ScanInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=yjyw5q13w9.database.windows.net;Database=kristian_test;User ID=ktuser@yjyw5q13w9;Password=!9DghxJ1Fch34tYT6UCbEpIpzmqbDhSO@L23CyQvqBfKPT2ECS;MultipleActiveResultSets=true;");
        }

        public ExContext() { }

        public App AddApp(App a)
        {
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

        public async Task<List<App>> GetAppsAsync()
        {
            var result = await Apps.ToListAsync();
            return result;
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

        public async Task<List<Model.Exception>> GetExceptionsAsync()
        {
            var result = await Exceptions.ToListAsync();
            return result;
        }

        public List<Model.Exception> GetExceptionsByAppId(int appid)
        {
            return Exceptions.Where(e => e.AppId == appid).OrderByDescending(e => e.Date).ToList();
        }

        //public List<Model.Exception> GetExceptionsByAppName(string AppName)
        //{
        //    return Exceptions.Where(e => e.AppId == AppId).ToList();
        //}

        public void ResetDB()
        {
            Console.WriteLine("Resetting DB...");
            Apps.RemoveRange(Apps);
            Exceptions.RemoveRange(Exceptions);
            SaveChanges();
        }
    }
}

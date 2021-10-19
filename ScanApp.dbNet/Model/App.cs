using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScanApp.db.Model
{
    public class App
    {
        [Key]
        public int AppId { get; set; }
        public string Name { get; set; }

        public App(string Name)
        {
            this.Name = Name;
        }
        public App(){

        }
    }

}


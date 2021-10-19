using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scan_console_app.Model
{
    class App
    {
        [Key]
        public int AppId { get; set; }
        public string Name { get; set; }
        //public string Test { get; set; }

        public App(string Name)
        {
            this.Name = Name;
        }
        public App(){

        }
    }

}


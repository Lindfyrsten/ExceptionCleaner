using ScanApp.db.Database;
using ScanAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScanApp.Web.Services
{
    public class FilterService
    {
        public IEnumerable<FilterViewModel> Read()
        {
            return GetAll();
        }

        public IList<FilterViewModel> GetAll()
        {
            using (var db = new ExContext())
            {
                var result = db.Filters.ToList().Select(filter =>
                {
                    return new FilterViewModel
                    {
                        Value = filter.Value,
                        FilterId = filter.FilterId,
                        AppName = filter.AppName
                    };
                }).ToList();
                return result;
            }
        }
    }
}

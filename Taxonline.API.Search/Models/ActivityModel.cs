using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxonline.API.Search.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string Memo { get; set; }
        public string TypeOfActivity { get; set; }
        public int WorkItem { get; set; }
    }
}

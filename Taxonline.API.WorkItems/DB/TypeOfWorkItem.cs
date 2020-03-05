using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxonline.API.WorkItems.DB
{
    public class TypeOfWorkItem
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public List<WorkItem> WorkItems { get; set; }
    }
}

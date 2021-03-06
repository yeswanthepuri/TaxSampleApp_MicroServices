﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.WorkItems.Models.Interfaces;

namespace Taxonline.API.WorkItems.Models
{
    public class WorkItemModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Jurisdiction { get; set; }
        public int MyProperty { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Intrest { get; set; }
        public decimal Discount { get; set; }
        public string TaxTypeID { get; set; }
        public string TypeofWorkItemID { get; set; }
    }
}

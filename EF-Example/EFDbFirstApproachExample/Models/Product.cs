﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models
{
    public class Product
    {   [Key]
        public int ProductID { get; set; }
        public string pershkrim { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
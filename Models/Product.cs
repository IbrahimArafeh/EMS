﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal? Weight { get; set; }
        public int? GategoryId { get; set; }
        public int? StatusId { get; set; }
        public int? InventoryCount { get; set; }

        public virtual Category Gategory { get; set; }
        public virtual Status Status { get; set; }
    }
}
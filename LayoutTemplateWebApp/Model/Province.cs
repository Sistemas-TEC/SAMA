﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public partial class Province
    {
        public Province()
        {
            Canton = new HashSet<Canton>();
            StudentIntegratec = new HashSet<StudentIntegratec>();
        }
        [Key]
        public int provinceId { get; set; }
        public string provinceName { get; set; }

        public virtual ICollection<Canton> Canton { get; set; }
        public virtual ICollection<StudentIntegratec> StudentIntegratec { get; set; }
    }
}
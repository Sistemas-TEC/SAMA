﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class Godchild
    {
        [Key]
        [Column("email")]
        [ForeignKey("StudentIntegratec")]
        public string Email { get; set; }

        [Column("consideration")]
        public string Consideration { get; set; }

        public virtual StudentIntegratec StudentIntegratec { get; set; }
    }
}
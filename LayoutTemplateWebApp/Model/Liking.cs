﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class Liking
    {
        [Key]
        [Column("likingId")]
        public int LikingId { get; set; }

        [Required]
        [Column("likingName")]
        public string LikingName { get; set; }
    }
}
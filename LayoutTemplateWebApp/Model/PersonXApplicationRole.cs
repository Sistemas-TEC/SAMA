﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public partial class PersonXApplicationRole
    {
        [Key]
        public string email { get; set; }
        public int applicationRoleId { get; set; }

        public virtual Person emailNavigation { get; set; }
    }
}
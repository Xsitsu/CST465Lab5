﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CST465Lab5.Models
{
    public class CostumeModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}

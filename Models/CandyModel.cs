using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CST465Lab5.Models
{
    public class CandyModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
    }
}

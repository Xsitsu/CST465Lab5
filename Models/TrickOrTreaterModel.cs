using CST465Lab5.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CST465Lab5.Models
{
    public class TrickOrTreaterModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Favorite Candy")]
        public string FavoriteCandy { get; set; }
        [Required]
        [Display(Name = "Costume")]
        public string Costume { get; set; }

        static public List<string> CandyList()
        {
            return new CandyDBRepository().GetListString();
        }
        static public List<string> CostumeList()
        {
            return new CostumeDBRepository().GetListString();
        }
    }
}

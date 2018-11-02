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
        public string Name { get; set; }
        [Required]
        public string FavoriteCandy { get; set; }
        [Required]
        public string Costume { get; set; }

        static string[] _candyList = new string[]
        {
            "Twix",
            "Starburst",
            "M&M"
        };
        static string[] _costumeList = new string[]
        {
            "Witch",
            "Ghost",
            "Vampire",
            "Zombie"
        };

        static public string[] CandyList
        {
            get
            {
                return _candyList;
            }

        }
        static public string[] CostumeList
        {
            get
            {
                return _costumeList;
            }

        }
    }
}

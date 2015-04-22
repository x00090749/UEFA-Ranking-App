using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UefaServiceV9.Models
{
    public class CountryRanking
    {
        [Required]
        public int Id { get; set; } //team id

        [Required]
        public string CountryName { get; set; } //name
       
        [Required]
        public double Ranking { get; set; } //x.xxx


    }
}
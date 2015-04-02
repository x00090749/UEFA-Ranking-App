using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UefaServiceV4.Models
{
    public class TeamRanking
    {
        [Required]
        public int Id { get; set; } //team id

        [Required]
        public string TeamName { get; set; } //name

        [Required]
        public string CountryCode { get; set; }

        public double Ranking { get; set; } //x.xxx

        //  public string CountryCode { get; set; }

        // Foreign Key
        /* public int CountryId { get; set; }
         public Country Country { get; set; }*/


    }
}
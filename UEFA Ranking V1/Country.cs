using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UEFA_Ranking_V1.Models
{
    public class Country
    {

        private int Id;

        public int ID
        {
            get { return Id; }


            set { Id = value; }
        }


        //[Display(Name = "League: ")]
        public string LeagueName { get; set; }
        //[Display(Name = "Team: ")]
        public int CountryRank { get; set; }
        //[Display(Name = "Club Coefficient: ")]
        public string RoundToEnter { get; set; }
       
       
    }
}
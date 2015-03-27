using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UefaServiceV3.Models
{
    public class Country
    {

        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public int Position { get; set; }

    }
}
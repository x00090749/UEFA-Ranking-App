﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UefaServiceV3.Models
{
    public class Team
    {
        [Required]
        public int Id { get; set; } //team id
        [Required]
        public string TeamName { get; set; } //name
        //  public string CountryCode { get; set; }

        // Foreign Key
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
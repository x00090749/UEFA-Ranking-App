using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace UEFARankingV2.Models
{
    public class Team
    {
        public int TeamId { get; set; } //ContactId
        public string Name { get; set; }
        public string League { get; set; }
        public string Nation { get; set; }
        public double CoEfficient { get; set; }
        public string RoundToEnter { get; set; }
        
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
                    "api/teams/{0}", this.TeamId); // api/teams 
            }
            set { }
        }


    }
}
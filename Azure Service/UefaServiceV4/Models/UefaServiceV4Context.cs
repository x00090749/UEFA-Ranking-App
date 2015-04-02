using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UefaServiceV4.Models
{
    public class UefaServiceV4Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UefaServiceV4Context() : base("name=UefaServiceV4Context")
        {
        }

        public System.Data.Entity.DbSet<UefaServiceV4.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV4.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV4.Models.TeamRanking> TeamRankings { get; set; }
    
    }
}

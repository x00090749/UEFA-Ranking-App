using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UEFA_Ranking_V1.Models
{
    public class UEFA_Ranking_V1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UEFA_Ranking_V1Context() : base("name=UEFA_Ranking_V1Context")
        {
        }

        public System.Data.Entity.DbSet<UEFA_Ranking_V1.Models.Team> Teams { get; set; }
    
    }
}

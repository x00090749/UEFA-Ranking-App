using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UefaServiceV9.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.TeamRanking> TeamRankings { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.RoundOne> RoundOnes { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.RoundTwo> RoundTwoes { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.RoundThreeChampionsRoute> RoundThreeChampionsRoutes { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.RoundThreeLeagueRoute> RoundThreeLeagueRoutes { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.RoundFourLeagueRoute> RoundFourLeagueRoutes { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.GroupStage> GroupStages { get; set; }

        public System.Data.Entity.DbSet<UefaServiceV9.Models.CountryRanking> CountryRankings { get; set; }

       // public System.Data.Entity.DbSet<UefaServiceV9.Models.GroupStage> GroupStages { get; set; }
    }
}
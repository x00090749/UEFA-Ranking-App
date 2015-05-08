using System.Data.Entity;
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false) //throwIfV1Schema :
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        

        public DbSet<TeamRanking> TeamRankings { get; set; }

        public void MarkAsModified(TeamRanking item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<RoundOne> RoundOnes { get; set; }

        public void MarkAsModified(RoundOne item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<RoundTwo> RoundTwoes { get; set; }

        public void MarkAsModified(RoundTwo item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<RoundThreeChampionsRoute> RoundThreeChampionsRoutes { get; set; }

        public void MarkAsModified(RoundThreeChampionsRoute item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<RoundThreeLeagueRoute> RoundThreeLeagueRoutes { get; set; }

        public void MarkAsModified(RoundThreeLeagueRoute item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<RoundFourLeagueRoute> RoundFourLeagueRoutes { get; set; }

        public void MarkAsModified(RoundFourLeagueRoute item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<GroupStage> GroupStages { get; set; }

        public void MarkAsModified(GroupStage item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public DbSet<CountryRanking> CountryRankings { get; set; }

        public void MarkAsModified(CountryRanking item)
        {
            Entry(item).State = EntityState.Modified;
        }

       // public System.Data.Entity.DbSet<UefaServiceV9.Models.GroupStage> GroupStages { get; set; }
    }
}
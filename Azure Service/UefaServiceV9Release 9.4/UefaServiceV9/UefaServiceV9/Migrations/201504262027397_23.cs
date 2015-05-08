namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundFourLeagueRoutes", "TeamName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.RoundFourLeagueRoutes", "CountryCode", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.RoundThreeChampionsRoutes", "TeamName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.RoundThreeChampionsRoutes", "CountryCode", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.RoundFourLeagueRoutes", "TeamRankingId");
            DropColumn("dbo.RoundThreeChampionsRoutes", "TeamRankingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoundThreeChampionsRoutes", "TeamRankingId", c => c.Int(nullable: false));
            AddColumn("dbo.RoundFourLeagueRoutes", "TeamRankingId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoundThreeChampionsRoutes", "CountryCode", c => c.String());
            AlterColumn("dbo.RoundThreeChampionsRoutes", "TeamName", c => c.String());
            AlterColumn("dbo.RoundFourLeagueRoutes", "CountryCode", c => c.String());
            AlterColumn("dbo.RoundFourLeagueRoutes", "TeamName", c => c.String());
        }
    }
}

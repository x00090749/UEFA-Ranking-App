namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundThreeLeagueRoutes", "TeamName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.RoundThreeLeagueRoutes", "CountryCode", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.RoundThreeLeagueRoutes", "TeamRankingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoundThreeLeagueRoutes", "TeamRankingId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoundThreeLeagueRoutes", "CountryCode", c => c.String());
            AlterColumn("dbo.RoundThreeLeagueRoutes", "TeamName", c => c.String());
        }
    }
}

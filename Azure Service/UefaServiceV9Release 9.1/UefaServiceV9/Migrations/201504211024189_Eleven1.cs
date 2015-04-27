namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eleven1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoundThreeChampionsRoutes", "TeamRankingId", "dbo.TeamRankings");
            DropForeignKey("dbo.RoundThreeLeagueRoutes", "TeamRankingId", "dbo.TeamRankings");
            DropIndex("dbo.RoundThreeChampionsRoutes", new[] { "TeamRankingId" });
            DropIndex("dbo.RoundThreeLeagueRoutes", new[] { "TeamRankingId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.RoundThreeLeagueRoutes", "TeamRankingId");
            CreateIndex("dbo.RoundThreeChampionsRoutes", "TeamRankingId");
            AddForeignKey("dbo.RoundThreeLeagueRoutes", "TeamRankingId", "dbo.TeamRankings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoundThreeChampionsRoutes", "TeamRankingId", "dbo.TeamRankings", "Id", cascadeDelete: true);
        }
    }
}

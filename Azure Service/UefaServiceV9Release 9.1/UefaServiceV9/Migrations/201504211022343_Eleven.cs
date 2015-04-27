namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eleven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundThreeLeagueRoutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        CountryCode = c.String(),
                        Ranking = c.Double(nullable: false),
                        TeamRankingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamRankings", t => t.TeamRankingId, cascadeDelete: true)
                .Index(t => t.TeamRankingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundThreeLeagueRoutes", "TeamRankingId", "dbo.TeamRankings");
            DropIndex("dbo.RoundThreeLeagueRoutes", new[] { "TeamRankingId" });
            DropTable("dbo.RoundThreeLeagueRoutes");
        }
    }
}

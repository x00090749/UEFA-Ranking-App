namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tenth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundThreeChampionsRoutes",
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
            DropForeignKey("dbo.RoundThreeChampionsRoutes", "TeamRankingId", "dbo.TeamRankings");
            DropIndex("dbo.RoundThreeChampionsRoutes", new[] { "TeamRankingId" });
            DropTable("dbo.RoundThreeChampionsRoutes");
        }
    }
}

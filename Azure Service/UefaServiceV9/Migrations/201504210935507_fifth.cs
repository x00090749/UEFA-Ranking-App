namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundTwoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        CountryCode = c.String(),
                        TeamRankingId = c.Int(nullable: false),
                        TeamRankingRanking = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamRankings", t => t.TeamRankingId, cascadeDelete: true)
                .Index(t => t.TeamRankingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundTwoes", "TeamRankingId", "dbo.TeamRankings");
            DropIndex("dbo.RoundTwoes", new[] { "TeamRankingId" });
            DropTable("dbo.RoundTwoes");
        }
    }
}

namespace UefaServiceV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundOnes",
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
            DropForeignKey("dbo.RoundOnes", "TeamRankingId", "dbo.TeamRankings");
            DropIndex("dbo.RoundOnes", new[] { "TeamRankingId" });
            DropTable("dbo.RoundOnes");
        }
    }
}

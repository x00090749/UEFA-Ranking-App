namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eight : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoundTwoes", "TeamRankingId", "dbo.TeamRankings");
            DropIndex("dbo.RoundTwoes", new[] { "TeamRankingId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.RoundTwoes", "TeamRankingId");
            AddForeignKey("dbo.RoundTwoes", "TeamRankingId", "dbo.TeamRankings", "Id", cascadeDelete: true);
        }
    }
}

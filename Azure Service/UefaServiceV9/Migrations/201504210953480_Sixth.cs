namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoundTwoes", "TeamRankingRanking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoundTwoes", "TeamRankingRanking", c => c.Int(nullable: false));
        }
    }
}

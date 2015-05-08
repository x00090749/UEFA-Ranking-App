namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundOnes", "TeamName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.RoundTwoes", "TeamName", c => c.String(nullable: false));
            DropColumn("dbo.RoundTwoes", "TeamRankingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoundTwoes", "TeamRankingId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoundTwoes", "TeamName", c => c.String());
            AlterColumn("dbo.RoundOnes", "TeamName", c => c.String(nullable: false, maxLength: 15));
        }
    }
}

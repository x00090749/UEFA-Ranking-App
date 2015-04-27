namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixteen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundOnes", "TeamName", c => c.String(nullable: false));
            AlterColumn("dbo.RoundOnes", "CountryCode", c => c.String(nullable: false));
            DropColumn("dbo.RoundOnes", "TeamRankingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoundOnes", "TeamRankingId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoundOnes", "CountryCode", c => c.String());
            AlterColumn("dbo.RoundOnes", "TeamName", c => c.String());
        }
    }
}

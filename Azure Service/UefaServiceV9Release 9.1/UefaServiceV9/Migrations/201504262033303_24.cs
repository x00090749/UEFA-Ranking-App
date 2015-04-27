namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CountryRankings", "CountryCode", c => c.String());
            AlterColumn("dbo.TeamRankings", "CountryCode", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeamRankings", "CountryCode", c => c.String(nullable: false));
            DropColumn("dbo.CountryRankings", "CountryCode");
        }
    }
}

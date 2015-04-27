namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CountryRankings", "CountryName", c => c.String(nullable: false, maxLength: 35));
            DropColumn("dbo.CountryRankings", "CountryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CountryRankings", "CountryCode", c => c.String());
            AlterColumn("dbo.CountryRankings", "CountryName", c => c.String(nullable: false));
        }
    }
}

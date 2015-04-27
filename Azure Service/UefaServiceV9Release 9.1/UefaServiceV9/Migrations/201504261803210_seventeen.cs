namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventeen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundOnes", "TeamName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.RoundOnes", "CountryCode", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoundOnes", "CountryCode", c => c.String(nullable: false));
            AlterColumn("dbo.RoundOnes", "TeamName", c => c.String(nullable: false));
        }
    }
}

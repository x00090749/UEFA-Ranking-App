namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundOnes", "CountryCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoundOnes", "CountryCode", c => c.String(nullable: false, maxLength: 3));
        }
    }
}

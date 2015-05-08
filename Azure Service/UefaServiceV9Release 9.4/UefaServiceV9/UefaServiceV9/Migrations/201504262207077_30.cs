namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundThreeChampionsRoutes", "TeamName", c => c.String(nullable: false, maxLength: 35));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoundThreeChampionsRoutes", "TeamName", c => c.String(nullable: false, maxLength: 25));
        }
    }
}

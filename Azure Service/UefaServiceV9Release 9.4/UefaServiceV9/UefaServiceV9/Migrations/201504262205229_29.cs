namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundThreeLeagueRoutes", "TeamName", c => c.String(nullable: false, maxLength: 35));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoundThreeLeagueRoutes", "TeamName", c => c.String(nullable: false, maxLength: 25));
        }
    }
}

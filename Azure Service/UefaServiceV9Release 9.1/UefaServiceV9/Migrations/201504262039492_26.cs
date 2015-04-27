namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeamRankings", "TeamName", c => c.String(nullable: false, maxLength: 35));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeamRankings", "TeamName", c => c.String(nullable: false));
        }
    }
}

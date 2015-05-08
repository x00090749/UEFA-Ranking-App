namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GroupStages", "TeamName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.GroupStages", "CountryCode", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.GroupStages", "TeamRankingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupStages", "TeamRankingId", c => c.Int(nullable: false));
            AlterColumn("dbo.GroupStages", "CountryCode", c => c.String());
            AlterColumn("dbo.GroupStages", "TeamName", c => c.String());
        }
    }
}

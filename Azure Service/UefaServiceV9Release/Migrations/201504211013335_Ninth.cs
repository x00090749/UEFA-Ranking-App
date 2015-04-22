namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ninth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoundTwoes", "Ranking", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoundTwoes", "Ranking");
        }
    }
}

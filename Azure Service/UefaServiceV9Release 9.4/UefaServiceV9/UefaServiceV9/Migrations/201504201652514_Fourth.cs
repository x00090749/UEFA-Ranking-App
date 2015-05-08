namespace UefaServiceV9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundOnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        CountryCode = c.String(),
                        Ranking = c.Double(nullable: false),
                        TeamRankingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoundOnes");
        }
    }
}

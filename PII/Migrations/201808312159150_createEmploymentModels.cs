namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEmploymentModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmploymentRanks",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Rank = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NatureOfBusinesses",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Business = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NatureOfBusinesses");
            DropTable("dbo.EmploymentRanks");
        }
    }
}

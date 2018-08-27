namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBarangayModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barangays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityMunicipalityId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Barangays");
        }
    }
}

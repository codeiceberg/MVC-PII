namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreateBarangayModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barangays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityMunicipalityId = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        WebLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Barangays");
        }
    }
}

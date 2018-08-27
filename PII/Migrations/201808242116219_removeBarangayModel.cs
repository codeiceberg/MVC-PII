namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBarangayModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Barangays");
        }
        
        public override void Down()
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
    }
}

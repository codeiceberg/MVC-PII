namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMunicipalityModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CityMunicipalities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CityMunicipalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceId = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        WebLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreateCityMunicipalityModel : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.CityMunicipalities");
        }
    }
}

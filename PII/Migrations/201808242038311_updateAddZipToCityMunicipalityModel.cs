namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddZipToCityMunicipalityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CityMunicipalities", "Zip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CityMunicipalities", "Zip");
        }
    }
}

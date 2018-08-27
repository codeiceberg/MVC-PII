namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddZipToCityMunicipalityModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CityMunicipalities", "WebLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CityMunicipalities", "WebLink");
        }
    }
}

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddressModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "BarangayId", c => c.Int());
            AddColumn("dbo.Addresses", "CityMunicipalityId", c => c.Int());
            AddColumn("dbo.Addresses", "ProvinceId", c => c.Int());
            DropColumn("dbo.Addresses", "Barangay");
            DropColumn("dbo.Addresses", "CityMunicipality");
            DropColumn("dbo.Addresses", "Province");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Province", c => c.String());
            AddColumn("dbo.Addresses", "CityMunicipality", c => c.String());
            AddColumn("dbo.Addresses", "Barangay", c => c.String());
            DropColumn("dbo.Addresses", "ProvinceId");
            DropColumn("dbo.Addresses", "CityMunicipalityId");
            DropColumn("dbo.Addresses", "BarangayId");
        }
    }
}

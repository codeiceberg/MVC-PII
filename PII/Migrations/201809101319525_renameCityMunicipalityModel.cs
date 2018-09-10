namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameCityMunicipalityModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CityMunicipalities", newName: "Cities");
            RenameColumn(table: "dbo.Barangays", name: "CityMunicipalityId", newName: "CityId");
            RenameColumn(table: "dbo.Addresses", name: "CityMunicipalityId", newName: "CityId");
            RenameIndex(table: "dbo.Addresses", name: "IX_CityMunicipalityId", newName: "IX_CityId");
            RenameIndex(table: "dbo.Barangays", name: "IX_CityMunicipalityId", newName: "IX_CityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Barangays", name: "IX_CityId", newName: "IX_CityMunicipalityId");
            RenameIndex(table: "dbo.Addresses", name: "IX_CityId", newName: "IX_CityMunicipalityId");
            RenameColumn(table: "dbo.Addresses", name: "CityId", newName: "CityMunicipalityId");
            RenameColumn(table: "dbo.Barangays", name: "CityId", newName: "CityMunicipalityId");
            RenameTable(name: "dbo.Cities", newName: "CityMunicipalities");
        }
    }
}

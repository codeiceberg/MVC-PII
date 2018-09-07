namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBarangayModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Barangays", "Name", c => c.String(nullable: false, maxLength: 64));
            CreateIndex("dbo.Barangays", "CityMunicipalityId");
            AddForeignKey("dbo.Barangays", "CityMunicipalityId", "dbo.CityMunicipalities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barangays", "CityMunicipalityId", "dbo.CityMunicipalities");
            DropIndex("dbo.Barangays", new[] { "CityMunicipalityId" });
            AlterColumn("dbo.Barangays", "Name", c => c.String(nullable: false));
        }
    }
}

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddressModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "PersonId", c => c.Int());
            AlterColumn("dbo.Addresses", "BarangayId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "CityMunicipalityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "ProvinceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "AddressTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Addresses", "BarangayId");
            CreateIndex("dbo.Addresses", "CityMunicipalityId");
            CreateIndex("dbo.Addresses", "ProvinceId");
            CreateIndex("dbo.Addresses", "PersonId");
            AddForeignKey("dbo.Addresses", "BarangayId", "dbo.Barangays", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Addresses", "CityMunicipalityId", "dbo.CityMunicipalities", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Addresses", "PersonId", "dbo.People", "Id");
            AddForeignKey("dbo.Addresses", "ProvinceId", "dbo.Provinces", "Id", cascadeDelete: false);
            DropColumn("dbo.Addresses", "PersonalInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "PersonalInformationId", c => c.Int());
            DropForeignKey("dbo.Addresses", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Addresses", "PersonId", "dbo.People");
            DropForeignKey("dbo.Addresses", "CityMunicipalityId", "dbo.CityMunicipalities");
            DropForeignKey("dbo.Addresses", "BarangayId", "dbo.Barangays");
            DropIndex("dbo.Addresses", new[] { "PersonId" });
            DropIndex("dbo.Addresses", new[] { "ProvinceId" });
            DropIndex("dbo.Addresses", new[] { "CityMunicipalityId" });
            DropIndex("dbo.Addresses", new[] { "BarangayId" });
            AlterColumn("dbo.Addresses", "AddressTypeId", c => c.Byte());
            AlterColumn("dbo.Addresses", "ProvinceId", c => c.Int());
            AlterColumn("dbo.Addresses", "CityMunicipalityId", c => c.Int());
            AlterColumn("dbo.Addresses", "BarangayId", c => c.Int());
            DropColumn("dbo.Addresses", "PersonId");
        }
    }
}

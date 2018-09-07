namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProvinceModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CityMunicipalities", "Name", c => c.String(nullable: false, maxLength: 64));
            CreateIndex("dbo.CityMunicipalities", "ProvinceId");
            AddForeignKey("dbo.CityMunicipalities", "ProvinceId", "dbo.Provinces", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityMunicipalities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.CityMunicipalities", new[] { "ProvinceId" });
            AlterColumn("dbo.CityMunicipalities", "Name", c => c.String(nullable: false));
        }
    }
}

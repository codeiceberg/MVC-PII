namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addAddressModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseBlockLotNo = c.String(),
                        Street = c.String(),
                        SubdivisionVillage = c.String(),
                        Barangay = c.String(),
                        CityMunicipality = c.String(),
                        Province = c.String(),
                        Zip = c.Int(),
                    })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}

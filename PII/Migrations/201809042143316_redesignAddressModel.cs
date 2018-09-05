namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redesignAddressModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "AddressType", c => c.Byte());
            AddColumn("dbo.Addresses", "PersonalInformationId", c => c.Int());
            DropColumn("dbo.PersonalInformations", "ResidentialAddressId");
            DropColumn("dbo.PersonalInformations", "PermanentAddressId");
            DropColumn("dbo.PersonalInformations", "BusinessAddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalInformations", "BusinessAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.PersonalInformations", "PermanentAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.PersonalInformations", "ResidentialAddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "PersonalInformationId");
            DropColumn("dbo.Addresses", "AddressType");
        }
    }
}

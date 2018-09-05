namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddressModelTypeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "AddressTypeId", c => c.Byte());
            DropColumn("dbo.Addresses", "AddressType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "AddressType", c => c.Byte());
            DropColumn("dbo.Addresses", "AddressTypeId");
        }
    }
}

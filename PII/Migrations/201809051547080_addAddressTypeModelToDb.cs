namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressTypeModelToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddressTypes");
        }
    }
}

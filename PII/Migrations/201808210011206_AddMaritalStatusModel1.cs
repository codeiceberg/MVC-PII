namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaritalStatusModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MaritalStatus");
        }
    }
}

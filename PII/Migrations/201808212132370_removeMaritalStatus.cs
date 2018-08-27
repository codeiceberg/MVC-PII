namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMaritalStatus : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.MaritalStatus");
        }
        
        public override void Down()
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
    }
}

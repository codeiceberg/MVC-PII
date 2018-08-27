namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCivilStatusFieldType4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CivilStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CivilStatus");
        }
    }
}

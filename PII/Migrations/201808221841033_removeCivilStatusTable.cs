namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCivilStatusTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CivilStatus");
        }
        
        public override void Down()
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
    }
}

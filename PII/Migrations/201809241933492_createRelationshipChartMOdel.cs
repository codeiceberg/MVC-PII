namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createRelationshipChartMOdel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RelationshipChart",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Relationship = c.String(nullable: false, maxLength: 32),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RelationshipChart");
        }
    }
}

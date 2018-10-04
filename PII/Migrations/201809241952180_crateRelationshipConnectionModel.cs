namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crateRelationshipConnectionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RelationshipConnections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        RelationshipId = c.Byte(nullable: false),
                        PersonRelatedToId = c.Int(nullable: false),
                        Person1_Id = c.Int(),
                        RelationshipChart_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person1_Id)
                .ForeignKey("dbo.RelationshipCharts", t => t.RelationshipChart_Id)
                .Index(t => t.PersonId)
                .Index(t => t.Person1_Id)
                .Index(t => t.RelationshipChart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelationshipConnections", "RelationshipChart_Id", "dbo.RelationshipCharts");
            DropForeignKey("dbo.RelationshipConnections", "Person1_Id", "dbo.People");
            DropForeignKey("dbo.RelationshipConnections", "PersonId", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "RelationshipChart_Id" });
            DropIndex("dbo.RelationshipConnections", new[] { "Person1_Id" });
            DropIndex("dbo.RelationshipConnections", new[] { "PersonId" });
            DropTable("dbo.RelationshipConnections");
        }
    }
}

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reCreateRelationshipConnectionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RelationshipConnections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person_Id = c.Int(),
                        PersonRelatedTo_Id = c.Int(),
                        Relationship_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.People", t => t.PersonRelatedTo_Id)
                .ForeignKey("dbo.RelationshipCharts", t => t.Relationship_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.PersonRelatedTo_Id)
                .Index(t => t.Relationship_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelationshipConnections", "Relationship_Id", "dbo.RelationshipCharts");
            DropForeignKey("dbo.RelationshipConnections", "PersonRelatedTo_Id", "dbo.People");
            DropForeignKey("dbo.RelationshipConnections", "Person_Id", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "Relationship_Id" });
            DropIndex("dbo.RelationshipConnections", new[] { "PersonRelatedTo_Id" });
            DropIndex("dbo.RelationshipConnections", new[] { "Person_Id" });
            DropTable("dbo.RelationshipConnections");
        }
    }
}

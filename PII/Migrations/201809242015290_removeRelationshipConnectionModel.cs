namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRelationshipConnectionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelationshipConnections", "Person_Id", "dbo.People");
            DropForeignKey("dbo.RelationshipConnections", "PersonRelatedTo_Id", "dbo.People");
            DropForeignKey("dbo.RelationshipConnections", "Relationship_Id", "dbo.RelationshipCharts");
            DropIndex("dbo.RelationshipConnections", new[] { "Person_Id" });
            DropIndex("dbo.RelationshipConnections", new[] { "PersonRelatedTo_Id" });
            DropIndex("dbo.RelationshipConnections", new[] { "Relationship_Id" });
            DropTable("dbo.RelationshipConnections");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RelationshipConnections", "Relationship_Id");
            CreateIndex("dbo.RelationshipConnections", "PersonRelatedTo_Id");
            CreateIndex("dbo.RelationshipConnections", "Person_Id");
            AddForeignKey("dbo.RelationshipConnections", "Relationship_Id", "dbo.RelationshipCharts", "Id");
            AddForeignKey("dbo.RelationshipConnections", "PersonRelatedTo_Id", "dbo.People", "Id");
            AddForeignKey("dbo.RelationshipConnections", "Person_Id", "dbo.People", "Id");
        }
    }
}

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRelationshipConnectionModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelationshipConnections", "PersonId", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "PersonId" });
            RenameColumn(table: "dbo.RelationshipConnections", name: "PersonId", newName: "PersonId_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "PersonRelatedToId_Id", newName: "PersonRelatedTo_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "RelationshipChart_Id", newName: "Relationship_Id");
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_PersonRelatedToId_Id", newName: "IX_PersonRelatedTo_Id");
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_RelationshipChart_Id", newName: "IX_Relationship_Id");
            AlterColumn("dbo.RelationshipConnections", "PersonId_Id", c => c.Int());
            CreateIndex("dbo.RelationshipConnections", "PersonId_Id");
            AddForeignKey("dbo.RelationshipConnections", "PersonId_Id", "dbo.People", "Id");
            DropColumn("dbo.RelationshipConnections", "RelationshipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RelationshipConnections", "RelationshipId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.RelationshipConnections", "PersonId_Id", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "PersonId_Id" });
            AlterColumn("dbo.RelationshipConnections", "PersonId_Id", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_Relationship_Id", newName: "IX_RelationshipChart_Id");
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_PersonRelatedTo_Id", newName: "IX_PersonRelatedToId_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "Relationship_Id", newName: "RelationshipChart_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "PersonRelatedTo_Id", newName: "PersonRelatedToId_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "PersonId_Id", newName: "PersonId");
            CreateIndex("dbo.RelationshipConnections", "PersonId");
            AddForeignKey("dbo.RelationshipConnections", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}

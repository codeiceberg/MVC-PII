namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reCreateRelationshipConnectionModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelationshipConnections", "Person2_Id", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "Person2_Id" });
            RenameColumn(table: "dbo.RelationshipConnections", name: "Person2_Id", newName: "Person2Id");
            AlterColumn("dbo.RelationshipConnections", "Person2Id", c => c.Int(nullable: false));
            CreateIndex("dbo.RelationshipConnections", "Person2Id");
            AddForeignKey("dbo.RelationshipConnections", "Person2Id", "dbo.People", "Id", cascadeDelete: false);
            DropColumn("dbo.RelationshipConnections", "PersonRelatedToId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RelationshipConnections", "PersonRelatedToId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RelationshipConnections", "Person2Id", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "Person2Id" });
            AlterColumn("dbo.RelationshipConnections", "Person2Id", c => c.Int());
            RenameColumn(table: "dbo.RelationshipConnections", name: "Person2Id", newName: "Person2_Id");
            CreateIndex("dbo.RelationshipConnections", "Person2_Id");
            AddForeignKey("dbo.RelationshipConnections", "Person2_Id", "dbo.People", "Id");
        }
    }
}

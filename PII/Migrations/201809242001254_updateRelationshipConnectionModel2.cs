namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRelationshipConnectionModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RelationshipConnections", "PersonRelatedToId_Id", c => c.Int());
            CreateIndex("dbo.RelationshipConnections", "PersonRelatedToId_Id");
            AddForeignKey("dbo.RelationshipConnections", "PersonRelatedToId_Id", "dbo.People", "Id");
            DropColumn("dbo.RelationshipConnections", "PersonRelatedToId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RelationshipConnections", "PersonRelatedToId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RelationshipConnections", "PersonRelatedToId_Id", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "PersonRelatedToId_Id" });
            DropColumn("dbo.RelationshipConnections", "PersonRelatedToId_Id");
        }
    }
}

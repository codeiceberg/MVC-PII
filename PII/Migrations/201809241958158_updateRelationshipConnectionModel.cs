namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRelationshipConnectionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelationshipConnections", "Person1_Id", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "Person1_Id" });
            DropColumn("dbo.RelationshipConnections", "Person1_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RelationshipConnections", "Person1_Id", c => c.Int());
            CreateIndex("dbo.RelationshipConnections", "Person1_Id");
            AddForeignKey("dbo.RelationshipConnections", "Person1_Id", "dbo.People", "Id");
        }
    }
}

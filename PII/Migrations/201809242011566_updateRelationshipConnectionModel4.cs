namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRelationshipConnectionModel4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RelationshipConnections", name: "PersonId_Id", newName: "Person_Id");
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_PersonId_Id", newName: "IX_Person_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_Person_Id", newName: "IX_PersonId_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "Person_Id", newName: "PersonId_Id");
        }
    }
}

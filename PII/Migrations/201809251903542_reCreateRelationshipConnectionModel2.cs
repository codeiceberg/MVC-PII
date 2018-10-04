namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reCreateRelationshipConnectionModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelationshipConnections", "Person_Id", "dbo.People");
            DropForeignKey("dbo.RelationshipConnections", "Relationship_Id", "dbo.RelationshipCharts");
            DropIndex("dbo.RelationshipConnections", new[] { "Person_Id" });
            DropIndex("dbo.RelationshipConnections", new[] { "Relationship_Id" });
            RenameColumn(table: "dbo.RelationshipConnections", name: "Person_Id", newName: "PersonId");
            RenameColumn(table: "dbo.RelationshipConnections", name: "PersonRelatedTo_Id", newName: "Person2_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "Relationship_Id", newName: "RelationshipChartId");
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_PersonRelatedTo_Id", newName: "IX_Person2_Id");
            AddColumn("dbo.RelationshipConnections", "PersonRelatedToId", c => c.Int(nullable: false));
            AlterColumn("dbo.RelationshipConnections", "PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.RelationshipConnections", "RelationshipChartId", c => c.Byte(nullable: false));
            CreateIndex("dbo.RelationshipConnections", "PersonId");
            CreateIndex("dbo.RelationshipConnections", "RelationshipChartId");
            AddForeignKey("dbo.RelationshipConnections", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RelationshipConnections", "RelationshipChartId", "dbo.RelationshipCharts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelationshipConnections", "RelationshipChartId", "dbo.RelationshipCharts");
            DropForeignKey("dbo.RelationshipConnections", "PersonId", "dbo.People");
            DropIndex("dbo.RelationshipConnections", new[] { "RelationshipChartId" });
            DropIndex("dbo.RelationshipConnections", new[] { "PersonId" });
            AlterColumn("dbo.RelationshipConnections", "RelationshipChartId", c => c.Byte());
            AlterColumn("dbo.RelationshipConnections", "PersonId", c => c.Int());
            DropColumn("dbo.RelationshipConnections", "PersonRelatedToId");
            RenameIndex(table: "dbo.RelationshipConnections", name: "IX_Person2_Id", newName: "IX_PersonRelatedTo_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "RelationshipChartId", newName: "Relationship_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "Person2_Id", newName: "PersonRelatedTo_Id");
            RenameColumn(table: "dbo.RelationshipConnections", name: "PersonId", newName: "Person_Id");
            CreateIndex("dbo.RelationshipConnections", "Relationship_Id");
            CreateIndex("dbo.RelationshipConnections", "Person_Id");
            AddForeignKey("dbo.RelationshipConnections", "Relationship_Id", "dbo.RelationshipCharts", "Id");
            AddForeignKey("dbo.RelationshipConnections", "Person_Id", "dbo.People", "Id");
        }
    }
}

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePersonModelFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "FirstName", c => c.String());
            DropColumn("dbo.People", "FistName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "FistName", c => c.String());
            DropColumn("dbo.People", "FirstName");
        }
    }
}

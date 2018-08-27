namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCivilStatusFieldType5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalInformations", "CivilStatus", c => c.String());
            DropColumn("dbo.PersonalInformations", "CivilStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalInformations", "CivilStatusId", c => c.Byte(nullable: false));
            DropColumn("dbo.PersonalInformations", "CivilStatus");
        }
    }
}

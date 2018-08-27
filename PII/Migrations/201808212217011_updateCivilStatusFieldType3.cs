namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCivilStatusFieldType3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalInformations", "CivilStatusId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalInformations", "CivilStatusId", c => c.Byte());
        }
    }
}

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCivilStatusFieldType2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalInformations", "CivilStatusId", c => c.Byte());
            DropColumn("dbo.PersonalInformations", "CivilStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalInformations", "CivilStatus", c => c.Byte());
            DropColumn("dbo.PersonalInformations", "CivilStatusId");
        }
    }
}

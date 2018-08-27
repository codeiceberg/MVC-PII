namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCivilStatusFieldType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalInformations", "PlateOfBirthAddressId", c => c.Int());
            AlterColumn("dbo.PersonalInformations", "CivilStatus", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalInformations", "CivilStatus", c => c.String());
            AlterColumn("dbo.PersonalInformations", "PlateOfBirthAddressId", c => c.Int(nullable: false));
        }
    }
}

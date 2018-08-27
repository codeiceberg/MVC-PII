namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createPersonalInformationClass1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Title = c.String(),
                        LastName = c.String(),
                        FistName = c.String(),
                        MiddleName = c.String(),
                        NameExtension = c.String(),
                        DateOfBirth = c.DateTime(),
                        PlateOfBirthAddressId = c.Int(nullable: false),
                        Gender = c.String(),
                        CivilStatus = c.String(),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        BloodType = c.String(),
                        GsisNo = c.String(),
                        PagibigNo = c.String(),
                        PhilhealthNo = c.String(),
                        SssNo = c.String(),
                        TinNo = c.String(),
                        AgencyEmployeeNo = c.String(),
                        Citizenship = c.String(),
                        ResidentialAddressId = c.Int(nullable: false),
                        PermanentAddressId = c.Int(nullable: false),
                        BusinessAddressId = c.Int(nullable: false),
                        TelephoneNo = c.Int(nullable: false),
                        MobileNo = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        ParentId = c.Int(nullable: false),
                        WhoChange = c.String(),
                        WhenChange = c.DateTime(),
                        WhoAdd = c.String(),
                        WhenAdd = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonalInformations");
        }
    }
}

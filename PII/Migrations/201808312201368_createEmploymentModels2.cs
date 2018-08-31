namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEmploymentModels2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmploymentInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentType = c.String(),
                        Otheres = c.String(),
                        YearsWithPrecentEmployer = c.Short(),
                        PositionId = c.Short(),
                        NatureOfBusinessId = c.Short(),
                        WorkTenureYears = c.Short(),
                        WorkTenureMonths = c.Short(),
                        NameOfBusiness = c.String(),
                        PhoneNo = c.String(),
                        FaxNo = c.String(),
                        EmailAddress = c.String(),
                        GrossAnnualIncome = c.Int(),
                        AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmploymentInformations");
        }
    }
}

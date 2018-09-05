using System.Web.UI.WebControls;

namespace PII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateAddressType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into AddressTypes(Id,Type) values (1,'Residential')");
            Sql("Insert into AddressTypes(Id,Type) values (2,'Permanent')");
            Sql("Insert into AddressTypes(Id,Type) values (3,'Business')");
        }
        
        public override void Down()
        {
        }
    }
}

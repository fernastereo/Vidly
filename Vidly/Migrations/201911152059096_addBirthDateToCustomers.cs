namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthDateToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "birthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "birthDate");
        }
    }
}

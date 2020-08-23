namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAvailableToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "numberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Movies set numberAvailable=stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "numberAvailable");
        }
    }
}

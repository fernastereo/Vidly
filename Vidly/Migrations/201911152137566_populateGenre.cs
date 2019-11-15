namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres (name) values ('Comedy')");
            Sql("insert into genres (name) values ('Plomo')");
            Sql("insert into genres (name) values ('Family')");
            Sql("insert into genres (name) values ('Romance')");
            Sql("insert into genres (name) values ('Scyfi')");
        }
        
        public override void Down()
        {
        }
    }
}

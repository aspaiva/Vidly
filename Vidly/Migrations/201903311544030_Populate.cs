namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate : DbMigration
    {
        public override void Up()
        {
            Sql("insert membershiptypes(id, signupfee, durationinmonths, discountrate, name) values (1,0,0,0,'Normal')");
            Sql("insert membershiptypes(id, signupfee, durationinmonths, discountrate, name) values (3,90,3,15,'Quarterly')");
            Sql("insert membershiptypes(id, signupfee, durationinmonths, discountrate, name) values (4,300,12,20,'Annualy')");
            Sql("insert membershiptypes(id, signupfee, durationinmonths, discountrate, name) values (2,30,1,10,'Monthly')");

            Sql("INSERT Genres Values ('Comedy')");
            Sql("INSERT Genres Values ('SciFi')");
            Sql("INSERT Genres Values ('Adventure')");
            Sql("INSERT Genres Values ('Romantic')");
            Sql("INSERT Genres Values ('Police')");
            Sql("INSERT Genres Values ('Drama')");
            Sql("INSERT Genres Values ('Documentary')");


            Sql("insert MediaTypes values ('Film')");
            Sql("insert MediaTypes values ('Animation')");
            Sql("insert MediaTypes values ('Stop motion')");
            Sql("insert MediaTypes values ('Manga')");
            Sql("insert MediaTypes values ('Digital')");

        }
        
        public override void Down()
        {
        }
    }
}

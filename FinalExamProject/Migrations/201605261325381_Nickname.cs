namespace FinalExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nickname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nickname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nickname");
        }
    }
}

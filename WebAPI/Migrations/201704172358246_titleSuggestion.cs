namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titleSuggestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sugerences", "titulo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sugerences", "titulo");
        }
    }
}

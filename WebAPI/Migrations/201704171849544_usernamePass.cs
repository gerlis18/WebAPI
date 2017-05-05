namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernamePass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "username", c => c.String());
            AddColumn("dbo.Users", "password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "password");
            DropColumn("dbo.Users", "username");
        }
    }
}

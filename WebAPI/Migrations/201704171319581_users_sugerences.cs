namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users_sugerences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSugerences",
                c => new
                    {
                        UserSugerenceId = c.Int(nullable: false),
                        UserEId = c.Int(nullable: false),
                        UserRId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserSugerenceId, t.UserEId, t.UserRId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSugerences");
        }
    }
}

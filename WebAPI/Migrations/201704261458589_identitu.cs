namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identitu : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SugerencesPosts");
            AlterColumn("dbo.SugerencesPosts", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SugerencesPosts", new[] { "id", "CategoriaId", "SugerenceId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SugerencesPosts");
            AlterColumn("dbo.SugerencesPosts", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SugerencesPosts", new[] { "id", "CategoriaId", "SugerenceId", "UserId" });
        }
    }
}

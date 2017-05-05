namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTBs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        categoria = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SugerencesPosts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        SugerenceId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id, t.CategoriaId, t.SugerenceId, t.UserId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SugerencesPosts");
            DropTable("dbo.Categorias");
        }
    }
}

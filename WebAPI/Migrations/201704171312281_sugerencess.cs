namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sugerencess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sugerences",
                c => new
                    {
                        SugerenceId = c.Int(nullable: false, identity: true),
                        mensaje = c.String(),
                        creacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SugerenceId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Rol = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Sugerences");
        }
    }
}

namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        conteudo = c.String(),
                        criado = c.DateTime(nullable: false),
                        UsuarioId = c.Int(),
                        categoria_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.categoria_id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.categoria_id);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        texto = c.String(),
                        criado = c.DateTime(nullable: false),
                        post_id = c.Int(),
                        usuario_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.post_id)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id)
                .Index(t => t.post_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        login = c.String(nullable: false),
                        senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "categoria_id", "dbo.Categorias");
            DropIndex("dbo.Comentarios", new[] { "usuario_id" });
            DropIndex("dbo.Comentarios", new[] { "post_id" });
            DropIndex("dbo.Posts", new[] { "categoria_id" });
            DropIndex("dbo.Posts", new[] { "UsuarioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Comentarios");
            DropTable("dbo.Posts");
            DropTable("dbo.Categorias");
        }
    }
}

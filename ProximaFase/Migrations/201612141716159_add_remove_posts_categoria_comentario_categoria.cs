namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_remove_posts_categoria_comentario_categoria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "categoria_id", "dbo.Categorias");
            DropForeignKey("dbo.Comentarios", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Comentarios", "usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Posts", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Posts", new[] { "UsuarioId" });
            DropIndex("dbo.Posts", new[] { "categoria_id" });
            DropIndex("dbo.Comentarios", new[] { "post_id" });
            DropIndex("dbo.Comentarios", new[] { "usuario_id" });
            DropTable("dbo.Categorias");
            DropTable("dbo.Posts");
            DropTable("dbo.Comentarios");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Comentarios", "usuario_id");
            CreateIndex("dbo.Comentarios", "post_id");
            CreateIndex("dbo.Posts", "categoria_id");
            CreateIndex("dbo.Posts", "UsuarioId");
            AddForeignKey("dbo.Posts", "UsuarioId", "dbo.Usuarios", "id");
            AddForeignKey("dbo.Comentarios", "usuario_id", "dbo.Usuarios", "id");
            AddForeignKey("dbo.Comentarios", "post_id", "dbo.Posts", "id");
            AddForeignKey("dbo.Posts", "categoria_id", "dbo.Categorias", "id");
        }
    }
}

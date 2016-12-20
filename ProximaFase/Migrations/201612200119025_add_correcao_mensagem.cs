namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_mensagem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensagems", "DeUsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Mensagems", new[] { "DeUsuarioID" });
            AlterColumn("dbo.Mensagems", "DeUsuarioID", c => c.Int(nullable: false));
            CreateIndex("dbo.Mensagems", "DeUsuarioID");
            AddForeignKey("dbo.Mensagems", "DeUsuarioID", "dbo.Usuarios", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensagems", "DeUsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Mensagems", new[] { "DeUsuarioID" });
            AlterColumn("dbo.Mensagems", "DeUsuarioID", c => c.Int());
            CreateIndex("dbo.Mensagems", "DeUsuarioID");
            AddForeignKey("dbo.Mensagems", "DeUsuarioID", "dbo.Usuarios", "id");
        }
    }
}

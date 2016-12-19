namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_usuario1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JogoDesejadoes", "usuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.JogoPossuidoes", "usuarioID", "dbo.Usuarios");
            DropIndex("dbo.JogoDesejadoes", new[] { "usuarioID" });
            DropIndex("dbo.JogoPossuidoes", new[] { "usuarioID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.JogoPossuidoes", "usuarioID");
            CreateIndex("dbo.JogoDesejadoes", "usuarioID");
            AddForeignKey("dbo.JogoPossuidoes", "usuarioID", "dbo.Usuarios", "id", cascadeDelete: true);
            AddForeignKey("dbo.JogoDesejadoes", "usuarioID", "dbo.Usuarios", "id", cascadeDelete: true);
        }
    }
}

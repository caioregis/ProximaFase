namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_combinacao_jogodesejado_jogopossuido : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.JogoPossuidoes", new[] { "combinacao_CombinacaoID" });
            AddColumn("dbo.Combinacaos", "Usuario_id", c => c.Int());
            CreateIndex("dbo.Combinacaos", "Usuario_id");
            CreateIndex("dbo.JogoPossuidoes", "usuarioID");
            CreateIndex("dbo.JogoPossuidoes", "Combinacao_CombinacaoID");
            CreateIndex("dbo.JogoDesejadoes", "usuarioID");
            AddForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios", "id");
            AddForeignKey("dbo.JogoPossuidoes", "usuarioID", "dbo.Usuarios", "id", cascadeDelete: true);
            AddForeignKey("dbo.JogoDesejadoes", "usuarioID", "dbo.Usuarios", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JogoDesejadoes", "usuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.JogoPossuidoes", "usuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios");
            DropIndex("dbo.JogoDesejadoes", new[] { "usuarioID" });
            DropIndex("dbo.JogoPossuidoes", new[] { "Combinacao_CombinacaoID" });
            DropIndex("dbo.JogoPossuidoes", new[] { "usuarioID" });
            DropIndex("dbo.Combinacaos", new[] { "Usuario_id" });
            DropColumn("dbo.Combinacaos", "Usuario_id");
            CreateIndex("dbo.JogoPossuidoes", "combinacao_CombinacaoID");
        }
    }
}

namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_combinacao1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.ConsoleGameUsuarios", "ConsoleGame_ConsoleGameID", "dbo.ConsoleGames");
            DropForeignKey("dbo.ConsoleGameUsuarios", "Usuario_id", "dbo.Usuarios");
            DropIndex("dbo.Combinacaos", new[] { "Usuario_id" });
            DropIndex("dbo.ConsoleGameUsuarios", new[] { "ConsoleGame_ConsoleGameID" });
            DropIndex("dbo.ConsoleGameUsuarios", new[] { "Usuario_id" });
            AddColumn("dbo.Combinacaos", "Combinacao_CombinacaoID", c => c.Int());
            AddColumn("dbo.Usuarios", "Combinacao_CombinacaoID", c => c.Int());
            AddColumn("dbo.ConsoleGames", "Usuario_id", c => c.Int());
            CreateIndex("dbo.Combinacaos", "Combinacao_CombinacaoID");
            CreateIndex("dbo.Usuarios", "Combinacao_CombinacaoID");
            CreateIndex("dbo.ConsoleGames", "Usuario_id");
            AddForeignKey("dbo.Combinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos", "CombinacaoID");
            AddForeignKey("dbo.ConsoleGames", "Usuario_id", "dbo.Usuarios", "id");
            AddForeignKey("dbo.Usuarios", "Combinacao_CombinacaoID", "dbo.Combinacaos", "CombinacaoID");
            DropColumn("dbo.Combinacaos", "Usuario_id");
            DropTable("dbo.ConsoleGameUsuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConsoleGameUsuarios",
                c => new
                    {
                        ConsoleGame_ConsoleGameID = c.Int(nullable: false),
                        Usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsoleGame_ConsoleGameID, t.Usuario_id });
            
            AddColumn("dbo.Combinacaos", "Usuario_id", c => c.Int());
            DropForeignKey("dbo.Usuarios", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropForeignKey("dbo.ConsoleGames", "Usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Combinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropIndex("dbo.ConsoleGames", new[] { "Usuario_id" });
            DropIndex("dbo.Usuarios", new[] { "Combinacao_CombinacaoID" });
            DropIndex("dbo.Combinacaos", new[] { "Combinacao_CombinacaoID" });
            DropColumn("dbo.ConsoleGames", "Usuario_id");
            DropColumn("dbo.Usuarios", "Combinacao_CombinacaoID");
            DropColumn("dbo.Combinacaos", "Combinacao_CombinacaoID");
            CreateIndex("dbo.ConsoleGameUsuarios", "Usuario_id");
            CreateIndex("dbo.ConsoleGameUsuarios", "ConsoleGame_ConsoleGameID");
            CreateIndex("dbo.Combinacaos", "Usuario_id");
            AddForeignKey("dbo.ConsoleGameUsuarios", "Usuario_id", "dbo.Usuarios", "id", cascadeDelete: true);
            AddForeignKey("dbo.ConsoleGameUsuarios", "ConsoleGame_ConsoleGameID", "dbo.ConsoleGames", "ConsoleGameID", cascadeDelete: true);
            AddForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios", "id");
        }
    }
}

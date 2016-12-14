namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_combinacao_mensagens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Combinacaos",
                c => new
                    {
                        CombinacaoID = c.Int(nullable: false, identity: true),
                        ValorCombinacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CombinacaoID);
            
            CreateTable(
                "dbo.Mensagems",
                c => new
                    {
                        MensagemID = c.Int(nullable: false, identity: true),
                        CombinacaoID = c.Int(nullable: false),
                        DeUsuarioID = c.Int(nullable: false),
                        MensagemText = c.String(),
                        DataHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MensagemID)
                .ForeignKey("dbo.Combinacaos", t => t.CombinacaoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.DeUsuarioID, cascadeDelete: true)
                .Index(t => t.CombinacaoID)
                .Index(t => t.DeUsuarioID);
            
            CreateTable(
                "dbo.CombinacaoUsuarios",
                c => new
                    {
                        Combinacao_CombinacaoID = c.Int(nullable: false),
                        Usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Combinacao_CombinacaoID, t.Usuario_id })
                .ForeignKey("dbo.Combinacaos", t => t.Combinacao_CombinacaoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_id, cascadeDelete: true)
                .Index(t => t.Combinacao_CombinacaoID)
                .Index(t => t.Usuario_id);
            
            AddColumn("dbo.JogoPossuidoes", "Combinacao_CombinacaoID", c => c.Int());
            CreateIndex("dbo.JogoPossuidoes", "Combinacao_CombinacaoID");
            AddForeignKey("dbo.JogoPossuidoes", "Combinacao_CombinacaoID", "dbo.Combinacaos", "CombinacaoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CombinacaoUsuarios", "Usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.CombinacaoUsuarios", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropForeignKey("dbo.Mensagems", "DeUsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Mensagems", "CombinacaoID", "dbo.Combinacaos");
            DropForeignKey("dbo.JogoPossuidoes", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropIndex("dbo.CombinacaoUsuarios", new[] { "Usuario_id" });
            DropIndex("dbo.CombinacaoUsuarios", new[] { "Combinacao_CombinacaoID" });
            DropIndex("dbo.Mensagems", new[] { "DeUsuarioID" });
            DropIndex("dbo.Mensagems", new[] { "CombinacaoID" });
            DropIndex("dbo.JogoPossuidoes", new[] { "Combinacao_CombinacaoID" });
            DropColumn("dbo.JogoPossuidoes", "Combinacao_CombinacaoID");
            DropTable("dbo.CombinacaoUsuarios");
            DropTable("dbo.Mensagems");
            DropTable("dbo.Combinacaos");
        }
    }
}

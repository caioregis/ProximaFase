namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_combinacao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioCombinacaos", "Usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioCombinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropIndex("dbo.UsuarioCombinacaos", new[] { "Usuario_id" });
            DropIndex("dbo.UsuarioCombinacaos", new[] { "Combinacao_CombinacaoID" });
            AddColumn("dbo.Combinacaos", "Usuario_id", c => c.Int());
            CreateIndex("dbo.Combinacaos", "Usuario_id");
            AddForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios", "id");
            DropTable("dbo.UsuarioCombinacaos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuarioCombinacaos",
                c => new
                    {
                        Usuario_id = c.Int(nullable: false),
                        Combinacao_CombinacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_id, t.Combinacao_CombinacaoID });
            
            DropForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios");
            DropIndex("dbo.Combinacaos", new[] { "Usuario_id" });
            DropColumn("dbo.Combinacaos", "Usuario_id");
            CreateIndex("dbo.UsuarioCombinacaos", "Combinacao_CombinacaoID");
            CreateIndex("dbo.UsuarioCombinacaos", "Usuario_id");
            AddForeignKey("dbo.UsuarioCombinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos", "CombinacaoID", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioCombinacaos", "Usuario_id", "dbo.Usuarios", "id", cascadeDelete: true);
        }
    }
}

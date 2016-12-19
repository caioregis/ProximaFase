namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_combinacao4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios");
            DropIndex("dbo.Combinacaos", new[] { "Usuario_id" });
            CreateTable(
                "dbo.UsuarioCombinacaos",
                c => new
                    {
                        Usuario_id = c.Int(nullable: false),
                        Combinacao_CombinacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_id, t.Combinacao_CombinacaoID })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_id, cascadeDelete: true)
                .ForeignKey("dbo.Combinacaos", t => t.Combinacao_CombinacaoID, cascadeDelete: true)
                .Index(t => t.Usuario_id)
                .Index(t => t.Combinacao_CombinacaoID);
            
            DropColumn("dbo.Combinacaos", "Usuario_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Combinacaos", "Usuario_id", c => c.Int());
            DropForeignKey("dbo.UsuarioCombinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropForeignKey("dbo.UsuarioCombinacaos", "Usuario_id", "dbo.Usuarios");
            DropIndex("dbo.UsuarioCombinacaos", new[] { "Combinacao_CombinacaoID" });
            DropIndex("dbo.UsuarioCombinacaos", new[] { "Usuario_id" });
            DropTable("dbo.UsuarioCombinacaos");
            CreateIndex("dbo.Combinacaos", "Usuario_id");
            AddForeignKey("dbo.Combinacaos", "Usuario_id", "dbo.Usuarios", "id");
        }
    }
}

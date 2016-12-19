namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao_jogopossuido_include_combinacoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JogoPossuidoes", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropIndex("dbo.JogoPossuidoes", new[] { "Combinacao_CombinacaoID" });
            CreateTable(
                "dbo.JogoPossuidoCombinacaos",
                c => new
                    {
                        JogoPossuido_id = c.Int(nullable: false),
                        Combinacao_CombinacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JogoPossuido_id, t.Combinacao_CombinacaoID })
                .ForeignKey("dbo.JogoPossuidoes", t => t.JogoPossuido_id, cascadeDelete: true)
                .ForeignKey("dbo.Combinacaos", t => t.Combinacao_CombinacaoID, cascadeDelete: true)
                .Index(t => t.JogoPossuido_id)
                .Index(t => t.Combinacao_CombinacaoID);
            
            DropColumn("dbo.JogoPossuidoes", "Combinacao_CombinacaoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JogoPossuidoes", "Combinacao_CombinacaoID", c => c.Int());
            DropForeignKey("dbo.JogoPossuidoCombinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropForeignKey("dbo.JogoPossuidoCombinacaos", "JogoPossuido_id", "dbo.JogoPossuidoes");
            DropIndex("dbo.JogoPossuidoCombinacaos", new[] { "Combinacao_CombinacaoID" });
            DropIndex("dbo.JogoPossuidoCombinacaos", new[] { "JogoPossuido_id" });
            DropTable("dbo.JogoPossuidoCombinacaos");
            CreateIndex("dbo.JogoPossuidoes", "Combinacao_CombinacaoID");
            AddForeignKey("dbo.JogoPossuidoes", "Combinacao_CombinacaoID", "dbo.Combinacaos", "CombinacaoID");
        }
    }
}

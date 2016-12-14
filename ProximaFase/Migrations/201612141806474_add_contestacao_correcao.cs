namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_contestacao_correcao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Combinacaos", "Constestacao_ContestacaoID", "dbo.Contestacaos");
            DropIndex("dbo.Combinacaos", new[] { "Constestacao_ContestacaoID" });
            AddColumn("dbo.Contestacaos", "CombinacaoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contestacaos", "CombinacaoID");
            AddForeignKey("dbo.Contestacaos", "CombinacaoID", "dbo.Combinacaos", "CombinacaoID", cascadeDelete: true);
            DropColumn("dbo.Combinacaos", "Constestacao_ContestacaoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Combinacaos", "Constestacao_ContestacaoID", c => c.Int());
            DropForeignKey("dbo.Contestacaos", "CombinacaoID", "dbo.Combinacaos");
            DropIndex("dbo.Contestacaos", new[] { "CombinacaoID" });
            DropColumn("dbo.Contestacaos", "CombinacaoID");
            CreateIndex("dbo.Combinacaos", "Constestacao_ContestacaoID");
            AddForeignKey("dbo.Combinacaos", "Constestacao_ContestacaoID", "dbo.Contestacaos", "ContestacaoID");
        }
    }
}

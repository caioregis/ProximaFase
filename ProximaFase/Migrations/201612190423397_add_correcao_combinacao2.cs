namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_combinacao2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Combinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropIndex("dbo.Combinacaos", new[] { "Combinacao_CombinacaoID" });
            DropColumn("dbo.Combinacaos", "Combinacao_CombinacaoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Combinacaos", "Combinacao_CombinacaoID", c => c.Int());
            CreateIndex("dbo.Combinacaos", "Combinacao_CombinacaoID");
            AddForeignKey("dbo.Combinacaos", "Combinacao_CombinacaoID", "dbo.Combinacaos", "CombinacaoID");
        }
    }
}

namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_combinacao3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuarios", "Combinacao_CombinacaoID", "dbo.Combinacaos");
            DropIndex("dbo.Usuarios", new[] { "Combinacao_CombinacaoID" });
            DropColumn("dbo.Usuarios", "Combinacao_CombinacaoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Combinacao_CombinacaoID", c => c.Int());
            CreateIndex("dbo.Usuarios", "Combinacao_CombinacaoID");
            AddForeignKey("dbo.Usuarios", "Combinacao_CombinacaoID", "dbo.Combinacaos", "CombinacaoID");
        }
    }
}

namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_jogopossuido_teste : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.JogoPossuidoes", new[] { "Combinacao_CombinacaoID" });
            CreateIndex("dbo.JogoPossuidoes", "combinacao_CombinacaoID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.JogoPossuidoes", new[] { "combinacao_CombinacaoID" });
            CreateIndex("dbo.JogoPossuidoes", "Combinacao_CombinacaoID");
        }
    }
}

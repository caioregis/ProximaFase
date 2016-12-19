namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_combinacao_jogopossuido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Combinacaos", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.JogoPossuidoes", "Disponivel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JogoPossuidoes", "Disponivel");
            DropColumn("dbo.Combinacaos", "Status");
        }
    }
}

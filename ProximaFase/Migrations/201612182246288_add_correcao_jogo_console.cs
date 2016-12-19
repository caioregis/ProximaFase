namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_jogo_console : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JogoDesejadoes", "consoleID", c => c.Int(nullable: false));
            AddColumn("dbo.JogoPossuidoes", "consoleID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JogoPossuidoes", "consoleID");
            DropColumn("dbo.JogoDesejadoes", "consoleID");
        }
    }
}

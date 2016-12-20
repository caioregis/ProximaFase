namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jogoDesejadoModel_e_jogoPossuidoModel_correcao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jogoes", "console_ConsoleGameID", "dbo.ConsoleGames");
            DropForeignKey("dbo.JogoDesejadoes", "jogoID", "dbo.Jogoes");
            DropForeignKey("dbo.JogoPossuidoes", "jogoID", "dbo.Jogoes");
            DropIndex("dbo.JogoDesejadoes", new[] { "jogoID" });
            DropIndex("dbo.Jogoes", new[] { "console_ConsoleGameID" });
            DropIndex("dbo.JogoPossuidoes", new[] { "jogoID" });
            AddColumn("dbo.JogoDesejadoes", "nome", c => c.String());
            AddColumn("dbo.JogoDesejadoes", "anoLancamento", c => c.Int(nullable: false));
            AddColumn("dbo.JogoDesejadoes", "valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.JogoDesejadoes", "console_ConsoleGameID", c => c.Int());
            AddColumn("dbo.JogoPossuidoes", "nome", c => c.String());
            AddColumn("dbo.JogoPossuidoes", "anoLancamento", c => c.Int(nullable: false));
            AddColumn("dbo.JogoPossuidoes", "valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.JogoPossuidoes", "console_ConsoleGameID", c => c.Int());
            CreateIndex("dbo.JogoDesejadoes", "console_ConsoleGameID");
            CreateIndex("dbo.JogoPossuidoes", "console_ConsoleGameID");
            AddForeignKey("dbo.JogoDesejadoes", "console_ConsoleGameID", "dbo.ConsoleGames", "ConsoleGameID");
            AddForeignKey("dbo.JogoPossuidoes", "console_ConsoleGameID", "dbo.ConsoleGames", "ConsoleGameID");
            DropColumn("dbo.JogoDesejadoes", "jogoID");
            DropColumn("dbo.JogoPossuidoes", "jogoID");
            DropTable("dbo.Jogoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Jogoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        anoLancamento = c.Int(nullable: false),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        console_ConsoleGameID = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.JogoPossuidoes", "jogoID", c => c.Int(nullable: false));
            AddColumn("dbo.JogoDesejadoes", "jogoID", c => c.Int(nullable: false));
            DropForeignKey("dbo.JogoPossuidoes", "console_ConsoleGameID", "dbo.ConsoleGames");
            DropForeignKey("dbo.JogoDesejadoes", "console_ConsoleGameID", "dbo.ConsoleGames");
            DropIndex("dbo.JogoPossuidoes", new[] { "console_ConsoleGameID" });
            DropIndex("dbo.JogoDesejadoes", new[] { "console_ConsoleGameID" });
            DropColumn("dbo.JogoPossuidoes", "console_ConsoleGameID");
            DropColumn("dbo.JogoPossuidoes", "valor");
            DropColumn("dbo.JogoPossuidoes", "anoLancamento");
            DropColumn("dbo.JogoPossuidoes", "nome");
            DropColumn("dbo.JogoDesejadoes", "console_ConsoleGameID");
            DropColumn("dbo.JogoDesejadoes", "valor");
            DropColumn("dbo.JogoDesejadoes", "anoLancamento");
            DropColumn("dbo.JogoDesejadoes", "nome");
            CreateIndex("dbo.JogoPossuidoes", "jogoID");
            CreateIndex("dbo.Jogoes", "console_ConsoleGameID");
            CreateIndex("dbo.JogoDesejadoes", "jogoID");
            AddForeignKey("dbo.JogoPossuidoes", "jogoID", "dbo.Jogoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.JogoDesejadoes", "jogoID", "dbo.Jogoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Jogoes", "console_ConsoleGameID", "dbo.ConsoleGames", "ConsoleGameID");
        }
    }
}

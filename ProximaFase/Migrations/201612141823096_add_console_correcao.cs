namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_console_correcao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsoleGames",
                c => new
                    {
                        ConsoleGameID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsoleGameID);
            
            CreateTable(
                "dbo.ConsoleGameUsuarios",
                c => new
                    {
                        ConsoleGame_ConsoleGameID = c.Int(nullable: false),
                        Usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsoleGame_ConsoleGameID, t.Usuario_id })
                .ForeignKey("dbo.ConsoleGames", t => t.ConsoleGame_ConsoleGameID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_id, cascadeDelete: true)
                .Index(t => t.ConsoleGame_ConsoleGameID)
                .Index(t => t.Usuario_id);
            
            AddColumn("dbo.Jogoes", "console_ConsoleGameID", c => c.Int());
            CreateIndex("dbo.Jogoes", "console_ConsoleGameID");
            AddForeignKey("dbo.Jogoes", "console_ConsoleGameID", "dbo.ConsoleGames", "ConsoleGameID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogoes", "console_ConsoleGameID", "dbo.ConsoleGames");
            DropForeignKey("dbo.ConsoleGameUsuarios", "Usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.ConsoleGameUsuarios", "ConsoleGame_ConsoleGameID", "dbo.ConsoleGames");
            DropIndex("dbo.ConsoleGameUsuarios", new[] { "Usuario_id" });
            DropIndex("dbo.ConsoleGameUsuarios", new[] { "ConsoleGame_ConsoleGameID" });
            DropIndex("dbo.Jogoes", new[] { "console_ConsoleGameID" });
            DropColumn("dbo.Jogoes", "console_ConsoleGameID");
            DropTable("dbo.ConsoleGameUsuarios");
            DropTable("dbo.ConsoleGames");
        }
    }
}

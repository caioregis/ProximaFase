namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_console_jogo_jogopossuido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consoles",
                c => new
                    {
                        ConsoleID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsoleID);
            
            CreateTable(
                "dbo.ConsoleUsuarios",
                c => new
                    {
                        Console_ConsoleID = c.Int(nullable: false),
                        Usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Console_ConsoleID, t.Usuario_id })
                .ForeignKey("dbo.Consoles", t => t.Console_ConsoleID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_id, cascadeDelete: true)
                .Index(t => t.Console_ConsoleID)
                .Index(t => t.Usuario_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsoleUsuarios", "Usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.ConsoleUsuarios", "Console_ConsoleID", "dbo.Consoles");
            DropIndex("dbo.ConsoleUsuarios", new[] { "Usuario_id" });
            DropIndex("dbo.ConsoleUsuarios", new[] { "Console_ConsoleID" });
            DropTable("dbo.ConsoleUsuarios");
            DropTable("dbo.Consoles");
        }
    }
}

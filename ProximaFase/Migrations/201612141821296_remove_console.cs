namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_console : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsoleUsuarios", "Console_ConsoleID", "dbo.Consoles");
            DropForeignKey("dbo.ConsoleUsuarios", "Usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Jogoes", "console_ConsoleID", "dbo.Consoles");
            DropIndex("dbo.Jogoes", new[] { "console_ConsoleID" });
            DropIndex("dbo.ConsoleUsuarios", new[] { "Console_ConsoleID" });
            DropIndex("dbo.ConsoleUsuarios", new[] { "Usuario_id" });
            DropColumn("dbo.Jogoes", "console_ConsoleID");
            DropTable("dbo.Consoles");
            DropTable("dbo.ConsoleUsuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConsoleUsuarios",
                c => new
                    {
                        Console_ConsoleID = c.Int(nullable: false),
                        Usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Console_ConsoleID, t.Usuario_id });
            
            CreateTable(
                "dbo.Consoles",
                c => new
                    {
                        ConsoleID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsoleID);
            
            AddColumn("dbo.Jogoes", "console_ConsoleID", c => c.Int());
            CreateIndex("dbo.ConsoleUsuarios", "Usuario_id");
            CreateIndex("dbo.ConsoleUsuarios", "Console_ConsoleID");
            CreateIndex("dbo.Jogoes", "console_ConsoleID");
            AddForeignKey("dbo.Jogoes", "console_ConsoleID", "dbo.Consoles", "ConsoleID");
            AddForeignKey("dbo.ConsoleUsuarios", "Usuario_id", "dbo.Usuarios", "id", cascadeDelete: true);
            AddForeignKey("dbo.ConsoleUsuarios", "Console_ConsoleID", "dbo.Consoles", "ConsoleID", cascadeDelete: true);
        }
    }
}

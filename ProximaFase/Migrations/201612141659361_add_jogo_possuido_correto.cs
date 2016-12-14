namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_jogo_possuido_correto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JogoPossuidoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jogoID = c.Int(nullable: false),
                        usuarioID = c.Int(nullable: false),
                        detalhes = c.String(),
                        dataDeCompra = c.DateTime(nullable: false),
                        estado = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogoes", t => t.jogoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.usuarioID, cascadeDelete: true)
                .Index(t => t.jogoID)
                .Index(t => t.usuarioID);
            
            CreateTable(
                "dbo.Jogoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        anoLancamento = c.DateTime(nullable: false),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        console_ConsoleID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Consoles", t => t.console_ConsoleID)
                .Index(t => t.console_ConsoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JogoPossuidoes", "usuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.JogoPossuidoes", "jogoID", "dbo.Jogoes");
            DropForeignKey("dbo.Jogoes", "console_ConsoleID", "dbo.Consoles");
            DropIndex("dbo.Jogoes", new[] { "console_ConsoleID" });
            DropIndex("dbo.JogoPossuidoes", new[] { "usuarioID" });
            DropIndex("dbo.JogoPossuidoes", new[] { "jogoID" });
            DropTable("dbo.Jogoes");
            DropTable("dbo.JogoPossuidoes");
        }
    }
}

namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_contestacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contestacaos",
                c => new
                    {
                        ContestacaoID = c.Int(nullable: false, identity: true),
                        UsuarioAcusadoID = c.Int(nullable: false),
                        FraudeConfirmada = c.Boolean(nullable: false),
                        ValorMulta = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ContestacaoID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioAcusadoID, cascadeDelete: true)
                .Index(t => t.UsuarioAcusadoID);
            
            AddColumn("dbo.Combinacaos", "Constestacao_ContestacaoID", c => c.Int());
            CreateIndex("dbo.Combinacaos", "Constestacao_ContestacaoID");
            AddForeignKey("dbo.Combinacaos", "Constestacao_ContestacaoID", "dbo.Contestacaos", "ContestacaoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Combinacaos", "Constestacao_ContestacaoID", "dbo.Contestacaos");
            DropForeignKey("dbo.Contestacaos", "UsuarioAcusadoID", "dbo.Usuarios");
            DropIndex("dbo.Contestacaos", new[] { "UsuarioAcusadoID" });
            DropIndex("dbo.Combinacaos", new[] { "Constestacao_ContestacaoID" });
            DropColumn("dbo.Combinacaos", "Constestacao_ContestacaoID");
            DropTable("dbo.Contestacaos");
        }
    }
}

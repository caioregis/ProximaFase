namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_console : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CombinacaoUsuarios", newName: "UsuarioCombinacaos");
            DropPrimaryKey("dbo.UsuarioCombinacaos");
            AddPrimaryKey("dbo.UsuarioCombinacaos", new[] { "Usuario_id", "Combinacao_CombinacaoID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UsuarioCombinacaos");
            AddPrimaryKey("dbo.UsuarioCombinacaos", new[] { "Combinacao_CombinacaoID", "Usuario_id" });
            RenameTable(name: "dbo.UsuarioCombinacaos", newName: "CombinacaoUsuarios");
        }
    }
}

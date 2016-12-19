namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsoleGames", "Usuario_id", "dbo.Usuarios");
            DropIndex("dbo.ConsoleGames", new[] { "Usuario_id" });
            DropColumn("dbo.ConsoleGames", "Usuario_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConsoleGames", "Usuario_id", c => c.Int());
            CreateIndex("dbo.ConsoleGames", "Usuario_id");
            AddForeignKey("dbo.ConsoleGames", "Usuario_id", "dbo.Usuarios", "id");
        }
    }
}

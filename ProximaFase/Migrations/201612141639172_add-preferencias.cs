namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpreferencias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preferencias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        distanciaMaximaDeBusca = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preferencias", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Preferencias", new[] { "UsuarioId" });
            DropTable("dbo.Preferencias");
        }
    }
}

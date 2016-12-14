namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_jogos_desejados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JogoDesejadoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jogoID = c.Int(nullable: false),
                        usuarioID = c.Int(nullable: false),
                        estado = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogoes", t => t.jogoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.usuarioID, cascadeDelete: true)
                .Index(t => t.jogoID)
                .Index(t => t.usuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JogoDesejadoes", "usuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.JogoDesejadoes", "jogoID", "dbo.Jogoes");
            DropIndex("dbo.JogoDesejadoes", new[] { "usuarioID" });
            DropIndex("dbo.JogoDesejadoes", new[] { "jogoID" });
            DropTable("dbo.JogoDesejadoes");
        }
    }
}

namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_cartao_de_credito : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartaoDeCreditoes",
                c => new
                    {
                        CartaoDeCreditoID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        Bandeira = c.String(),
                        Numero = c.Int(nullable: false),
                        DataVencimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartaoDeCreditoID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartaoDeCreditoes", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.CartaoDeCreditoes", new[] { "UsuarioID" });
            DropTable("dbo.CartaoDeCreditoes");
        }
    }
}

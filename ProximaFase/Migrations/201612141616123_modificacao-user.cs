namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacaouser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        logradouro = c.String(nullable: false),
                        numero = c.Int(nullable: false),
                        complemento = c.String(),
                        bairro = c.String(),
                        cidade = c.String(nullable: false),
                        estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Usuarios", "email", c => c.String(nullable: false));
            AddColumn("dbo.Usuarios", "nome", c => c.String(nullable: false));
            AddColumn("dbo.Usuarios", "telefone", c => c.String());
            AddColumn("dbo.Usuarios", "endereco_id", c => c.Int());
            CreateIndex("dbo.Usuarios", "endereco_id");
            AddForeignKey("dbo.Usuarios", "endereco_id", "dbo.Enderecoes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "endereco_id", "dbo.Enderecoes");
            DropIndex("dbo.Usuarios", new[] { "endereco_id" });
            DropColumn("dbo.Usuarios", "endereco_id");
            DropColumn("dbo.Usuarios", "telefone");
            DropColumn("dbo.Usuarios", "nome");
            DropColumn("dbo.Usuarios", "email");
            DropTable("dbo.Enderecoes");
        }
    }
}

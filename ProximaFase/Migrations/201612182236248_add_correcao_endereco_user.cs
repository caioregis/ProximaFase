namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_correcao_endereco_user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuarios", "endereco_id", "dbo.Enderecoes");
            DropIndex("dbo.Usuarios", new[] { "endereco_id" });
            RenameColumn(table: "dbo.Usuarios", name: "endereco_id", newName: "enderecoID");
            AlterColumn("dbo.Usuarios", "enderecoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuarios", "enderecoID");
            AddForeignKey("dbo.Usuarios", "enderecoID", "dbo.Enderecoes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "enderecoID", "dbo.Enderecoes");
            DropIndex("dbo.Usuarios", new[] { "enderecoID" });
            AlterColumn("dbo.Usuarios", "enderecoID", c => c.Int());
            RenameColumn(table: "dbo.Usuarios", name: "enderecoID", newName: "endereco_id");
            CreateIndex("dbo.Usuarios", "endereco_id");
            AddForeignKey("dbo.Usuarios", "endereco_id", "dbo.Enderecoes", "id");
        }
    }
}

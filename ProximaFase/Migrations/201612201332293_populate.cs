namespace ProximaFase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JogoDesejadoes", "anoLancamento", c => c.Int(nullable: false));
            AlterColumn("dbo.JogoPossuidoes", "anoLancamento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JogoPossuidoes", "anoLancamento", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JogoDesejadoes", "anoLancamento", c => c.DateTime(nullable: false));
        }
    }
}

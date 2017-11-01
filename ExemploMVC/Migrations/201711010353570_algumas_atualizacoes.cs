namespace ExemploMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class algumas_atualizacoes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enderecos", "Rua", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Enderecos", "Bairro", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Enderecos", "Bairro", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Enderecos", "Rua", c => c.String(maxLength: 255, unicode: false));
        }
    }
}

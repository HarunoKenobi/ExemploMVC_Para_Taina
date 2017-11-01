namespace ExemploMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rua = c.String(maxLength: 255, unicode: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(maxLength: 255, unicode: false),
                        MoradorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.MoradorId)
                .Index(t => t.MoradorId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "MoradorId", "dbo.Usuarios");
            DropIndex("dbo.Enderecos", new[] { "MoradorId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Enderecos");
        }
    }
}

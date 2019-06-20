namespace TPMascotas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inical : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adoptadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Edad = c.Int(nullable: false),
                        NivelSociabilidad = c.Int(nullable: false),
                        SociablAanimal = c.Boolean(nullable: false),
                        Sexo = c.String(),
                        Foto = c.String(),
                        TipoAnimal = c.String(),
                        Raza = c.String(),
                        Tamanio = c.Single(nullable: false),
                        Nombre = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Contrasenia = c.String(),
                        NombreCompleto = c.String(),
                        NumeroCelular = c.String(),
                        ViveEnCasaODepto = c.Boolean(nullable: false),
                        Localidad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Encontradoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Localidad = c.String(),
                        Foto = c.String(),
                        TipoAnimal = c.String(),
                        Raza = c.String(),
                        Tamanio = c.Single(nullable: false),
                        Nombre = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Perdidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        recompensa = c.Single(nullable: false),
                        zona = c.String(),
                        Foto = c.String(),
                        TipoAnimal = c.String(),
                        Raza = c.String(),
                        Tamanio = c.Single(nullable: false),
                        Nombre = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Perdidoes", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Encontradoes", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Adoptadoes", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Perdidoes", new[] { "UsuarioID" });
            DropIndex("dbo.Encontradoes", new[] { "UsuarioID" });
            DropIndex("dbo.Adoptadoes", new[] { "UsuarioID" });
            DropTable("dbo.Perdidoes");
            DropTable("dbo.Encontradoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Adoptadoes");
        }
    }
}

namespace TPMascotas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
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
                        Desc = c.String(),
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
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Perdidoes");
            DropTable("dbo.Encontradoes");
            DropTable("dbo.Adoptadoes");
        }
    }
}

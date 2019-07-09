namespace TPMascotas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initnueva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adoptadoes", "Genero", c => c.String());
            AddColumn("dbo.Encontradoes", "Genero", c => c.String());
            AddColumn("dbo.Perdidoes", "Genero", c => c.String());
            AlterColumn("dbo.Adoptadoes", "NivelSociabilidad", c => c.String());
            AlterColumn("dbo.Adoptadoes", "SociablAanimal", c => c.String());
            AlterColumn("dbo.Adoptadoes", "Tamanio", c => c.String());
            AlterColumn("dbo.Encontradoes", "Tamanio", c => c.String());
            AlterColumn("dbo.Perdidoes", "Tamanio", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Perdidoes", "Tamanio", c => c.Single(nullable: false));
            AlterColumn("dbo.Encontradoes", "Tamanio", c => c.Single(nullable: false));
            AlterColumn("dbo.Adoptadoes", "Tamanio", c => c.Single(nullable: false));
            AlterColumn("dbo.Adoptadoes", "SociablAanimal", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Adoptadoes", "NivelSociabilidad", c => c.Int(nullable: false));
            DropColumn("dbo.Perdidoes", "Genero");
            DropColumn("dbo.Encontradoes", "Genero");
            DropColumn("dbo.Adoptadoes", "Genero");
        }
    }
}

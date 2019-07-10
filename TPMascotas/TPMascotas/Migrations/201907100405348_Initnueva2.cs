namespace TPMascotas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initnueva2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Mail");
            DropColumn("dbo.AspNetUsers", "Contrasenia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Contrasenia", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Mail", c => c.String());
        }
    }
}

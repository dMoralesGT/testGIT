namespace Proyect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTiempo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarea", "tiempoEstimado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarea", "tiempoEstimado");
        }
    }
}

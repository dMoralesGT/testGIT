namespace Proyect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CambioEstado",
                c => new
                    {
                        CambioEstadoID = c.Int(nullable: false, identity: true),
                        fechaInicial = c.DateTime(nullable: false),
                        fechaFinal = c.DateTime(nullable: false),
                        TareaID = c.Int(nullable: false),
                        EstadoID = c.Int(),
                    })
                .PrimaryKey(t => t.CambioEstadoID)
                .ForeignKey("dbo.Estado", t => t.EstadoID)
                .ForeignKey("dbo.Tarea", t => t.TareaID, cascadeDelete: true)
                .Index(t => t.TareaID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        HorasReales = c.Boolean(nullable: false),
                        Inicial = c.Boolean(nullable: false),
                        Final = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoID);
            
            CreateTable(
                "dbo.Tarea",
                c => new
                    {
                        TareaID = c.Int(nullable: false, identity: true),
                        asunto = c.String(),
                        cuerpo = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        DesarrolladorID = c.Int(),
                        ProyectoID = c.Int(nullable: false),
                        PrioridadID = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TareaID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Desarrollador", t => t.DesarrolladorID)
                .ForeignKey("dbo.Estado", t => t.EstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Prioridad", t => t.PrioridadID, cascadeDelete: true)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoID, cascadeDelete: true)
                .Index(t => t.DesarrolladorID)
                .Index(t => t.ProyectoID)
                .Index(t => t.PrioridadID)
                .Index(t => t.EstadoID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Desarrollador",
                c => new
                    {
                        DesarrolladorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DesarrolladorID);
            
            CreateTable(
                "dbo.Proyecto",
                c => new
                    {
                        ProyectoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DesarrolladorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProyectoID)
                .ForeignKey("dbo.Desarrollador", t => t.DesarrolladorID, cascadeDelete: true)
                .Index(t => t.DesarrolladorID);
            
            CreateTable(
                "dbo.Inicidencia",
                c => new
                    {
                        IncidenciaID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Resuelto = c.Boolean(nullable: false),
                        TareaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncidenciaID)
                .ForeignKey("dbo.Tarea", t => t.TareaID, cascadeDelete: true)
                .Index(t => t.TareaID);
            
            CreateTable(
                "dbo.Prioridad",
                c => new
                    {
                        PrioridadID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.PrioridadID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarea", "ProyectoID", "dbo.Proyecto");
            DropForeignKey("dbo.Tarea", "PrioridadID", "dbo.Prioridad");
            DropForeignKey("dbo.Inicidencia", "TareaID", "dbo.Tarea");
            DropForeignKey("dbo.Tarea", "EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Tarea", "DesarrolladorID", "dbo.Desarrollador");
            DropForeignKey("dbo.Proyecto", "DesarrolladorID", "dbo.Desarrollador");
            DropForeignKey("dbo.Tarea", "CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.CambioEstado", "TareaID", "dbo.Tarea");
            DropForeignKey("dbo.CambioEstado", "EstadoID", "dbo.Estado");
            DropIndex("dbo.Inicidencia", new[] { "TareaID" });
            DropIndex("dbo.Proyecto", new[] { "DesarrolladorID" });
            DropIndex("dbo.Tarea", new[] { "CategoriaID" });
            DropIndex("dbo.Tarea", new[] { "EstadoID" });
            DropIndex("dbo.Tarea", new[] { "PrioridadID" });
            DropIndex("dbo.Tarea", new[] { "ProyectoID" });
            DropIndex("dbo.Tarea", new[] { "DesarrolladorID" });
            DropIndex("dbo.CambioEstado", new[] { "EstadoID" });
            DropIndex("dbo.CambioEstado", new[] { "TareaID" });
            DropTable("dbo.Prioridad");
            DropTable("dbo.Inicidencia");
            DropTable("dbo.Proyecto");
            DropTable("dbo.Desarrollador");
            DropTable("dbo.Categoria");
            DropTable("dbo.Tarea");
            DropTable("dbo.Estado");
            DropTable("dbo.CambioEstado");
        }
    }
}

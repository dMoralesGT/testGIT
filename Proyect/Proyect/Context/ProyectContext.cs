using Proyect.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Proyect.Context
{
    public class ProyectContext: DbContext
    {
        public ProyectContext() : base("ProyectContext")
        {

        }

        public DbSet<CambioEstado> CambiosEstado { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Desarrollador> Desarrolladores { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }

        public System.Data.Entity.DbSet<Proyect.Models.Inicidencia> Inicidencias { get; set; }
    }
}
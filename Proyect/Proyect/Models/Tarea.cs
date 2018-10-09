using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect.Models
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public string asunto { get; set; }
        public string cuerpo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int tiempoEstimado { get; set; }

        public int? DesarrolladorID {get; set; }
        public virtual Desarrollador Desarrollador { get; set; }

        public int ProyectoID { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public int PrioridadID { get; set; }
        public virtual Prioridad Prioridad { get; set; }

        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<CambioEstado> CambioEstado { get; set; }
        public virtual ICollection<Inicidencia> Incidencia { get; set; }
    }
}
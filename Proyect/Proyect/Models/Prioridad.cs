using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect.Models
{
    public class Prioridad
    {
        public int PrioridadID { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection <Tarea> Tarea { get; set; }
    }
}
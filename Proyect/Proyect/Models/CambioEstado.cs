using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect.Models
{
    public class CambioEstado
    {
        public int CambioEstadoID { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }

        public int TareaID { get; set; }
        public int? EstadoID { get; set; }

        public virtual Tarea Tarea { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
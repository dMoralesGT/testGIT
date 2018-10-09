using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect.Models
{
    public class Estado
    {
        public int EstadoID { get; set; }
        public String Nombre { get; set; }
        public bool HorasReales { get; set; }
        public bool Inicial { get; set; }
        public bool Final { get; set; }

        public virtual ICollection<Tarea> Tarea { get; set; }
        public virtual ICollection<CambioEstado> CambioEstado { get; set; }
    }
}
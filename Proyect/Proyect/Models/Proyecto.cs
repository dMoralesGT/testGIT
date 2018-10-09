using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect.Models
{
    public class Proyecto
    {
        public int ProyectoID { get; set; }
        public string Nombre { get; set; }
        public int DesarrolladorID { get; set; }

        public virtual Desarrollador Desarrollador { get; set; }
    }
}
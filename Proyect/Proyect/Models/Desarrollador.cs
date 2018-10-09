using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyect.Models
{
    public class Desarrollador
    {
        public int DesarrolladorID { get; set; }
        public string Nombre { get; set; }
        public Boolean Admin { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
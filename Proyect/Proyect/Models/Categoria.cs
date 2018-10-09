using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Proyect.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
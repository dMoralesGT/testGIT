using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyect.Models
{
    public class Inicidencia
    {
        [Key]
        public int IncidenciaID { get; set; }
        public string Descripcion { get; set; }
        public bool Resuelto { get; set; }

        public int TareaID { get; set; }
        public virtual Tarea Tarea { get; set; }
    }
}
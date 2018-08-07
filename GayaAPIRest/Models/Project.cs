using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class Project
    {
        public int NumProyecto { get; set; }
        public DatosProyecto DatosProyecto { get; set; }
    }
    
    public class DatosProyecto
    {
        public string Empresa { get; set; }
        public string Clave { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
    }
}
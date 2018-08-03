using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class PresupuestoContratado
    {
        public string Empresa { get; set; }
        public string Proyecto { get; set; }
        public Contratos Contratos { get; set; }
    }

    public class Contratos
    {
        public string NumContrato { get; set; }
        public int Ejercicio { get; set; }
        public int Periodo { get; set; }
        public string Cliente { get; set; }
        public object[] Posiciones { get; set; }
    }
}
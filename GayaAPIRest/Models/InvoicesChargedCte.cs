using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class InvoicesChargedCte
    {
        public int IDRegistro { get; set; }
        public DatosPagadoCte DatosPagadoCte { get; set; }
    }

    public class DatosPagadoCte
    {
        public string EmpresaID { get; set; }
        public string EmpresaNombre { get; set; }
        public string Movimiento { get; set; }
        public string Origen { get; set; }
        public string FechaEmision { get; set; }
        public string Referencia { get; set; }
        public string Proyecto { get; set; }
        public string Cliente { get; set; }
        public string NombreCte { get; set; }
        public int Ejercicio { get; set; }
        public int Periodo { get; set; }
        public decimal Importe { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal ImportePesos { get; set; }
    }

}
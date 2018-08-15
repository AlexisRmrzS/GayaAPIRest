using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class InvoicedProv
    {
        public int IDRegistro { get; set; }
        public DatosPresupuestoFactP DatosPresupuestoFactP { get; set; }
    }
    
    public class DatosPresupuestoFactP
    {
        public string EmpresaID { get; set; }
        public string EmpresaNombre { get; set; }
        public string Movimiento { get; set; }
        public string Origen { get; set; }
        public string FechaEmision { get; set; }
        public string Referencia { get; set; }
        public string Proyecto { get; set; }
        public string Proveedor { get; set; }
        public string NombreProv { get; set; }
        public string ClavePresupuestal { get; set; }
        public string Grupo { get; set; }
        public string Nombre { get; set; }
        public int EjercicioAfecta { get; set; }
        public int PeriodoAfecta { get; set; }
        public decimal Importe { get; set; }
    }
}
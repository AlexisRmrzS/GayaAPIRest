using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class OperationBudget
    {
        public int IDRegistro { get; set; }
        public DatosPresupuestoOper DatosPresupuesto { get; set; }
    }

    public class DatosPresupuestoOper
    {
        public string EmpresaID { get; set; }
        public string EmpresaNombre { get; set; }
        public string Movimiento { get; set; }
        public string Tipo { get; set; }
        public string FechaEmision { get; set; }
        public string Proyecto { get; set; }
        public string ClavePresupuestal { get; set; }
        public string Grupo { get; set; }
        public string Nombre { get; set; }
        public int EjercicioAfecta { get; set; }
        public int PeriodoAfecta { get; set; }
        public decimal Importe { get; set; }
    }
}
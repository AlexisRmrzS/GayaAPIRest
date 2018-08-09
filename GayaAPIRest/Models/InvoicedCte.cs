using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class InvoicedCte
    {
        public int IDRegistro { get; set; }
        public InvRegistro InvRegistro { get; set; }
    }

    public class InvRegistro
    {
        public string EmpresaID { get; set; }
        public string EmpresaNombre { get; set; }
        public string Proyecto { get; set; }
        public string Origen { get; set; }
        public string Movimiento { get; set; }
        public string FechaEmision { get; set; }
        public string Concepto { get; set; }
        public string Observaciones { get; set; }
        public string Cliente { get; set; }
        public string NombreCliente { get; set; }
        public string Partida { get; set; }
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal Importe { get; set; }
        public decimal ImportePesos { get; set; }

    }
}
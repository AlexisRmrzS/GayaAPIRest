using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class ContractedBudget
    {
        public int IDRegistro { get; set; }
        public Registro Registro { get; set; }
    }

    public class Registro
    {
        public string IDEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Proyecto { get; set; }
        public string Contrato { get; set; }
        public int Ejercicio { get; set; }
        public int Periodo { get; set; }
        public string Cliente { get; set; }
        public string NombreCliente { get; set; }
        public string Tipo { get; set; }
        public string Posicion { get; set; }
        public string NombrePosicion { get; set; }
        public string FechaModificacion { get; set; }
        public string Partida { get; set; }
        public int Factor { get; set; }
        public decimal Importe { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal ImportePesos { get; set; }
    }
    
}
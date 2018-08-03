using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GayaAPIRest.Models
{
    public class ContractedBudget
    {
        public string Empresa { get; set; }
        public Proyecto Proyecto { get; set; }
    }
        
    public class Proyecto
    {
        public string Nombre { get; set; }
        public Contrato Contrato { get; set; }
    }

    public class Contrato
    {
        public string NumContrato { get; set; }
        public int Ejercicio { get; set; }
        public int Periodo { get; set; }
        public Cliente Cliente { get; set; }
        public Posicion Posicion { get; set; }
    }

    public class Cliente
    {
        public string CodCliente { get; set; }
        public string Nombre { get; set; }
    }

    public class Posicion
    {
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public Partida Partida { get; set; }
    }

    public class Partida
    {
        public string Nombre { get; set; }
        public int Factor { get; set; }
        public float Importe { get; set; }
        public float TipoCambio { get; set; }
        public float ImportePesos { get; set; }
    }
    
}
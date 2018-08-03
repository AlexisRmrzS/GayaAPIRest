using GayaAPIRest.Models;
using GayaAPIRest.Data_Access;
using System.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cryptography;

namespace GayaAPIRest.Controllers
{
    public class ContractedBudgetController : ApiController
    {
        ContractedBudget presupuesto = new ContractedBudget { Empresa = "Gaya Construcciones", Proyecto = new Proyecto { Nombre = "ATT FASE II", Contrato = new Contrato { NumContrato = "Contrato Constr.Prov 332", Ejercicio = 2017, Periodo = 4, Cliente = new Cliente { CodCliente = "CTE-23213", Nombre = "Juan Perez"} , Posicion = new Posicion { Tipo = "POSICION", Nombre = "Presupuesto Inicial", Partida = new Partida { Nombre = "016-INSTALACIONES ELECTRICAS", Factor = 1, Importe = (float)182732.82, TipoCambio = (float)18.04, ImportePesos = (float)3296500.0728 } } } } };
        PresupuestoContratado presupuesto2 = new PresupuestoContratado();

        // GET: api/ContractedBudget
        public string Get()
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.ExecQuery("G001", "ATT_TOREO_0131INTF01");

            return dt.Rows[0]["Contrato"].ToString() + " " + dt.Rows[0]["Partida"].ToString();
            
            //return Decrypt.FixedDecrypt(ConfigurationManager.AppSettings["secureConnection"]);
        }
        

        // GET: api/ContractedBudget?Empresa=G001?Proyecto=ATT_TOREO_0131INTF01
        public IHttpActionResult Get(string Empresa, string Proyecto)
        {
            presupuesto2.Empresa = "Master Builder III";
            presupuesto2.Proyecto = "Altan Redes";
            presupuesto2.Contratos = new Contratos();
            presupuesto2.Contratos.Cliente = "Pedro Torres";
            presupuesto2.Contratos.Ejercicio = 2017;
            presupuesto2.Contratos.Periodo = 4;
            presupuesto2.Contratos.NumContrato = "Contrato Constr.Prov";
            presupuesto2.Contratos.Posiciones = new object[] { "016-INST. ELECTRICAS", "123495.98" };

            return Ok(presupuesto2);
        }

    }
}

using GayaAPIRest.Models;
using GayaAPIRest.Data_Access;
using System.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Http;

namespace GayaAPIRest.Controllers
{
    public class ContractedBudgetController : ApiController
    {
        private ContractedBudget[] objectBuilder(string Proyecto)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getContractedBudget(Proyecto);
            ContractedBudget[] budget = new ContractedBudget[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ContractedBudget temp = new ContractedBudget();
                temp.IDRegistro = i + 1;

                temp.Registro = new Registro();

                temp.Registro.IDEmpresa = dt.Rows[i]["Empresa"].ToString();
                temp.Registro.NombreEmpresa = dt.Rows[i]["NombreEmpresa"].ToString();
                temp.Registro.Proyecto = dt.Rows[i]["Proyecto"].ToString();
                temp.Registro.Contrato = dt.Rows[i]["Contrato"].ToString();
                temp.Registro.Ejercicio = Convert.ToInt32(dt.Rows[i]["Ejercicio"].ToString());
                temp.Registro.Periodo = Convert.ToInt32(dt.Rows[i]["Periodo"].ToString());
                temp.Registro.Cliente = dt.Rows[i]["Cliente"].ToString();
                temp.Registro.NombreCliente = dt.Rows[i]["NombreCliente"].ToString();
                temp.Registro.Tipo = dt.Rows[i]["Tipo"].ToString();
                temp.Registro.Posicion = dt.Rows[i]["Posicion"].ToString();
                temp.Registro.NombrePosicion = dt.Rows[i]["NombrePosicion"].ToString();
                temp.Registro.FechaModificacion = dt.Rows[i]["FechaModificacion"].ToString();
                temp.Registro.Partida = dt.Rows[i]["Partida"].ToString();
                temp.Registro.Factor = Convert.ToInt32(dt.Rows[i]["Factor"].ToString());
                temp.Registro.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"].ToString());
                temp.Registro.TipoCambio = Convert.ToDecimal(dt.Rows[i]["TipoCambio"].ToString());
                temp.Registro.ImportePesos = Convert.ToDecimal(dt.Rows[i]["ImportePesos"].ToString());

                budget[i] = temp;

            }

            return budget;
        }

        // GET: api/ContractedBudget
        public IHttpActionResult Get()
        {
            Default def = new Default();
            def.APIName = "Gaya Construcciones API";
            def.APIVersion = ConfigurationManager.AppSettings["APIVersion"];
            def.APIPath = "/api/ContractedBudget/";
            def.APIExample = "/api/ContractedBudget?Project={ProjectID}";
            def.APIMessage = "Developed By ARS";

            return Ok(def);
        }
        
        // GET: api/ContractedBudget?Project=ATT_TOREO_0131INTF01
        public IHttpActionResult Get(string Project)
        {
            try
            {
                return Ok(objectBuilder(Project));
            }
            catch (Exception e)
            {
                return Ok(new { Exception = new { ErrorSource = e.Source, ErrorMethod = e.TargetSite.Name, ErrorMessage = e.Message } });
            }
        }
        
    }
}

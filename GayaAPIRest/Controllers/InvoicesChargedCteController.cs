using GayaAPIRest.Data_Access;
using GayaAPIRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GayaAPIRest.Controllers
{
    public class InvoicesChargedCteController : ApiController
    {
        private InvoicesChargedCte[] objectBuilder(string Proyecto)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getInvoicesCharged(Proyecto);
            InvoicesChargedCte[] invoices = new InvoicesChargedCte[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InvoicesChargedCte temp = new InvoicesChargedCte();
                temp.IDRegistro = i + 1;

                temp.DatosPagadoCte = new DatosPagadoCte();

                temp.DatosPagadoCte.EmpresaID = dt.Rows[i]["EmpresaID"].ToString();
                temp.DatosPagadoCte.EmpresaNombre = dt.Rows[i]["EmpresaNombre"].ToString();
                temp.DatosPagadoCte.Movimiento = dt.Rows[i]["Movimiento"].ToString();
                temp.DatosPagadoCte.Origen = dt.Rows[i]["Origen"].ToString();
                temp.DatosPagadoCte.FechaEmision = dt.Rows[i]["FechaEmision"].ToString();
                temp.DatosPagadoCte.Referencia = dt.Rows[i]["Referencia"].ToString();
                temp.DatosPagadoCte.Proyecto = dt.Rows[i]["Proyecto"].ToString();
                temp.DatosPagadoCte.Cliente = dt.Rows[i]["Cliente"].ToString();
                temp.DatosPagadoCte.NombreCte = dt.Rows[i]["NombreCte"].ToString();
                temp.DatosPagadoCte.Ejercicio = Convert.ToInt32(dt.Rows[i]["Ejercicio"].ToString());
                temp.DatosPagadoCte.Periodo = Convert.ToInt32(dt.Rows[i]["Periodo"].ToString());
                temp.DatosPagadoCte.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"].ToString());
                temp.DatosPagadoCte.TipoCambio = Convert.ToDecimal(dt.Rows[i]["TipoCambio"].ToString());
                temp.DatosPagadoCte.ImportePesos = Convert.ToDecimal(dt.Rows[i]["ImportePesos"].ToString());

                invoices[i] = temp;

            }

            return invoices;
        }

        // GET: api/InvoicesChargedCte
        public IHttpActionResult Get()
        {
            Default def = new Default();
            def.APIName = "Gaya Construcciones API";
            def.APIVersion = ConfigurationManager.AppSettings["APIVersion"];
            def.APIPath = "/api/InvoicesChargedCte/";
            def.APIExample = "/api/InvoicesChargedCte?Project={ProjectID}";
            def.APIMessage = "Developed By ARS";

            return Ok(def);
        }

        // GET: api/InvoicesChargedCte?Project=ATT_TOREO_0131INTF01
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

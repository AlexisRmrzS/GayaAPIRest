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
    public class InvoicedCteController : ApiController
    {
        private InvoicedCte[] objectBuilder(string Project)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getInvoicedCte(Project);

            InvoicedCte[] invoices = new InvoicedCte[dt.Rows.Count];

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                InvoicedCte temp = new InvoicedCte();
                temp.IDRegistro = i + 1;

                temp.InvRegistro = new InvRegistro();

                temp.InvRegistro.EmpresaID = dt.Rows[i]["Empresa"].ToString();
                temp.InvRegistro.EmpresaNombre = dt.Rows[i]["NombreEmpresa"].ToString();
                temp.InvRegistro.Proyecto = dt.Rows[i]["Proyecto"].ToString();
                temp.InvRegistro.Origen = dt.Rows[i]["Origen"].ToString();
                temp.InvRegistro.Movimiento = dt.Rows[i]["Movimiento"].ToString();
                temp.InvRegistro.FechaEmision = dt.Rows[i]["FechaEmision"].ToString();
                temp.InvRegistro.Concepto = dt.Rows[i]["Concepto"].ToString();
                temp.InvRegistro.Observaciones = dt.Rows[i]["Observaciones"].ToString();
                temp.InvRegistro.Cliente = dt.Rows[i]["Cliente"].ToString();
                temp.InvRegistro.NombreCliente = dt.Rows[i]["NombreCliente"].ToString();
                temp.InvRegistro.Partida = dt.Rows[i]["Partida"].ToString();
                temp.InvRegistro.Moneda = dt.Rows[i]["Moneda"].ToString();
                temp.InvRegistro.TipoCambio = Convert.ToDecimal(dt.Rows[i]["TipoCambio"].ToString());
                temp.InvRegistro.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"].ToString());
                temp.InvRegistro.ImportePesos = Convert.ToDecimal(dt.Rows[i]["ImportePesos"].ToString());

                invoices[i] = temp;

            }

            return invoices;

        }

        // GET: api/InvoicedCte
        public IHttpActionResult Get()
        {
            Default def = new Default();
            def.APIName = "Gaya Construcciones API";
            def.APIVersion = ConfigurationManager.AppSettings["APIVersion"];
            def.APIPath = "/api/InvoicedCte/";
            def.APIExample = "/api/InvoicedCte?Project={ProjectID}";
            def.APIMessage = "Developed By ARS";

            return Ok(def);
        }

        // GET: api/InvoicedCte/5
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

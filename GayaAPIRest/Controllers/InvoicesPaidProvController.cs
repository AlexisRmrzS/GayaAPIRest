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
    public class InvoicesPaidProvController : ApiController
    {
        private InvoicesPaidProv[] objectBuilder(string Proyecto)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getInvoicesPaid(Proyecto);
            InvoicesPaidProv[] budget = new InvoicesPaidProv[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InvoicesPaidProv temp = new InvoicesPaidProv();
                temp.IDRegistro = i + 1;

                temp.DatosPagadoProv = new DatosPagadoProv();

                temp.DatosPagadoProv.EmpresaID = dt.Rows[i]["EmpresaID"].ToString();
                temp.DatosPagadoProv.EmpresaNombre = dt.Rows[i]["EmpresaNombre"].ToString();
                temp.DatosPagadoProv.Movimiento = dt.Rows[i]["Movimiento"].ToString();
                temp.DatosPagadoProv.Origen = dt.Rows[i]["Origen"].ToString();
                temp.DatosPagadoProv.FechaEmision = dt.Rows[i]["FechaEmision"].ToString();

                temp.DatosPagadoProv.Proyecto = dt.Rows[i]["Proyecto"].ToString();
                temp.DatosPagadoProv.Proveedor = dt.Rows[i]["Proveedor"].ToString();
                temp.DatosPagadoProv.NombreProv = dt.Rows[i]["NombreProv"].ToString();
                temp.DatosPagadoProv.ClavePresupuestal = dt.Rows[i]["ClavePresupuestal"].ToString();
                temp.DatosPagadoProv.Grupo = dt.Rows[i]["Grupo"].ToString();
                temp.DatosPagadoProv.Nombre = dt.Rows[i]["Nombre"].ToString();
                temp.DatosPagadoProv.EjercicioAfecta = Convert.ToInt32(dt.Rows[i]["Ejercicio"].ToString());
                temp.DatosPagadoProv.PeriodoAfecta = Convert.ToInt32(dt.Rows[i]["Periodo"].ToString());
                temp.DatosPagadoProv.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"].ToString());

                budget[i] = temp;

            }

            return budget;
        }

        // GET: api/InvoicesPaidProv
        public IHttpActionResult Get()
        {
            Default def = new Default();
            def.APIName = "Gaya Construcciones API";
            def.APIVersion = ConfigurationManager.AppSettings["APIVersion"];
            def.APIPath = "/api/InvoicesPaidProv/";
            def.APIExample = "/api/InvoicesPaidProv?Project={ProjectID}";
            def.APIMessage = "Developed By ARS";

            return Ok(def);
        }

        // GET: api/InvoicesPaidProv?Project=ATT_TOREO_0131INTF01
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

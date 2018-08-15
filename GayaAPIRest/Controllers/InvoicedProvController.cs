using GayaAPIRest.Models;
using GayaAPIRest.Data_Access;
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
    public class InvoicedProvController : ApiController
    {
        private InvoicedProv[] objectBuilder(string Proyecto)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getInvoicedProv(Proyecto);
            InvoicedProv[] budget = new InvoicedProv[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InvoicedProv temp = new InvoicedProv();
                temp.IDRegistro = i + 1;

                temp.DatosPresupuestoFactP = new DatosPresupuestoFactP();

                temp.DatosPresupuestoFactP.EmpresaID = dt.Rows[i]["EmpresaID"].ToString();
                temp.DatosPresupuestoFactP.EmpresaNombre = dt.Rows[i]["EmpresaNombre"].ToString();
                temp.DatosPresupuestoFactP.Movimiento = dt.Rows[i]["Movimiento"].ToString();
                temp.DatosPresupuestoFactP.Origen = dt.Rows[i]["Origen"].ToString();
                temp.DatosPresupuestoFactP.FechaEmision = dt.Rows[i]["FechaEmision"].ToString();
                temp.DatosPresupuestoFactP.Referencia = dt.Rows[i]["Referencia"].ToString();

                temp.DatosPresupuestoFactP.Proyecto = dt.Rows[i]["Proyecto"].ToString();
                temp.DatosPresupuestoFactP.Proveedor = dt.Rows[i]["Proveedor"].ToString();
                temp.DatosPresupuestoFactP.NombreProv = dt.Rows[i]["NombreProv"].ToString();
                temp.DatosPresupuestoFactP.ClavePresupuestal = dt.Rows[i]["ClavePresupuestal"].ToString();
                temp.DatosPresupuestoFactP.Grupo = dt.Rows[i]["Grupo"].ToString();
                temp.DatosPresupuestoFactP.Nombre = dt.Rows[i]["Nombre"].ToString();
                temp.DatosPresupuestoFactP.EjercicioAfecta = Convert.ToInt32(dt.Rows[i]["EjercicioAfecta"].ToString());
                temp.DatosPresupuestoFactP.PeriodoAfecta = Convert.ToInt32(dt.Rows[i]["PeriodoAfecta"].ToString());
                temp.DatosPresupuestoFactP.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"].ToString());

                budget[i] = temp;

            }

            return budget;
        }

        // GET: api/InvoicedProv
        public IHttpActionResult Get()
        {
            Default def = new Default();
            def.APIName = "Gaya Construcciones API";
            def.APIVersion = ConfigurationManager.AppSettings["APIVersion"];
            def.APIPath = "/api/InvoicedProv/";
            def.APIExample = "/api/InvoicedProv?Project={ProjectID}";
            def.APIMessage = "Developed By ARS";

            return Ok(def);
        }

        // GET: api/InvoicedProv/5
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

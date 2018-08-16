using GayaAPIRest.Data_Access;
using GayaAPIRest.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GayaAPIRest.Controllers
{
    public class CommittedBudgetController : ApiController
    {
        private CommittedBudget[] objectBuilder(string Proyecto)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getCommittedBudget(Proyecto);
            CommittedBudget[] budget = new CommittedBudget[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CommittedBudget temp = new CommittedBudget();
                temp.IDRegistro = i + 1;

                temp.DatosPresupuestoCompr = new DatosPresupuestoCompr();

                temp.DatosPresupuestoCompr.EmpresaID = dt.Rows[i]["EmpresaID"].ToString();
                temp.DatosPresupuestoCompr.EmpresaNombre = dt.Rows[i]["EmpresaNombre"].ToString();
                temp.DatosPresupuestoCompr.Movimiento = dt.Rows[i]["Movimiento"].ToString();
                temp.DatosPresupuestoCompr.FechaEmision = dt.Rows[i]["FechaEmision"].ToString();
                temp.DatosPresupuestoCompr.Referencia = dt.Rows[i]["Referencia"].ToString();

                temp.DatosPresupuestoCompr.Proyecto = dt.Rows[i]["Proyecto"].ToString();
                temp.DatosPresupuestoCompr.Proveedor = dt.Rows[i]["Proveedor"].ToString();
                temp.DatosPresupuestoCompr.NombreProv = dt.Rows[i]["NombreProv"].ToString();
                temp.DatosPresupuestoCompr.ClavePresupuestal = dt.Rows[i]["ClavePresupuestal"].ToString();
                temp.DatosPresupuestoCompr.Grupo = dt.Rows[i]["Grupo"].ToString();
                temp.DatosPresupuestoCompr.Nombre = dt.Rows[i]["Nombre"].ToString();
                temp.DatosPresupuestoCompr.EjercicioAfecta = Convert.ToInt32(dt.Rows[i]["EjercicioAfecta"].ToString());
                temp.DatosPresupuestoCompr.PeriodoAfecta = Convert.ToInt32(dt.Rows[i]["PeriodoAfecta"].ToString());
                temp.DatosPresupuestoCompr.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"].ToString());
                
                budget[i] = temp;

            }

            return budget;
        }

        // GET: api/CommittedBudget
        public IHttpActionResult Get()
        {
            Default def = new Default();
            def.APIName = "Gaya Construcciones API";
            def.APIVersion = ConfigurationManager.AppSettings["APIVersion"];
            def.APIPath = "/api/CommittedBudget/";
            def.APIExample = "/api/CommittedBudget?Project={ProjectID}";
            def.APIMessage = "Developed By ARS";

            return Ok(def);
        }

        // GET: api/CommittedBudget?Project=ATT_TOREO_0131INTF01
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

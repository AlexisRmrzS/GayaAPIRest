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
    public class OperationBudgetController : ApiController
    {
        private OperationBudget[] objectBuilder(string Project)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getOperationBudget(Project);

            OperationBudget[] operationBudgets = new OperationBudget[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OperationBudget temp = new OperationBudget();
                temp.IDRegistro = i + 1;

                temp.DatosPresupuesto = new DatosPresupuestoOper();

                temp.DatosPresupuesto.EmpresaID = dt.Rows[i]["EmpresaID"].ToString();
                temp.DatosPresupuesto.EmpresaNombre = dt.Rows[i]["EmpresaNombre"].ToString();
                temp.DatosPresupuesto.Movimiento = dt.Rows[i]["Movimiento"].ToString();
                temp.DatosPresupuesto.Tipo = dt.Rows[i]["Tipo"].ToString();
                temp.DatosPresupuesto.FechaEmision= dt.Rows[i]["FechaEmision"].ToString();
                temp.DatosPresupuesto.Proyecto = dt.Rows[i]["Proyecto"].ToString();
                temp.DatosPresupuesto.ClavePresupuestal= dt.Rows[i]["ClavePresupuestal"].ToString();
                temp.DatosPresupuesto.Grupo = dt.Rows[i]["Grupo"].ToString();
                temp.DatosPresupuesto.Nombre = dt.Rows[i]["Nombre"].ToString();
                temp.DatosPresupuesto.EjercicioAfecta = Convert.ToInt32(dt.Rows[i]["EjercicioAfecta"].ToString());
                temp.DatosPresupuesto.PeriodoAfecta = Convert.ToInt32(dt.Rows[i]["PeriodoAfecta"].ToString());
                temp.DatosPresupuesto.Importe = Convert.ToDecimal(dt.Rows[i]["Importe"].ToString());

                operationBudgets[i] = temp;
            }
            
            return operationBudgets;

        }

        // GET: api/OperationBudget
        public IHttpActionResult Get()
        {
            Default def = new Default();
            def.APIName = ConfigurationManager.AppSettings["APIName"];
            def.APIVersion = ConfigurationManager.AppSettings["APIVersion"];
            def.APIPath = "/api/OperationBudget/";
            def.APIExample = "/api/OperationBudget?Project={ProjectID}";
            def.APIMessage = "Developed By ARS";

            return Ok(def);
        }

        // GET: api/OperationBudget/5
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

using GayaAPIRest.Models;
using GayaAPIRest.Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GayaAPIRest.Controllers
{
    public class ProjectController : ApiController
    {
        private Project[] objectBuilder(string Company)
        {
            Project[] projects;
            DataAccess da = new DataAccess();
            DataTable dt = da.getProject(Company);

            if (dt.Rows.Count >= 1)
            {
                projects = new Project[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Project temp = new Project();
                    temp.NumProyecto = i + 1;
                    temp.DatosProyecto = new DatosProyecto();

                    temp.DatosProyecto.EmpresaID = dt.Rows[i]["EmpresaID"].ToString();
                    temp.DatosProyecto.EmpresaNombre = dt.Rows[i]["EmpresaNombre"].ToString();
                    temp.DatosProyecto.Clave = dt.Rows[i]["Proyecto"].ToString();
                    temp.DatosProyecto.Categoria = dt.Rows[i]["Categoria"].ToString();
                    temp.DatosProyecto.Descripcion = dt.Rows[i]["Descripcion"].ToString();

                    projects[i] = temp;
                }
            }
            else
            {
                projects = new Project[1];
                Project temp = new Project();
                temp.NumProyecto = 1;
                temp.DatosProyecto = new DatosProyecto { EmpresaID = "", EmpresaNombre = "", Clave = "Sin Proyectos", Categoria = "", Descripcion = "No se encontraron registros con la clave especificada." };
                projects[0] = temp;
            }

            return projects;
            
        }

        // GET: api/Project
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(objectBuilder(null));
            }
            catch (Exception e)
            {
                return Ok(new { Exception = new { ErrorSource = e.Source, ErrorMethod = e.TargetSite.Name, ErrorMessage = e.Message } } );
            }
            
        }

        // GET: api/Project/Company
        public IHttpActionResult Get(string CompanyID)
        {
            try
            {
                return Ok(objectBuilder(CompanyID));
            }
            catch (Exception e)
            {
                return Ok(new { Exception = new { ErrorSource = e.Source, ErrorMethod = e.TargetSite.Name, ErrorMessage = e.Message }});
            }
            
        }

        
    }
}

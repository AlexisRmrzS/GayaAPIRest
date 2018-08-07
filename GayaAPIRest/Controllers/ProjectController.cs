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
        private Project[] objectBuilder(string Project)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.getProject(Project);
            Project[] projects;

            if (dt.Rows.Count >= 1)
            {
                projects = new Project[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Project temp = new Project();
                    temp.NumProyecto = i + 1;
                    temp.DatosProyecto = new DatosProyecto();

                    temp.DatosProyecto.Empresa = dt.Rows[i]["Empresa"].ToString();
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
                temp.DatosProyecto = new DatosProyecto { Empresa = "", Clave = "Sin Proyectos", Categoria = "", Descripcion = "No se encontraron registros con la clave especificada." };
                projects[0] = temp;
            }
            
            return projects;
        }

        // GET: api/Project
        public IHttpActionResult Get()
        {
            return Ok(objectBuilder(null));
        }

        // GET: api/Project/5
        public IHttpActionResult Get(string ID)
        {
            return Ok(objectBuilder(ID));
        }

        
    }
}

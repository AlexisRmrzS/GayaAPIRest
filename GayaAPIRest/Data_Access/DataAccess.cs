using System;
using System.Collections.Generic;
using Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Web;

namespace GayaAPIRest.Data_Access
{
    public class DataAccess
    {
        SqlConnection connectionString = new SqlConnection(Decrypt.FixedDecrypt(ConfigurationManager.AppSettings["secureConnection"]));

        public DataTable getContractedBudget(string Empresa, string Proyecto)
        {
            string sqlSentence = "SELECT * FROM CP_PresupuestoContratado_CTE WHERE EMPRESA = @Empresa AND PROYECTO = @Proyecto ORDER BY Ejercicio, Periodo, FechaModificacion";

            if (connectionString.State == ConnectionState.Open)
                connectionString.Close();
            
            SqlCommand cmd = new SqlCommand(sqlSentence, connectionString);
            cmd.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Empresa;
            cmd.Parameters.Add("@Proyecto", SqlDbType.VarChar).Value = Proyecto;

            connectionString.Open();
            
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            
            dt.Load(dr);
            
            return dt;
        }

        public DataTable getProject(string Project)
        {
            string sqlSentence = "";
            if (String.IsNullOrEmpty(Project))
                sqlSentence = "SELECT ISNULL(E.Nombre, 'NO IDENTIFICADA') AS Empresa, P.Proyecto, ISNULL(P.CATEGORIA, '') AS Categoria, ISNULL(P.DESCRIPCION, '') AS Descripcion " +
                                "FROM PROY P LEFT JOIN Empresa E ON P.Empresa = E.Empresa WHERE P.ESTATUS = 'ALTA' ORDER BY P.Proyecto";
            else
                sqlSentence = "SELECT ISNULL(E.Nombre, 'NO IDENTIFICADA') AS Empresa, P.Proyecto, ISNULL(P.CATEGORIA, '') AS Categoria, ISNULL(P.DESCRIPCION, '') AS Descripcion " +
                                "FROM PROY P LEFT JOIN Empresa E ON P.Empresa = E.Empresa WHERE P.ESTATUS = 'ALTA' AND P.Proyecto = @Proyecto ORDER BY P.Proyecto";

            if (connectionString.State == ConnectionState.Open)
                connectionString.Close();

            SqlCommand cmd = new SqlCommand(sqlSentence, connectionString);

            if (!String.IsNullOrEmpty(Project))
                cmd.Parameters.Add("@Proyecto", SqlDbType.VarChar).Value = Project;

            connectionString.Open();

            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            return dt;
        }
    }
}
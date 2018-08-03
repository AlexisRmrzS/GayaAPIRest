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

        public DataTable ExecQuery(string Empresa, string Proyecto)
        {
            string sqlSentence = "SELECT * FROM CP_PresupuestoContratado_CTE WHERE EMPRESA = @Empresa AND PROYECTO = @Proyecto";

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
    }
}
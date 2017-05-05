using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CrudPersonaSp.Dao
{
    public class Conexion
    {
        public string strConexion { get; set; }
        public SqlConnection conn { get; set; }
        public Conexion()
        {
            //recuperamos la cadena de conexion 
            strConexion = System.Configuration.ConfigurationManager.ConnectionStrings["dbTestPersonaCadenaConexion"].ConnectionString;
            conn = new SqlConnection(strConexion);
           // conn.ConnectionString = strConexion;
           
        }
        public void Conectar()
        {
            conn.Open();   
        }
        public void Desconectar()
        {
            conn.Close();
        }
        public string test()
        {
            try
            {
                conn.Open();
                return "Se ha conectado";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }

        }
            
    }
}
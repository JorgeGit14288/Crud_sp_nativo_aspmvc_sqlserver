using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudPersonaSp.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CrudPersonaSp.Dao
{
    public class PersonasDao:IPersonasDao
    {
        // variables para conexion
        SqlCommand cmd;
        SqlTransaction trx;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        //objeto para obtener la variable de conexion
        Conexion varConexion = new Conexion();
        
        public string Crear(Personas persona)
        {
            try
            {
                varConexion.Conectar();
                // le pasamos la variable de conexion a la transaccion
               trx = varConexion.conn.BeginTransaction();
                // le pasamos la variable de conexion al comando
                cmd = new SqlCommand("Persona_Insert", varConexion.conn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregamos los parametros 
                cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value= persona.idPersona;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar,50).Value = persona.nombre;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.direccion;
                cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = persona.imagen;
                cmd.Parameters.Add("@nacimiento", SqlDbType.Date).Value = persona.nacimiento.Date;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.telefono;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.email;
                //capturamos el numero de filas afectadas
                int rowsAffected = cmd.ExecuteNonQuery();
                //si las filas afectadas son mayor a 0, eso quiere decir que si inserto
                if (rowsAffected>0)
                {
                   trx.Commit();
                    return "Ok";
                }
                 trx.Rollback();
                return "Error, No se logro insertar el registro";
            }
            catch (Exception ex)
            {
                 trx.Rollback();
                return "Error, No se pudo establecer la conexion "+ ex.ToString();
            }
        }

        public string Eliminar(int idPersona)
        {
            throw new NotImplementedException();
        }

        public string Actualizar(Personas persona)
        {
            throw new NotImplementedException();
        }

        public Personas BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public Personas BuscarNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Personas> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public int ObtenerId()
        {
            throw new NotImplementedException();
        }
    }
}
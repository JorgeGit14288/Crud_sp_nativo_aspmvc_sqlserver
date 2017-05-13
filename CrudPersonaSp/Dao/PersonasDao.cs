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
                if(Existe(persona.idPersona))
                {
                    return "El id de usuario ya esta registrado, ingrese otro id";
                }

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

            try
            {
                if(Existe(idPersona))
                {
                    //Abrimos la conexion
                    varConexion.Conectar();
                    //iniciamos la transaccion
                    trx = varConexion.conn.BeginTransaction();
                    //creamo el comando
                    cmd = new SqlCommand("Persona_Delete", varConexion.conn, trx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //agregamos el parametro para eliminar
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    //obtenemoscon un int el numero de filas afectadas
                    int rowAffected = cmd.ExecuteNonQuery();
                    if(rowAffected==1)
                    {
                        //la fila ha sido eliminada
                        trx.Commit();
                        varConexion.Desconectar();
                        return "Se ha eliminado un registro de la base de datos";
                    }
                    if(rowAffected>1)
                    {
                        trx.Rollback();
                        varConexion.Desconectar();
                        // se han eliminado mas de un registro, por lo que hacemos un rollback
                        return "Error, se ha intentado eliminar mas de un registro, solo se debe eliminar uno a la vez";
                    }
                }
                return "No existe el id a eliminar";
            
            }
            catch
            {
                   trx.Rollback();
                        varConexion.Desconectar();
                return "Ha ocurrido un error al intentar eliminar el registro";

            }
        }

        public string Actualizar(Personas persona)
        {
            try
            {
                //abrimos la conexion
                varConexion.Conectar();
                //iniciamos la transaccion
                trx = varConexion.conn.BeginTransaction();
                //trx.Connection.ConnectionString = varConexion.strConexion;
               // trx.Connection.BeginTransaction();
                //creamos el comando
                cmd = new SqlCommand("Persona_Update", varConexion.conn, trx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", persona.idPersona);
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@direccion", persona.direccion);
                cmd.Parameters.AddWithValue("@imagen", persona.imagen);
                cmd.Parameters.AddWithValue("@nacimiento", persona.nacimiento);
                cmd.Parameters.AddWithValue("@telefono", persona.telefono);
                cmd.Parameters.AddWithValue("@email", persona.email);

                //obtenermos el entero de retorno para ver si afecto a algunas filas
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected>0)
                {
                    trx.Commit();
                    varConexion.Desconectar();
                    return "Se ha actualizado " + rowsAffected + " registro de la base de datos";
                   
                }
                trx.Rollback();
                varConexion.Desconectar();
                return "No se ha podido actualizar el registro";


            }
            catch
            {
                trx.Rollback();
                varConexion.Desconectar();
                return "Error, no se ha podidio Actualizar el registro";
            }
        }

        public Personas BuscarId(int id)
        {
            Personas p = new Personas();
            try
            {
                //iniciamos la conexion
                varConexion.Conectar();
                //iniciamos el comando
                cmd = new SqlCommand("Persona_Select", varConexion.conn);
                //creamos los pararmetros que recibe el procedimiento almacenado
                cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value=id;
                cmd.CommandType = CommandType.StoredProcedure;
                dr= cmd.ExecuteReader();
                
                if(dr.HasRows)
                {
                     while (dr.Read())
                     {
                         p.idPersona = Convert.ToInt32(dr["idPersona"]);
                         p.nombre = dr["nombre"].ToString();
                         p.direccion = dr["direccion"].ToString();
                         if(!String.IsNullOrEmpty(dr["imagen"].ToString()))
                         {
                             p.imagen = (byte[])dr["imagen"];
                         }
                         p.nacimiento = Convert.ToDateTime(dr["nacimiento"]);
                         p.telefono= dr["telefono"].ToString();
                         p.email = dr["email"].ToString();

                     }
                }
                varConexion.Desconectar();
                return p;

            }
            catch (Exception ex)
            {
                varConexion.Desconectar();
                return p;
            }
        }

        public Personas BuscarNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Personas> Listar()
        {
            List<Personas> lista = new List<Personas>();
            try
            {
                //abrimos la conexion
                varConexion.Conectar();
                //agregamos el comando
                cmd = new SqlCommand("Persona_Listar", varConexion.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Personas p = new Personas();
                        p.idPersona = Convert.ToInt32(dr["idPersona"]);
                        p.nombre = dr["nombre"].ToString();
                        p.direccion = dr["direccion"].ToString();
                        if (!String.IsNullOrEmpty(dr["imagen"].ToString()))
                        {
                            p.imagen = (byte[])dr["imagen"];
                        }
                        p.telefono = dr["telefono"].ToString();
                        p.nacimiento = DateTime.Parse(dr["nacimiento"].ToString());
                        p.email = dr["email"].ToString();

                        lista.Add(p);
                        
                    }
                    dr.NextResult();
                }
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Existe(int id)
        {
           try
           {
               //abrimos la conexion
               varConexion.Conectar();
               //instanceamos el comando
               cmd = new SqlCommand("Persona_Exists", varConexion.conn);
               cmd.CommandType = CommandType.StoredProcedure;
               //agregamos los parametros de entrada
               cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = id;
               //agregamos parametro de salida
               
               cmd.Parameters.Add("@exists", SqlDbType.Int).Direction =ParameterDirection.Output;
               //ejecutamos el comando de consulta
               cmd.ExecuteNonQuery();
               varConexion.Desconectar();
               int existe = Convert.ToInt32(cmd.Parameters["@exists"].Value.ToString());
               if(existe==1)
               {
                   return true;
               }
               return false;
           }
            catch(Exception ex)
           {
               return false;
           }
        }

        public int ObtenerId()
        {
            try
            {
                //iniciamos la conexion
                varConexion.Conectar();
                //pasamos los datos al comando
                cmd = new SqlCommand("select_max_id_persona", varConexion.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // creamos la variable de salida
                cmd.Parameters.Add("@idPersona", SqlDbType.Int);
                cmd.Parameters["@idPersona"].Direction = ParameterDirection.Output;

                //creamos la variable de retorno por si queremos recuperar el retorno
                cmd.Parameters.Add("@return_value", SqlDbType.Int);
                cmd.Parameters["@return_value"].Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();
                int idreturn = Convert.ToInt32(cmd.Parameters["@return_value"].Value);
                int id = Convert.ToInt32(cmd.Parameters["@idPersona"].Value);
                return id+1;

            }
            catch
            {
                return 0;
            }
        }
    }
}
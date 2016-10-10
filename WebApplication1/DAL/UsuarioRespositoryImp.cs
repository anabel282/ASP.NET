using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class UsuarioRespositoryImp : UsuarioRepository
    {

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;

        public Usuario create(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void delete(Guid codigo)
        {

        }

        public IList<Usuario> getAll()
        {
            IList<Usuario> usuarios = null;
            const string SQL = "getAllUsuario";//procedimiento almacenado que tenga en la SQLServer

            using(SqlConnection conexion = new SqlConnection())
            {
                SqlCommand command = new SqlCommand(SQL, conexion);
                command.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        usuarios = new List<Usuario>();
                        Usuario usuario = null;

                        while (reader.Read())
                        {
                            usuario = parseUsuario(reader);
                        }
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public Usuario getById(Guid codigo)
        {
            Usuario usuario = null;
            const string SQL = "";
            //Con el using cuando termine el metodo, se destruye automaticamente el objeto
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();
                ;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)//comprobamos si devuelve datos
                    {

                        while (reader.Read())//cada vuelta es una tupla
                        {
                            usuario = parseUsuario(reader);
                        }
                    }
                }
            }
            return usuario
        }

        private Usuario parseUsuario(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.CodUsuario = new Guid(reader["codUsuario"].ToString());
            usuario.Nombre = reader["nombre"].ToString();
            usuario.Apellidos = reader["apellidos"].ToString();
            usuario.Alias = reader["alias"].ToString();
            usuario.Pass = reader["pass"].ToString();
            usuario.Dni = reader["dni"].ToString();
            usuario.FNacimiento = Convert.ToDateTime(reader["fNacimiento"].ToString());

            return usuario;
        }

        public Usuario update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
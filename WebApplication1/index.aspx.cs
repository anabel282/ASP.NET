using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            try
            {
                /*
                 *Estamos referenciado las etiquetas del web.config, el configuracionManager --> etiqueta configuration, connectionStrings --> etiqueta connectionString  
                 */
                string cadenaConexion = ConfigurationManager.ConnectionStrings[""].ConnectionString;
                string SQL = "SELECT * FROM usuario";
                SqlConnection conn = new SqlConnection(cadenaConexion);
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter(SQL, conn);
                dAdapter.Fill(ds);
                dt = ds.Tables[0];

                grdUsuarios.DataSource = dt;
                grdUsuarios.DataBind();
                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Console.Error.Write(ex.Message);
            }
        }

        protected void grdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            //int codUsuario
            switch (commandName)
            {
                case "editUsuario":
                    //Hemos pulsado el boton de editar;
                    break;
                case "borrarUsuario":
                    //Hemos pulsado el boton borrar;
                    break;
            }
        }
    }
}
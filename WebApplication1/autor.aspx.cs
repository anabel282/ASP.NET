using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Autor : System.Web.UI.Page
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
                string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
                string SQL = "SELECT * FROM autor";
                SqlConnection conn = new SqlConnection(cadenaConexion);
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter(SQL, conn);
                dAdapter.Fill(ds);
                dt = ds.Tables[0];

                grdv_autores.DataSource = dt;
                grdv_autores.DataBind();

                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Console.Write(ex.Message);
            }
        }


        protected void grdv_autores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            string codAutor = grdv_autores.DataKeys[index].Value.ToString();

            switch (command)
            {
                case "editarAutor":
                    {
                        lblIdAutor.Text = codAutor;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#editModal').modal('show')");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarEditar", sb.ToString(), false);
                    }
                    break;
                case "borrarAutor":
                    {
                        lblIdAutor.Text = codAutor;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#borrarModal').modal('show')");
                        sb.Append(@"</script>");
                    }
                    break;
            }
        }

        protected void btnCrearAutor_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            lblIdAutor.Text = "-1";
            txtNombreAutor.Text = "";
            sb.Append(@"<script>");
            sb.Append("$('#editModal').modal('show')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarCreate", sb.ToString(), false);
        }


        protected void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            string codigo = lblIdAutor.Text;
            string nombre = txtNombreAutor.Text;
            int cod;
            string SQL = "INSERT INTO autor (nombre, borrado) VALUES ('" + nombre + "', 0)";

            if (Int32.TryParse(codigo, out cod) && cod > -1)
            {
                SQL = "UPDATE autor SET nombre=" + nombre + " borrado=0 WHERE codAutor=" + cod;
            }

            string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();
                SqlCommand sqlcomm = new SqlCommand();
                sqlcomm.Connection = conn;
                sqlcomm.CommandText = SQL;
                sqlcomm.CommandType = CommandType.Text;
                sqlcomm.ExecuteNonQuery();
 
            }catch(SqlException ex)
            {
                System.Console.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            cargarDatos();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script>");
            sb.Append("$(#'editModal').modal('hide')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OcultarCreate", sb.ToString(), false);

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;

            string codigo = lblIdAutor.Text;
            string SQL = "DELETE FROM usuario WHERE codAutor=" + codigo;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = SQL;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                System.Console.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            cargarDatos();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            lblMensaje.Text = "";
            txtIdAutor.Text = "-1";
            sb.Append(@"<script>");
            sb.Append("$(#'borrarModal').modal('hide')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "borrar", sb.ToString(), false);
        }
    }
}
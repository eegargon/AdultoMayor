using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAdultoMayor
{
    public partial class frmusers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Listar)
            {
                BindTable();
            }

            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Editar)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            string username = Request.QueryString["username"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM users WHERE username = '{username}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtusername.Value = dt.Rows[0]["username"].ToString();
            txtpassword.Value = "---";//dt.Rows[0]["password"].ToString();
            txtroles.Value = dt.Rows[0]["roles"].ToString();
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                             username,
                                                             password,
                                                             roles
                                                        FROM users", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string username = row.Cells[0].Text;

            Response.Redirect("~/admin/frmusers.aspx?cmd=edit&username=" + username);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string username = (Request.Form["ctl00$contenido$txtusername"] != null) ? Request.Form["ctl00$contenido$txtusername"].ToString() : "";
            string password = (Request.Form["ctl00$contenido$txtpassword"] != null) ? Request.Form["ctl00$contenido$txtpassword"].ToString() : "";
            string roles = (Request.Form["ctl00$contenido$txtroles"] != null) ? Request.Form["ctl00$contenido$txtroles"].ToString() : "";
            
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    users
                                SET 
                                    roles=?                                    
                                WHERE
                                    username=?
                                ";
            if (!password.Equals("---"))
            {
                cmd.CommandText = @"UPDATE 
                                    users
                                SET 
                                    password=?,
                                    roles=?                                    
                                WHERE
                                    username=?
                                ";
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                cmd.Parameters.Add(new OdbcParameter("password", password));
            }
            cmd.Parameters.Add(new OdbcParameter("roles", roles));
            cmd.Parameters.Add(new OdbcParameter("username", username));
            

            cmd.Connection = new OdbcConnection(Utilities.ObtenerCadenaConexion());
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                IrAlListadoPrincipal();
            }
            catch (Exception ex)
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }

        protected void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            IrAlListadoPrincipal();
        }

        private void IrAlListadoPrincipal()
        {
            Response.Redirect("~/admin/frmusers.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM users WHERE username = ? ";
                cmd.Parameters.Add("@username", OdbcType.VarChar).Value = txtusername.Value;
                cmd.Connection = new OdbcConnection(Utilities.ObtenerCadenaConexion());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                IrAlListadoPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO users ( username, password, roles) VALUES (?,?,?)";
                cmd.Parameters.Add("@username", OdbcType.VarChar).Value = txtusernameAdd.Value;
                cmd.Parameters.Add("@password", OdbcType.VarChar).Value = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpasswordAdd.Value, "SHA1");
                cmd.Parameters.Add("@roles", OdbcType.VarChar).Value = txtrolesAdd.Value;
                cmd.Connection = new OdbcConnection(Utilities.ObtenerCadenaConexion());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                IrAlListadoPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }

        protected void Valida_Codigo(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (args.Value.Length == 2 && EsNumerico(args.Value))
            {
                args.IsValid = true;
            }
        }

        private bool EsNumerico(string ValorIngresado)
        {
            bool esNumerico = false;
            try
            {
                long l = long.Parse(ValorIngresado);
                string s = l.ToString();
                if (string.Equals(s, ValorIngresado))
                {
                    esNumerico = true;
                }
            }
            catch { }
            return esNumerico;
        }

    }
}
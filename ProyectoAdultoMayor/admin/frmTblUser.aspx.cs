using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAdultoMayor
{
    public partial class frmTblUser : System.Web.UI.Page
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
            string UserName = Request.QueryString["Username"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_USER WHERE UserName = '{UserName}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtUserName.Value = dt.Rows[0]["UserName"].ToString();
            txtUserPassword.Value = dt.Rows[0]["UserPassword"].ToString();
            ckbactive.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                             UserName,
                                                             UserPassword,
                                                             iif(activo=0, 'NO', 'SI') AS activo 
                                                        FROM TBL_USER", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string Username = row.Cells[0].Text;

            Response.Redirect("~/admin/frmTblUser.aspx?cmd=edit&Username=" + Username);
        }

        protected void btnModificarIdUser_Click(object sender, EventArgs e)
        {
            string UserName = (Request.Form["ctl00$contenido$txtUserName"] != null) ? Request.Form["ctl00$contenido$txtUserName"].ToString() : "";
            string UserPassword = (Request.Form["ctl00$contenido$txtUserPassword"] != null) ? Request.Form["ctl00$contenido$txtUserPassword"].ToString() : "";
            string active = (Request.Form["ctl00$contenido$ckbactive"] != null) ? Request.Form["ctl00$contenido$ckbactive"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_USER 
                                SET 
                                    UserPassword=?,
                                    Activo=?
                                WHERE
                                    UserName=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("UserPassword", UserPassword));
            cmd.Parameters.Add(new OdbcParameter("Activo", (active == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("UserName", UserName));

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
            Response.Redirect("~/admin/frmTblUser.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_USER WHERE UserName = ? ";
                cmd.Parameters.Add("@UserName", OdbcType.VarChar).Value = txtUserName.Value;
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
                cmd.CommandText = "INSERT INTO TBL_USER ( UserName, UserPassword, Activo) VALUES (?,?,?)";
                cmd.Parameters.Add("@UserName", OdbcType.VarChar).Value = txtUserNameAdd.Value;
                cmd.Parameters.Add("@UserPassword", OdbcType.VarChar).Value = txtUserPasswordAdd.Value;
                cmd.Parameters.Add("@Activo", OdbcType.Bit).Value = ckbActiveAdd.Checked;
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
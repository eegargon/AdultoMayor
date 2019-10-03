using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAdultoMayor
{
    public partial class frmTblPiloto : System.Web.UI.Page
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
            string CUI = Request.QueryString["CUI"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_PILOTO WHERE Cui = '{CUI}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCui.Value = dt.Rows[0]["Cui"].ToString();
            txtNombre.Value = dt.Rows[0]["Nombre"].ToString();
            txtNit.Value = dt.Rows[0]["Nit"].ToString();
            txtLicencia.Value = dt.Rows[0]["Licencia"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT nombre, nit, licencia, cui, iif(activo=0, 'NO', 'SI') activo FROM TBL_PILOTO ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string CUI = row.Cells[0].Text;

            Response.Redirect("~/frmTblPiloto.aspx?cmd=edit&cui=" + CUI);
        }

        protected void btnModificarPiloto_Click(object sender, EventArgs e)
        {
            string cui = (Request.Form["ctl00$contenido$txtCui"] != null)?Request.Form["ctl00$contenido$txtCui"].ToString():"";
            string nombre = (Request.Form["ctl00$contenido$txtNombre"] != null)?Request.Form["ctl00$contenido$txtNombre"].ToString():"";
            string nit = (Request.Form["ctl00$contenido$txtNit"] != null)?Request.Form["ctl00$contenido$txtNit"].ToString():"";
            string licencia = (Request.Form["ctl00$contenido$txtLicencia"] != null) ?Request.Form["ctl00$contenido$txtLicencia"].ToString():"";
            string activo = (Request.Form["ctl00$contenido$ckbActivo"] != null)?Request.Form["ctl00$contenido$ckbActivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_PILOTO 
                                SET 
                                    Nombre=?,
                                    Nit=?,
                                    Licencia=?,
                                    Activo=?
                                WHERE
                                    Cui=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Nombre", nombre));
            cmd.Parameters.Add(new OdbcParameter("Nit", nit));
            cmd.Parameters.Add(new OdbcParameter("Licencia", licencia));
            cmd.Parameters.Add(new OdbcParameter("Activo", (activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("Cui", cui));

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
            Response.Redirect("~/frmTblPiloto.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_PILOTO WHERE cui = ? ";
                cmd.Parameters.Add("@CUI", OdbcType.VarChar).Value = txtCui.Value;
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

        protected void btnAgregarPiloto_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Tbl_Piloto (CUI, Nit, Nombre, Licencia, Activo) VALUES (?,?,?,?,?)";
                cmd.Parameters.Add("@CUI", OdbcType.VarChar).Value = txtCuiAdd.Value;
                cmd.Parameters.Add("@Nit", OdbcType.VarChar).Value = txtNitAdd.Value;
                cmd.Parameters.Add("@Nombre", OdbcType.VarChar).Value = txtNombreAdd.Value;
                cmd.Parameters.Add("@Licencia", OdbcType.VarChar).Value = txtLicenciaAdd.Value;
                cmd.Parameters.Add("@Activo", OdbcType.Bit).Value = ckbActivoAdd.Checked;
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (args.Value.Length == 13 && EsNumerico(args.Value))
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
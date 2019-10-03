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
    public partial class frmRefTipoFoto : System.Web.UI.Page
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
            string CodTipoFoto = Request.QueryString["CodTipoFoto"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM REF_TIPO_FOTO WHERE CodTipoFoto = '{CodTipoFoto}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCodTipoFoto.Value = dt.Rows[0]["CodTipoFoto"].ToString();
            txtTipoFoto.Value = dt.Rows[0]["TipoFoto"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT CodTipoFoto, TipoFoto,  iif(activo=0, 'NO', 'SI') activo FROM REF_TIPO_FOTO ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string CodTipoFoto = row.Cells[0].Text;

            Response.Redirect("~/frmRefTipoFoto.aspx?cmd=edit&CodTipoFoto=" + CodTipoFoto);
        }

        protected void btnModificarCodTipoFoto_Click(object sender, EventArgs e)
        {
            string CodTipoFoto = (Request.Form["ctl00$contenido$txtCodTipoFoto"] != null)?Request.Form["ctl00$contenido$txtCodTipoFoto"].ToString():"";
            string TipoFoto = (Request.Form["ctl00$contenido$txtTipoFoto"] != null)?Request.Form["ctl00$contenido$txtTipoFoto"].ToString():"";
            string Activo = (Request.Form["ctl00$contenido$ckbActivo"] != null)?Request.Form["ctl00$contenido$ckbActivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    REF_TIPO_FOTO 
                                SET 
                                    TipoFoto=?,
                                    Activo=?
                                WHERE
                                    CodTipoFoto=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("TipoFoto", TipoFoto));
            cmd.Parameters.Add(new OdbcParameter("Activo", (Activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("CodTipoFoto", CodTipoFoto));

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
            Response.Redirect("~/frmRefTipoFoto.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM REF_TIPO_FOTO WHERE CodTipoFoto = ? ";
                cmd.Parameters.Add("@CodTipoFoto", OdbcType.VarChar).Value = txtCodTipoFoto.Value;
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

        protected void btnAgregarCodTipoFoto_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO REF_TIPO_FOTO (CodTipoFoto, TipoFoto, Activo) VALUES (?,?,?)";
                cmd.Parameters.Add("@CodTipoFoto", OdbcType.VarChar).Value = txtCodTipoFotoAdd.Value;
                cmd.Parameters.Add("@TipoFoto", OdbcType.VarChar).Value = txtTipoFotoAdd.Value;
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
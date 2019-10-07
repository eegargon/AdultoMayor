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
    public partial class frmTblFoto : System.Web.UI.Page
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

            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Agregar)
            {
                CargarTipoFoto();
                CargarUnidad();             
            }

        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT IdFoto, Unidad, TipoFoto, imagen,  iif(activo=0, 'NO', 'SI') activo FROM TBL_FOTO", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void LoadData()
        {
            string IdFoto = Request.QueryString["IdFoto"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_FOTO WHERE IdFoto= '{IdFoto}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            txtIdFoto.Value = dt.Rows[0]["IdFoto"].ToString();
            txtUnidad.Value = dt.Rows[0]["Unidad"].ToString();
            txtTipoFoto.Value = dt.Rows[0]["TipoFoto"].ToString();
            txtimagen.Value = dt.Rows[0]["imagen"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string IdFoto = row.Cells[0].Text;

            Response.Redirect("~/admin/frmTblFoto.aspx?cmd=edit&IdFoto=" + IdFoto);
        }

        private void CargarTipoFoto()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select 
		                                                    CodTipoFoto, TipoFoto, 
		                                                    iif(Activo=0, 'NO', 'SI') active 
		                                                    from REF_TIPO_FOTO where Activo = 1",
                                                            Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);          
            txtTipoFotoAdd.DataValueField = "CodTipoFoto";
            txtTipoFotoAdd.DataTextField = "TipoFoto";
            txtTipoFotoAdd.DataSource = dt;
            txtTipoFotoAdd.DataBind();
        }

        private void CargarUnidad()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select 
		                                                    NoUNidad, NoUNidad, 
		                                                    iif(Activo=0, 'NO', 'SI') active 
		                                                    from TBL_BUSES where Activo = 1",
                                                            Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtUnidadAdd.DataValueField = "NoUNidad";
            txtUnidadAdd.DataTextField = "NoUNidad";
            txtUnidadAdd.DataSource = dt;
            txtUnidadAdd.DataBind();
        }
             

        protected void btnModificarIdFoto_Click(object sender, EventArgs e)
        {
            string IdFoto = (Request.Form["ctl00$contenido$txtIdFoto"] != null) ? Request.Form["ctl00$contenido$txtIdFoto"].ToString() : "";
            string Unidad = (Request.Form["ctl00$contenido$txtUnidad"] != null) ? Request.Form["ctl00$contenido$txtUnidad"].ToString() : "";
            string TipoFoto = (Request.Form["ctl00$contenido$txtTipoFoto"] != null) ? Request.Form["ctl00$contenido$txtTipoFoto"].ToString() : "";
            string imagen = (Request.Form["ctl00$contenido$txtimagen"] != null) ? Request.Form["ctl00$contenido$txtimagen"].ToString() : "";
            string Activo = (Request.Form["ctl00$contenido$ckbActivo"] != null) ? Request.Form["ctl00$contenido$ckbActivo"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_FOTO 
                                SET 
                                    Unidad=?,
                                    TipoFoto=?,
                                    imagen=?,
                                    Activo=?
                                WHERE
                                    IdFoto=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Unidad", Unidad));
            cmd.Parameters.Add(new OdbcParameter("TipoFoto", TipoFoto));
            cmd.Parameters.Add(new OdbcParameter("imagen", imagen));
            cmd.Parameters.Add(new OdbcParameter("Activo", (Activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("IdFoto", IdFoto));

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
            Response.Redirect("~/admin/frmTblFoto.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_FOTO WHERE IdFoto= ? ";
                cmd.Parameters.Add("@IdFoto", OdbcType.BigInt).Value = txtIdFoto.Value;
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

        protected void btnAgregarIdFoto_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO TBL_FOTO (Unidad, TipoFoto, imagen, Activo) VALUES (?,?,?,?)";                
                cmd.Parameters.Add("@Unidad", OdbcType.VarChar).Value = txtUnidadAdd.SelectedValue;
                cmd.Parameters.Add("@TipoFoto", OdbcType.Int).Value = txtTipoFotoAdd.SelectedValue;
                cmd.Parameters.Add("@imagen", OdbcType.VarChar).Value = txtimagenAdd.Value;
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
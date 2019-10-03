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
    public partial class frmTbl_Foto: System.Web.UI.Page
    {
        private object txtNoUNidadAdd;

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

            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Agregar)
            {
                CargarNoUNidad();
                }
            }
        }
        private void CargarTipoFoto() 

        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select CodTipoFoto, TipoFoto from REF_TIPO_FOTO where Activo=1 order by CodTipoFoto asc
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtTipoFotoAdd.DataTextField = "CodTipoFoto";
            txtTipoFotoAdd.DataTextField = "TipoFoto";
            txtTipoFotoAdd.DataSource = dt;
            txtTipoFotoAdd.DataBind();
        }
        private void CargarNoUNidad()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select NoUNidad, NoUNidad as Numero from TBL_BUSES where Activo=1 order by NoUNidad asc
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownNoUnidadAdd.DataTextField = "NoUNidad";
            DropDownNoUnidadAdd.DataTextField = "Numero";
            DropDownNoUnidadAdd.DataSource = dt;
            DropDownNoUnidadAdd.DataBind();
        }

        private void LoadData()
        {
            string IdFoto = Request.QueryString["IdFoto"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_FOTO WHERE IdFoto = '{IdFoto}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);        

            txtIdFoto.Value = dt.Rows[0]["IdFoto"].ToString();
            txtUnidad.Value = dt.Rows[0]["Unidad"].ToString();
            txtTipoFoto.Value = dt.Rows[0]["TipoFoto"].ToString();
            txtImagen.Value = dt.Rows[0]["Imagen"].ToString();
            ckbactive.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT IdFoto, Unidad, TipoFoto, Imagen, iif(activo=0, 'NO', 'SI') activo FROM TBL_Foto ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string IdFoto = row.Cells[0].Text;

            Response.Redirect("~/frmTbl_Foto.aspx?cmd=edit&IdFoto=" + IdFoto);
        }

        protected void btnModificarIdFoto_Click(object sender, EventArgs e)
        {
            string IdFoto = (Request.Form["ctl00$contenido$txtIdFoto"] != null) ? Request.Form["ctl00$contenido$txtIdFoto"].ToString() : "";
            string Unidad = (Request.Form["ctl00$contenido$txtUnidad"] != null) ? Request.Form["ctl00$contenido$txtUnidad"].ToString() : "";
            string TipoFoto = (Request.Form["ctl00$contenido$txtTipoFoto"] != null) ? Request.Form["ctl00$contenido$txtTipoFoto"].ToString() : "";
            string Imagen = (Request.Form["ctl00$contenido$txtImagen"] != null) ? Request.Form["ctl00$contenido$txtImagen"].ToString() : "";
            string active = (Request.Form["ctl00$contenido$ckbactive"] != null) ? Request.Form["ctl00$contenido$ckbactive"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    Tbl_Foto 
                                SET 
                                    IdFoto=?,
                                    Unidad=?,
                                    TipoFoto=?,
                                    Imagen=?,
                                    Activo=?
                                WHERE
                                    IdFoto=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("IdFoto", IdFoto));
            cmd.Parameters.Add(new OdbcParameter("Unidad", Unidad));
            cmd.Parameters.Add(new OdbcParameter("TipoFoto", TipoFoto));
            cmd.Parameters.Add(new OdbcParameter("Imagen", Imagen));
            cmd.Parameters.Add(new OdbcParameter("Activo", (active == "on") ? 1 : 0));
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
            Response.Redirect("~/admin/frmTbl_Foto.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM Tbl_Foto WHERE IdFoto = ? ";
                cmd.Parameters.Add("@IdFoto", OdbcType.VarChar).Value = txtIdFoto.Value;
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
                cmd.CommandText = "INSERT INTO Tbl_Foto (Unidad, TipoFoto, Imagen, Activo) VALUES (?,?,?,?)";
                cmd.Parameters.Add("@Unidad", OdbcType.VarChar).Value = DropDownNoUnidadAdd.SelectedValue;
                cmd.Parameters.Add("@TipoFoto", OdbcType.VarChar).Value = txtTipoFotoAdd.SelectedValue;
                cmd.Parameters.Add("@Imagen", OdbcType.VarChar).Value = txtImagenAdd.Value;
                cmd.Parameters.Add("@Active", OdbcType.Bit).Value = ckbActiveAdd.Checked;
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

        protected void Valida_IdFoto(object source, ServerValidateEventArgs args)
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
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
    public partial class frmTblLector : System.Web.UI.Page
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
            string Lector = Request.QueryString["Lector"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_LECTOR WHERE Lector = '{Lector}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtLector.Value = dt.Rows[0]["Lector"].ToString();
            txtNoSerie.Value = dt.Rows[0]["NoSerie"].ToString();
            txtModelo.Value = dt.Rows[0]["Modelo"].ToString();
            txtColorFOB.Value = dt.Rows[0]["ColorFOB"].ToString();
            txtInstalada.Value = dt.Rows[0]["Instalada"].ToString();
            txtControlInventario.Value = dt.Rows[0]["ControlInventario"].ToString();
            txtUbicacion.Value = dt.Rows[0]["Ubicacion"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT Lector, NoSerie, Modelo, ColorFOB, Instalada,ControlInventario, Ubicacion, iif(Activo=0, 'NO', 'SI') activo FROM TBL_LECTOR ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string Lector = row.Cells[0].Text;

            Response.Redirect("~/frmTblLector.aspx?cmd=edit&Lector=" + Lector);
        }

        protected void btnModificarLector_Click(object sender, EventArgs e)
        {
            string Lector = (Request.Form["ctl00$contenido$txtLector"] != null)?Request.Form["ctl00$contenido$txtLector"].ToString():"";
            string NoSerie = (Request.Form["ctl00$contenido$txtNoSerie"] != null)?Request.Form["ctl00$contenido$txtNoSerie"].ToString():"";
            string Modelo = (Request.Form["ctl00$contenido$txtModelo"] != null)?Request.Form["ctl00$contenido$txtModelo"].ToString():"";
            string ColorFOB = (Request.Form["ctl00$contenido$txtColorFOB"] != null) ? Request.Form["ctl00$contenido$txtColorFOB"].ToString() : "";
            string Instalado = (Request.Form["ctl00$contenido$txtInstalada"] != null) ? Request.Form["ctl00$contenido$txtInstalada"].ToString() : "";
            string ControlInventario = (Request.Form["ctl00$contenido$txtControlInventario"] != null) ? Request.Form["ctl00$contenido$txtControlInventario"].ToString() : "";
            string Ubicacion = (Request.Form["ctl00$contenido$txtUbicacion"] != null) ? Request.Form["ctl00$contenido$txtUbicacion"].ToString() : "";
            string Activo = (Request.Form["ctl00$contenido$ckbactivo"] != null)?Request.Form["ctl00$contenido$ckbactivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_LECTOR 
                                SET 
                                    NoSerie=?,
                                    Modelo=?,
                                    ColorFOB=?,
                                    Instalada=?,
                                    ControlInventario=?,
                                    Ubicacion=?,
                                    Activo=?
                                WHERE
                                    Lector=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("NoSerie", NoSerie));
            cmd.Parameters.Add(new OdbcParameter("Modelo", Modelo));
            cmd.Parameters.Add(new OdbcParameter("ColorFOB", ColorFOB));
            cmd.Parameters.Add(new OdbcParameter("Instalado", Instalado));
            cmd.Parameters.Add(new OdbcParameter("ControlInventario", ControlInventario));
            cmd.Parameters.Add(new OdbcParameter("Ubicacion", Ubicacion));
            cmd.Parameters.Add(new OdbcParameter("Activo", (Activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("Lector", Lector));

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
            Response.Redirect("~/frmTblLector.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_LECTOR WHERE Lector = ? ";
                cmd.Parameters.Add("@Lector", OdbcType.VarChar).Value = txtLector.Value;
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

        protected void btnAgregarLector_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO TBL_LECTOR (Lector, NoSerie, Modelo,ColorFOB,Instalada,ControlInventario,Ubicacion, Activo) VALUES (?,?,?,?,?,?,?,?)";
                cmd.Parameters.Add("@Lector", OdbcType.VarChar).Value = txtLectorAdd.Value;
                cmd.Parameters.Add("@NoSerie", OdbcType.VarChar).Value = txtNoSerieAdd.Value;
                cmd.Parameters.Add("@Modelo", OdbcType.VarChar).Value = txtModeloAdd.Value;
                cmd.Parameters.Add("@ColorFOB", OdbcType.VarChar).Value = txtColorFOBAdd.Value;
                cmd.Parameters.Add("@Instalada", OdbcType.VarChar).Value = txtInstaladaAdd.Value;
                cmd.Parameters.Add("@ControlInventario", OdbcType.VarChar).Value = txtControlInventarioAdd.Value;
                cmd.Parameters.Add("@Ubicacion", OdbcType.VarChar).Value = txtUbicacionAdd.Value;
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
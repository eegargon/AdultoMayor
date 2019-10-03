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
    public partial class frmTblSim : System.Web.UI.Page
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
                string SIM = Request.QueryString["SIM"];
                OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_SIM WHERE SIM = '{SIM}' ", Utilities.ObtenerCadenaConexion());
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtSIM.Value = dt.Rows[0]["SIM"].ToString();
                txtNoTelefono.Value = dt.Rows[0]["NoTelefono"].ToString();
                txtModelo.Value = dt.Rows[0]["Modelo"].ToString();
                txtOperador.Value = dt.Rows[0]["Operador"].ToString();
                txtColorFOB.Value = dt.Rows[0]["ColorFOB"].ToString();
                txtInstalado.Value = dt.Rows[0]["Instalado"].ToString();
                txtCostoInventario.Value = dt.Rows[0]["CostoInventario"].ToString();
                txtUbicacion.Value = dt.Rows[0]["Ubicacion"].ToString();
                ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
            }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT SIM, NoTelefono, Modelo, Operador, ColorFOB, Instalado,CostoInventario, Ubicacion, iif(activo=0, 'NO', 'SI') activo FROM TBL_SIM ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string SIM = row.Cells[0].Text;

            Response.Redirect("~/frmTblSim.aspx?cmd=edit&SIM=" + SIM);
        }

        protected void btnModificarSIM_Click(object sender, EventArgs e)
        {
            string SIM = (Request.Form["ctl00$contenido$txtSim"] != null)?Request.Form["ctl00$contenido$txtSim"].ToString():"";
            string NoTelefono = (Request.Form["ctl00$contenido$txtNoTelefono"] != null)?Request.Form["ctl00$contenido$txtNoTelefono"].ToString():"";
            string Modelo = (Request.Form["ctl00$contenido$txtModelo"] != null)?Request.Form["ctl00$contenido$txtModelo"].ToString():"";
            string Operador = (Request.Form["ctl00$contenido$txtOperador"] != null) ?Request.Form["ctl00$contenido$txtOperador"].ToString():"";
            string ColorFOB = (Request.Form["ctl00$contenido$txtColorFOB"] != null) ? Request.Form["ctl00$contenido$txtColorFOB"].ToString() : "";
            string Instalado = (Request.Form["ctl00$contenido$txtInstalado"] != null) ? Request.Form["ctl00$contenido$txtInstalado"].ToString() : "";
            string CostoInventario = (Request.Form["ctl00$contenido$txtCostoInventario"] != null) ? Request.Form["ctl00$contenido$txtCostoInventario"].ToString() : "";
            string Ubicacion = (Request.Form["ctl00$contenido$txtUbicacion"] != null) ? Request.Form["ctl00$contenido$txtUbicacion"].ToString() : "";
            string activo = (Request.Form["ctl00$contenido$ckbActivo"] != null)?Request.Form["ctl00$contenido$ckbActivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_SIM 
                                SET 
                                    NoTelefono=?,
                                    Modelo=?,
                                    Operador=?,
                                    ColorFOB=?,
                                    Instalado=?,
                                    CostoInventario=?,
                                    Ubicacion=?,
                                    Activo=?
                                WHERE
                                    SIM=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("NoTelefono", NoTelefono));
            cmd.Parameters.Add(new OdbcParameter("Modelo", Modelo));
            cmd.Parameters.Add(new OdbcParameter("Operador", Operador));
            cmd.Parameters.Add(new OdbcParameter("ColorFOB", ColorFOB));
            cmd.Parameters.Add(new OdbcParameter("Instalado", Instalado));
            cmd.Parameters.Add(new OdbcParameter("CostoInventario", CostoInventario));
            cmd.Parameters.Add(new OdbcParameter("Ubicacion", Ubicacion));
            cmd.Parameters.Add(new OdbcParameter("Activo", (activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("SIM", SIM));

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
            Response.Redirect("~/frmTblSim.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_SIM WHERE SIM = ? ";
                cmd.Parameters.Add("@SIM", OdbcType.VarChar).Value = txtSIM.Value;
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

        protected void btnAgregarSIM_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Tbl_SIM (SIM, Modelo, NoTelefono, Operador,ColorFOB,Instalado,CostoInventario,Ubicacion, Activo) VALUES (?,?,?,?,?,?,?,?,?)";
                cmd.Parameters.Add("@SIM", OdbcType.VarChar).Value = txtSIMAdd.Value;
                cmd.Parameters.Add("@Modelo", OdbcType.VarChar).Value = txtModeloAdd.Value;
                cmd.Parameters.Add("@NoTelefono", OdbcType.VarChar).Value = txtNoTelefonoAdd.Value;
                cmd.Parameters.Add("@Operador", OdbcType.VarChar).Value = txtOperadorAdd.Value;
                cmd.Parameters.Add("@ColorFOB", OdbcType.VarChar).Value = txtColorFOBAdd.Value;
                cmd.Parameters.Add("@Instalado", OdbcType.VarChar).Value = txtInstaladoAdd.Value;
                cmd.Parameters.Add("@CostoInventario", OdbcType.VarChar).Value = txtCostoInventarioAdd.Value;
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
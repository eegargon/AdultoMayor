using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAdultoMayor
{
    public partial class frmTblSimBus : System.Web.UI.Page
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
                // Cargar el combo de buses
                CargarBuses();
                CargarSIM();
            }
        }

        private void CargarSIM()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            s.SIM, 
                                                            CONCAT(
																IIF(isnull(s.SIM,'') = '', 'SINNoSIM', s.SIM),' - ', 
																IIF(isnull(s.NoTelefono,'') = '', 'SINNoTelefono', s.NoTelefono)
															) AS telefono, 
                                                            iif(activo IS NULL OR activo=0, 'NO', 'SI') activo 
                                                        FROM TBL_SIM s
                                                        WHERE s.Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtSIMAdd.DataValueField = "SIM";
            txtSIMAdd.DataTextField = "telefono";
            txtSIMAdd.DataSource = dt;
            txtSIMAdd.DataBind();
        }

        private void CargarBuses()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            b.NoUnidad, 
                                                            CONCAT(
																IIF(isnull(b.NoUnidad,'') = '', 'SINNoUNIDAD', b.NoUnidad),' - ', 
																IIF(isnull(b.Marca,'') = '', 'SINMARCA', b.Marca),' - ', 
																IIF(isnull(b.Ano,0) = 0, 1900, b.Ano),' - ', 
																IIF(isnull(b.NoPlaca,'') = '', 'SINPLACA', b.NoPlaca)
															) AS Unidad, 
                                                            iif(activo IS NULL OR activo=0, 'NO', 'SI') activo 
                                                        FROM TBL_BUSES b
                                                        WHERE b.Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtUnidadAdd.DataValueField = "NoUnidad";
            txtUnidadAdd.DataTextField = "Unidad";
            txtUnidadAdd.DataSource = dt;
            txtUnidadAdd.DataBind();
        }

        private void LoadData()
        {
            string SIM = Request.QueryString["SIM"];
            string Unidad = Request.QueryString["UNIDAD"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT SIM, 
                                                             Unidad,                                                                
                                                             Activo
                                                        FROM TBL_SIM_BUS 
                                                        WHERE SIM = '{SIM}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtSIM.Text = dt.Rows[0]["SIM"].ToString();
            txtUnidad.Text = dt.Rows[0]["Unidad"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            // Cargar el grid
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT 
                                                            sb.SIM, 
                                                            sb.Unidad,
                                                            iif(sb.activo=0, 'NO', 'SI') AS activo 
                                                        FROM TBL_SIM_BUS sb
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string SIM = row.Cells[0].Text;
            string Unidad = row.Cells[1].Text;

            Response.Redirect("~/frmTblSimBus.aspx?cmd=edit&SIM=" + SIM + "&Unidad=" + Unidad);
        }

        protected void btnModificarSIM_Click(object sender, EventArgs e)
        {
            string SIM = (Request.Form["ctl00$contenido$txtSim"] != null)?Request.Form["ctl00$contenido$txtSim"].ToString():"";
            string Unidad = (Request.Form["ctl00$contenido$txtUnidad"] != null)?Request.Form["ctl00$contenido$txtUnidad"].ToString():"";
            string activo = (Request.Form["ctl00$contenido$ckbactivo"] != null)?Request.Form["ctl00$contenido$ckbactivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_SIM_BUS 
                                SET 
                                    Activo=?
                                WHERE
                                    SIM=?
                                AND
                                    Unidad=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Activo", (activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("SIM", SIM));
            cmd.Parameters.Add(new OdbcParameter("Unidad", Unidad));

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
            Response.Redirect("~/admin/frmTblSimBus.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_SIM_BUS WHERE SIM = ? and Unidad = ?";
                cmd.Parameters.Add("@SIM", OdbcType.VarChar).Value = txtSIM.Text;
                cmd.Parameters.Add("@Unidad", OdbcType.VarChar).Value = txtUnidad.Text;
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
                cmd.CommandText = "INSERT INTO TBL_SIM_BUS (SIM, Unidad,  Activo) VALUES (?,?,?)";
                cmd.Parameters.Add("@SIM", OdbcType.VarChar).Value = txtSIMAdd.SelectedValue;
                cmd.Parameters.Add("@Unidad", OdbcType.VarChar).Value = txtUnidadAdd.SelectedValue;
                cmd.Parameters.Add("@Activo", OdbcType.Bit).Value = ckbActivoAdd.Checked;
                cmd.Connection = new OdbcConnection(Utilities.ObtenerCadenaConexion());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                IrAlListadoPrincipal();
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.ErrorCode == -2146232009)
                {
                    lblError.Text = "La Combinaci&oacute;n de SIM y Unidad ya fue Definida por lo que no se puede agregar Nuevamente";
                }
                if (cmd.Connection.State == ConnectionState.Open)
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
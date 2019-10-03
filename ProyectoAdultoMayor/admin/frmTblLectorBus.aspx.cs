using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAdultoMayor
{
    public partial class frmTblLectorBus : System.Web.UI.Page
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
                CargarLector();
            }
        }

        private void CargarLector()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select Lector, NoSerie from TBL_LECTOR where activo=1 order by NoSerie asc
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtLectorAdd.DataValueField = "Lector";
            txtLectorAdd.DataTextField = "NoSerie";
            txtLectorAdd.DataSource = dt;
            txtLectorAdd.DataBind();
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
            txtBusAdd.DataValueField = "NoUnidad";
            txtBusAdd.DataTextField = "Unidad";
            txtBusAdd.DataSource = dt;
            txtBusAdd.DataBind();
        }

        private void LoadData()
        {
            string Lector = Request.QueryString["LECTOR"];
            string Unidad = Request.QueryString["UNIDAD"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT Lector, 
                                                             Bus,
                                                             Estatus,
                                                             Activo
                                                        FROM TBL_LECTOR_BUS 
                                                        WHERE Lector = '{Lector}' AND Bus = '{Unidad}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtLector.Text = dt.Rows[0]["Lector"].ToString();
            txtUnidad.Text = dt.Rows[0]["Bus"].ToString();
            txtEstatus.Text = dt.Rows[0]["Estatus"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            // Cargar el grid
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT Lector, 
                                                             Bus,
                                                             Estatus,
                                                             iif(activo=0, 'NO', 'SI') AS activo 
                                                        FROM TBL_LECTOR_BUS
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string Lector = row.Cells[0].Text;
            string Unidad = row.Cells[1].Text;

            Response.Redirect("~/frmTblLectorBus.aspx?cmd=edit&Lector=" + Lector + "&Unidad=" + Unidad);
        }

        protected void btnModificarSIM_Click(object sender, EventArgs e)
        {
            string Lector = (Request.Form["ctl00$contenido$txtLector"] != null) ? Request.Form["ctl00$contenido$txtLector"].ToString() : "";
            string Unidad = (Request.Form["ctl00$contenido$txtUnidad"] != null) ? Request.Form["ctl00$contenido$txtUnidad"].ToString() : "";
            string Estatus = (Request.Form["ctl00$contenido$txtEstatus"] != null) ? Request.Form["ctl00$contenido$txtEstatus"].ToString() : "";
            string activo = (Request.Form["ctl00$contenido$ckbactivo"] != null) ? Request.Form["ctl00$contenido$ckbactivo"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_LECTOR_BUS 
                                SET 
                                    Activo=?,
                                    Estatus=?
                                WHERE
                                    Lector=?
                                AND Bus=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Activo", (activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("Estatus", Estatus));
            cmd.Parameters.Add(new OdbcParameter("Lector", Lector));
            cmd.Parameters.Add(new OdbcParameter("Bus", Unidad));

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
            Response.Redirect("~/admin/frmTblLectorBus.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_LECTOR_BUS WHERE LECTOR = ? and Bus = ?";
                cmd.Parameters.Add("@Lector", OdbcType.VarChar).Value = txtLector.Text;
                cmd.Parameters.Add("@Bus", OdbcType.VarChar).Value = txtUnidad.Text;
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

        protected void btnAgregarLectorBus_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO TBL_LECTOR_BUS (Lector, Bus, Estatus, Activo) VALUES (?,?,?,?)";
                cmd.Parameters.Add("@Lector", OdbcType.VarChar).Value = txtLectorAdd.SelectedValue;
                cmd.Parameters.Add("@Bus", OdbcType.VarChar).Value = txtBusAdd.SelectedValue;
                cmd.Parameters.Add("@Estatus", OdbcType.VarChar).Value = txtEstatusAdd.Text;
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
                    lblError.Text = "La Combinaci&oacute;n de Lector y Unidad ya fue Definida por lo que no se puede agregar Nuevamente";
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
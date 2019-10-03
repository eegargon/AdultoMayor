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
    public partial class frmTblInfo : System.Web.UI.Page
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
            string IdInfo = Request.QueryString["IdInfo"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_INFO WHERE IdInfo = '{IdInfo}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtIdInfo.Value = dt.Rows[0]["IdInfo"].ToString();
            txtBus.Value = dt.Rows[0]["Bus"].ToString();
            txtDepto.Value = dt.Rows[0]["Depto"].ToString();
            txtMuni.Value = dt.Rows[0]["Muni"].ToString();
            txtRuta.Value = dt.Rows[0]["Ruta"].ToString();
            txtMRZ.Value = dt.Rows[0]["MRZ"].ToString();
            txtDPI.Value = dt.Rows[0]["DPI"].ToString();
            txtNombre.Value = dt.Rows[0]["Nombre"].ToString();
            txtApellido.Value = dt.Rows[0]["Apellido"].ToString();
            txtFechaNac.Value = dt.Rows[0]["FechaNac"].ToString();
            txtAbordaje.Value = dt.Rows[0]["Abordaje"].ToString();
            ckbactive.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                             IdInfo,
                                                             Bus,
                                                             Depto,
                                                             Muni,
                                                             Ruta,
                                                             MRZ,
                                                             DPI,
                                                             Nombre,
                                                             Apellido,
                                                             FechaNac,
                                                             Abordaje,                                                                                                                          
                                                             iif(activo=0, 'NO', 'SI') AS activo 
                                                        FROM TBL_INFO", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string IdInfo = row.Cells[0].Text;

            Response.Redirect("~/frmTblInfo.aspx?cmd=edit&IdInfo=" + IdInfo);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string IdInfo = (Request.Form["ctl00$contenido$txtIdInfo"] != null) ? Request.Form["ctl00$contenido$txtIdInfo"].ToString() : "";
            string Bus = (Request.Form["ctl00$contenido$txtBus"] != null) ? Request.Form["ctl00$contenido$txtBus"].ToString() : "";
            string Depto = (Request.Form["ctl00$contenido$txtDepto"] != null) ? Request.Form["ctl00$contenido$txtDepto"].ToString() : "";
            string Muni = (Request.Form["ctl00$contenido$txtMuni"] != null) ? Request.Form["ctl00$contenido$txtMuni"].ToString() : "";
            string Ruta = (Request.Form["ctl00$contenido$txtRuta"] != null) ? Request.Form["ctl00$contenido$txtRuta"].ToString() : "";
            string MRZ = (Request.Form["ctl00$contenido$txtMRZ"] != null) ? Request.Form["ctl00$contenido$txtMRZ"].ToString() : "";
            string DPI = (Request.Form["ctl00$contenido$txtDPI"] != null) ? Request.Form["ctl00$contenido$txtDPI"].ToString() : "";
            string Nombre = (Request.Form["ctl00$contenido$txtNombre"] != null) ? Request.Form["ctl00$contenido$txtNombre"].ToString() : "";
            string Apellido = (Request.Form["ctl00$contenido$txtApellido"] != null) ? Request.Form["ctl00$contenido$txtApellido"].ToString() : "";
            string FechaNac = (Request.Form["ctl00$contenido$txtFechaNac"] != null) ? Request.Form["ctl00$contenido$txtFechaNac"].ToString() : "";
            string Abordaje = (Request.Form["ctl00$contenido$txtAbordaje"] != null) ? Request.Form["ctl00$contenido$txtAbordaje"].ToString() : "";
            string active = (Request.Form["ctl00$contenido$ckbactive"] != null) ? Request.Form["ctl00$contenido$ckbactive"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_INFO
                                SET 
                                    Bus=?,
                                    Depto=?,
                                    Muni=?,
                                    Ruta=?,
                                    MRZ=?,
                                    DPI=?,
                                    Nombre=?,
                                    Apellido=?,
                                    FechaNac=?,
                                    Abordaje=?,
                                    Activo=?
                                WHERE
                                    IdInfo=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Bus", Bus));
            cmd.Parameters.Add(new OdbcParameter("Depto", Depto));
            cmd.Parameters.Add(new OdbcParameter("Muni", Muni));
            cmd.Parameters.Add(new OdbcParameter("Ruta", Ruta));
            cmd.Parameters.Add(new OdbcParameter("MRZ", MRZ));
            cmd.Parameters.Add(new OdbcParameter("DPI", DPI));
            cmd.Parameters.Add(new OdbcParameter("Nombre", Nombre));
            cmd.Parameters.Add(new OdbcParameter("Apellido", Apellido));
            cmd.Parameters.Add(new OdbcParameter("FechaNac", FechaNac));
            cmd.Parameters.Add(new OdbcParameter("Abordaje", Abordaje));
            cmd.Parameters.Add(new OdbcParameter("Activo", (active == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("IdInfo", IdInfo));

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
            Response.Redirect("~/frmTblInfo.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_INFO WHERE IdInfo = ? ";
                cmd.Parameters.Add("@IdInfo", OdbcType.BigInt).Value = txtIdInfo.Value;
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
                cmd.CommandText = "INSERT INTO TBL_INFO (Bus, Depto, Muni, Ruta, MRZ, DPI, Nombre, Apellido, FechaNac, Abordaje, Activo) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.Parameters.Add("@Bus", OdbcType.VarChar).Value = txtBusAdd.Value;
                cmd.Parameters.Add("@Depto", OdbcType.VarChar).Value = txtDeptoAdd.Value;
                cmd.Parameters.Add("@Muni", OdbcType.VarChar).Value = txtMuniAdd.Value;
                cmd.Parameters.Add("@Ruta", OdbcType.VarChar).Value = txtRutaAdd.Value;
                cmd.Parameters.Add("@MRZ", OdbcType.VarChar).Value = txtMRZAdd.Value;
                cmd.Parameters.Add("@DPI", OdbcType.VarChar).Value = txtDPIAdd.Value;
                cmd.Parameters.Add("@Nombre", OdbcType.VarChar).Value = txtNombreAdd.Value;
                cmd.Parameters.Add("@Apellido", OdbcType.VarChar).Value = txtApellidoAdd.Value;
                cmd.Parameters.Add("@FechaNac", OdbcType.DateTime).Value = txtFechaNacAdd.Value;
                cmd.Parameters.Add("@Abordaje", OdbcType.DateTime).Value = txtAbordajeAdd.Value;
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
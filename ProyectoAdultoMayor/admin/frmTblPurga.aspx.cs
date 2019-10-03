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
    public partial class frmTblPurga : System.Web.UI.Page
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
            string IdPurga = Request.QueryString["IdPurga"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_PURGA WHERE IdPurga = '{IdPurga}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtIdPurga.Value = dt.Rows[0]["IdPurga"].ToString();
            txtNoUnidad.Value = dt.Rows[0]["NoUnidad"].ToString();
            txtDpi.Value = dt.Rows[0]["Dpi"].ToString();
            txtNombre.Value = dt.Rows[0]["Nombre"].ToString();
            txtApellido.Value = dt.Rows[0]["Apellido"].ToString();
            txtFechaNac.Value = dt.Rows[0]["FechaNac"].ToString();
            txtEdad.Value = dt.Rows[0]["Edad"].ToString();
            txtFechaAbordaje.Value = dt.Rows[0]["FechaAbordaje"].ToString();
            txtMRZ.Value = dt.Rows[0]["MRZ"].ToString();
            txtLatitud.Value = dt.Rows[0]["Latitud"].ToString();
            txtLongitud.Value = dt.Rows[0]["Longitud"].ToString();
            ckbactive.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                             IdPurga,
                                                             NoUnidad,
                                                             Dpi,
                                                             Nombre,
                                                             Apellido,
                                                             FechaNac,
                                                             Edad,
                                                             FechaAbordaje,
                                                             MRZ,
                                                             Latitud,
                                                             Longitud,                                                                                                                          
                                                             iif(activo=0, 'NO', 'SI') AS activo 
                                                        FROM TBL_PURGA", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string IdPurga = row.Cells[0].Text;

            Response.Redirect("~/frmTblPurga.aspx?cmd=edit&IdPurga=" + IdPurga);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string IdPurga = (Request.Form["ctl00$contenido$txtIdPurga"] != null) ? Request.Form["ctl00$contenido$txtIdPurga"].ToString() : "";
            string NoUnidad = (Request.Form["ctl00$contenido$txtNoUnidad"] != null) ? Request.Form["ctl00$contenido$txtNoUnidad"].ToString() : "";
            string Dpi = (Request.Form["ctl00$contenido$txtDpi"] != null) ? Request.Form["ctl00$contenido$txtDpi"].ToString() : "";
            string Nombre = (Request.Form["ctl00$contenido$txtNombre"] != null) ? Request.Form["ctl00$contenido$txtNombre"].ToString() : "";
            string Apellido = (Request.Form["ctl00$contenido$txtApellido"] != null) ? Request.Form["ctl00$contenido$txtApellido"].ToString() : "";
            string FechaNac = (Request.Form["ctl00$contenido$txtFechaNac"] != null) ? Request.Form["ctl00$contenido$txtFechaNac"].ToString() : "";
            string Edad = (Request.Form["ctl00$contenido$txtEdad"] != null) ? Request.Form["ctl00$contenido$txtEdad"].ToString() : "";
            string FechaAbordaje = (Request.Form["ctl00$contenido$txtFechaAbordaje"] != null) ? Request.Form["ctl00$contenido$txtFechaAbordaje"].ToString() : "";
            string MRZ = (Request.Form["ctl00$contenido$txtMRZ"] != null) ? Request.Form["ctl00$contenido$txtMrz"].ToString() : "";
            string Latitud = (Request.Form["ctl00$contenido$txtLatitud"] != null) ? Request.Form["ctl00$contenido$txtLatitud"].ToString() : "";
            string Longitud = (Request.Form["ctl00$contenido$txtLongitud"] != null) ? Request.Form["ctl00$contenido$txtLongitud"].ToString() : "";
            string active = (Request.Form["ctl00$contenido$ckbactive"] != null) ? Request.Form["ctl00$contenido$ckbactive"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_PURGA
                                SET 
                                    NoUnidad=?,
                                    Dpi=?,
                                    Nombre=?,
                                    Apellido=?,
                                    FechaNac=?,
                                    Edad=?,
                                    FechaAbordaje=?,
                                    Mrz=?,
                                    Latitud=?,
                                    Longitud=?,
                                    Activo=?
                                WHERE
                                    IdPurga=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("NoUnidad", NoUnidad));
            cmd.Parameters.Add(new OdbcParameter("Dpi", Dpi));
            cmd.Parameters.Add(new OdbcParameter("Nombre", Nombre));
            cmd.Parameters.Add(new OdbcParameter("Apellido", Apellido));
            cmd.Parameters.Add(new OdbcParameter("FechaNac", FechaNac));
            cmd.Parameters.Add(new OdbcParameter("Edad", Edad));
            cmd.Parameters.Add(new OdbcParameter("FechaAbordaje", FechaAbordaje));
            cmd.Parameters.Add(new OdbcParameter("MRZ", MRZ));
            cmd.Parameters.Add(new OdbcParameter("Latitud", Latitud));
            cmd.Parameters.Add(new OdbcParameter("Longitud", Longitud));
            cmd.Parameters.Add(new OdbcParameter("Activo", (active == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("IdPurga", IdPurga));

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
            Response.Redirect("~/admin/frmTblPurga.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_PURGA WHERE IdPurga = ? ";
                cmd.Parameters.Add("@IdPurga", OdbcType.VarChar).Value = txtIdPurga.Value;
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
                cmd.CommandText = "INSERT INTO TBL_Purga (NoUnidad, Dpi, Nombre, Apellido, FechaNac, Edad, FechaAbordaje, MRZ, Latitud, Longitud, Activo) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.Parameters.Add("@NoUnidad", OdbcType.VarChar).Value = txtNoUnidadAdd.Value;
                cmd.Parameters.Add("@Dpi", OdbcType.VarChar).Value = txtDpiAdd.Value;
                cmd.Parameters.Add("@Nombre", OdbcType.VarChar).Value = txtNombreAdd.Value;
                cmd.Parameters.Add("@Apellido", OdbcType.VarChar).Value = txtApellidoAdd.Value;
                cmd.Parameters.Add("@FechaNac", OdbcType.DateTime).Value = txtFechaNacAdd.Value;
                cmd.Parameters.Add("@Edad", OdbcType.Int).Value = txtEdadAdd.Value;
                cmd.Parameters.Add("@FechaAbordaje", OdbcType.DateTime).Value = txtFechaAbordajeAdd.Value;
                cmd.Parameters.Add("@MRZ", OdbcType.VarChar).Value = txtMRZAdd.Value;
                cmd.Parameters.Add("@Latitud", OdbcType.Double).Value = txtLatitudAdd.Value;
                cmd.Parameters.Add("@Longitud", OdbcType.Double).Value = txtLongitudAdd.Value;
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
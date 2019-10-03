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
    public partial class frmTblTransaccion : System.Web.UI.Page
    {
        private object txtDpiAdd;
        private object txtLatitudAdd;
        private object txtLongitudAdd;

        public object MrzAdd { get; private set; }
        public OdbcConnection NoUnidad { get; private set; }

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
            string NoUnidad = Request.QueryString["NoUnidad"];
            string strFechaAbordaje = Request.QueryString["FechaAbordaje"];
            DateTime FechaAbordaje = DateTime.ParseExact(strFechaAbordaje, "dd/MM/yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);


            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_Transaccion WHERE NoUnidad = '{NoUnidad}' AND FechaAbordaje = '{FechaAbordaje.ToString("yyyy-MM-dd HH:mm:ss")}'", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtNoUnidad.Value = dt.Rows[0]["NoUnidad"].ToString();
            txtDpi.Value = dt.Rows[0]["Dpi"].ToString();
            txtNombre.Value = dt.Rows[0]["Nombre"].ToString();
            txtApellido.Value = dt.Rows[0]["Apellido"].ToString();
            txtFechaNac.Value = dt.Rows[0]["FechaNac"].ToString();
            txtEdad.Value = dt.Rows[0]["Edad"].ToString();
            txtFechaAbordaje.Value = dt.Rows[0]["FechaAbordaje"].ToString();
            txtMrz.Value = dt.Rows[0]["Mrz"].ToString();
            txtLatitud.Value = dt.Rows[0]["Latitud"].ToString();
            txtLongitud.Value = dt.Rows[0]["Longitud"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT NoUnidad, DPI, Nombre, Apellido, FechaNac, Edad, convert(varchar, FechaAbordaje, 20) AS FechaAbordaje, Mrz, Latitud, Longitud,  iif(activo=0, 'NO', 'SI') activo FROM TBL_TRANSACCION ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string NoUnidad = row.Cells[0].Text;
            string strFechaAbordaje = row.Cells[6].Text;

            DateTime FechaAbordaje = DateTime.ParseExact(strFechaAbordaje, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

            Response.Redirect("~/frmTblTransaccion.aspx?cmd=edit&NoUnidad=" + NoUnidad + "&FechaAbordaje=" + FechaAbordaje);
        }

        protected void btnModificarTransaccion_Click(object sender, EventArgs e)
        {
            string NoUnidad = (Request.Form["ctl00$contenido$txtNoUnidad"] != null) ? Request.Form["ctl00$contenido$txtNoUnidad"].ToString() : "";
            string Dpi = (Request.Form["ctl00$contenido$txtDpi"] != null) ? Request.Form["ctl00$contenido$txtDpi"].ToString() : "";
            string Nombre = (Request.Form["ctl00$contenido$txtNombre"] != null) ? Request.Form["ctl00$contenido$txtNombre"].ToString() : "";
            string Apellido = (Request.Form["ctl00$contenido$txtApellido"] != null) ? Request.Form["ctl00$contenido$txtApellido"].ToString() : "";
            string FechaNac = (Request.Form["ctl00$contenido$txtFechaNac"] != null) ? Request.Form["ctl00$contenido$txtFechaNac"].ToString() : "";
            string Edad = (Request.Form["ctl00$contenido$txtEdad"] != null) ? Request.Form["ctl00$contenido$txtEdad"].ToString() : "";
            string FechaAbordaje = (Request.Form["ctl00$contenido$txtFechaAbordaje"] != null) ? Request.Form["ctl00$contenido$txtFechaAbordaje"].ToString() : "";
            string Mrz = (Request.Form["ctl00$contenido$txtMrz"] != null) ? Request.Form["ctl00$contenido$txtMrz"].ToString() : "";
            string Latitud = (Request.Form["ctl00$contenido$txtLatitud"] != null) ? Request.Form["ctl00$contenido$txtLatitud"].ToString() : "";
            string Longitud = (Request.Form["ctl00$contenido$txtLongitud"] != null) ? Request.Form["ctl00$contenido$txtLongitud"].ToString() : "";
            string activo = (Request.Form["ctl00$contenido$ckbActivo"] != null) ? Request.Form["ctl00$contenido$ckbActivo"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_Transaccion 
                                SET 
                                    NoUnidad=?,
                                    Dpi=?,
                                    Nombre=?,
                                    Apellido=?,
                                    FechaNac=?,
                                    Edad=?,
                                    FechaAbordaje=?,
                                    Latitud=?,
                                    Longitud=?, 
                                   Activo=?
                                WHERE
                                    NoUnidad=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("NoUnidad", NoUnidad));
            cmd.Parameters.Add(new OdbcParameter("Dpi", Dpi));
            cmd.Parameters.Add(new OdbcParameter("Nombre", Nombre));
            cmd.Parameters.Add(new OdbcParameter("Apellido", Apellido));
            cmd.Parameters.Add(new OdbcParameter("FechaNac", FechaNac));
            cmd.Parameters.Add(new OdbcParameter("Edad", Edad));
            cmd.Parameters.Add(new OdbcParameter("FechaAbordaje", FechaAbordaje));
            cmd.Parameters.Add(new OdbcParameter("Mrz", Mrz));
            cmd.Parameters.Add(new OdbcParameter("Latitud", Latitud));
            cmd.Parameters.Add(new OdbcParameter("Longitud", Longitud));
            cmd.Parameters.Add(new OdbcParameter("Activo", (activo == "on") ? 1 : 0));

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
            Response.Redirect("~/frmTblTransaccion.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_Transaccion WHERE NoUnidad = ? " + "&FechaAbordaje = ?";
                cmd.Parameters.Add("@NoUnidad", OdbcType.VarChar).Value = txtNoUnidad.Value;
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

        protected void btnAgregarTransaccion_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Tbl_Transaccion (NoUnidad , Dpi, Nombre, Apellido , FechaNac, Edad, FechaAbordaje, MRZ, Latitud, Longitud, Activo) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.Parameters.Add("@NoUnidad", OdbcType.VarChar).Value = txtNoUnidadAdd.Value;
                cmd.Parameters.Add("@Dpi", OdbcType.VarChar).Value = txtDpiAdd;
                cmd.Parameters.Add("@Nombre", OdbcType.VarChar).Value = txtNombreAdd.Value;
                cmd.Parameters.Add("@Apellido", OdbcType.VarChar).Value = txtApellidoAdd.Value;
                cmd.Parameters.Add("@FechaNac", OdbcType.VarChar).Value = txtFechaNacAdd.Value;
                cmd.Parameters.Add("@Edad", OdbcType.VarChar).Value = txtEdadAdd.Value;
                cmd.Parameters.Add("@FechaAbordaje", OdbcType.VarChar).Value = txtFechaAbordajeAdd.Value;
                cmd.Parameters.Add("@Mrz", OdbcType.VarChar).Value = MrzAdd;
                cmd.Parameters.Add("@Latitud", OdbcType.VarChar).Value = txtLatitudAdd;
                cmd.Parameters.Add("@Longitud", OdbcType.VarChar).Value = txtLongitudAdd;
                cmd.Parameters.Add("@Activo", OdbcType.Bit).Value = ckbActivoAdd.Checked;
                cmd.Connection = new OdbcConnection(Utilities.ObtenerCadenaConexion());
              

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
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
    public partial class frmTblRuta : System.Web.UI.Page
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
            string Ruta = Request.QueryString["Ruta"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_Ruta WHERE Ruta = '{Ruta}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtRuta.Value = dt.Rows[0]["Ruta"].ToString();
            txtDescripcion.Value = dt.Rows[0]["Descripcion"].ToString();
            txtRecorrido.Value = dt.Rows[0]["Recorrido"].ToString();
            txtKilometrosRuta.Value = dt.Rows[0]["KilometrosRuta"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT Descripcion, Recorrido, KilometrosRuta, Ruta, iif(activo=0, 'NO', 'SI') activo FROM TBL_Ruta ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string Ruta = row.Cells[0].Text;

            Response.Redirect("~/frmTblRuta.aspx?cmd=edit&Ruta=" + Ruta);
        }

        protected void btnModificarRuta_Click(object sender, EventArgs e)
        {
            string Ruta = (Request.Form["ctl00$contenido$txtRuta"] != null)?Request.Form["ctl00$contenido$txtRuta"].ToString():"";
            string Descripcion = (Request.Form["ctl00$contenido$txtDescripcion"] != null)?Request.Form["ctl00$contenido$txtDescripcion"].ToString():"";
            string Recorrido = (Request.Form["ctl00$contenido$txtRecorrido"] != null)?Request.Form["ctl00$contenido$txtRecorrido"].ToString():"";
            string KilometrosRuta = (Request.Form["ctl00$contenido$txtKilometrosRuta"] != null) ?Request.Form["ctl00$contenido$txtKilometrosRuta"].ToString():"";
            string activo = (Request.Form["ctl00$contenido$ckbActivo"] != null)?Request.Form["ctl00$contenido$ckbActivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_Ruta 
                                SET 
                                    Descripcion=?,
                                    Recorrido=?,
                                    KilometrosRuta=?,
                                    Activo=?
                                WHERE
                                    Ruta=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Descripcion", Descripcion));
            cmd.Parameters.Add(new OdbcParameter("Recorrido", Recorrido));
            cmd.Parameters.Add(new OdbcParameter("KilometrosRuta", KilometrosRuta));
            cmd.Parameters.Add(new OdbcParameter("Activo", (activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("Ruta", Ruta));

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
            Response.Redirect("~/admin/frmTblRuta.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_Ruta WHERE Ruta = ? ";
                cmd.Parameters.Add("@Ruta", OdbcType.VarChar).Value = txtRuta.Value;
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

        protected void btnAgregarRuta_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Tbl_Ruta (Ruta, Recorrido, Descripcion, KilometrosRuta, Activo) VALUES (?,?,?,?,?)";
                cmd.Parameters.Add("@Ruta", OdbcType.VarChar).Value = txtRutaAdd.Value;
                cmd.Parameters.Add("@Recorrido", OdbcType.VarChar).Value = txtRecorridoAdd.Value;
                cmd.Parameters.Add("@Descripcion", OdbcType.VarChar).Value = txtDescripcionAdd.Value;
                cmd.Parameters.Add("@KilometrosRuta", OdbcType.VarChar).Value = txtKilometrosRutaAdd.Value;
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
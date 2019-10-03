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
    public partial class frmTblAsociacion : System.Web.UI.Page
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
            string Asociacion = Request.QueryString["Asociacion"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_ASOCIACION WHERE Asociacion = '{Asociacion}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtAsociacion.Value = dt.Rows[0]["Asociacion"].ToString();
            txtDescripcion.Value = dt.Rows[0]["Descripcion"].ToString();
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT Asociacion, Descripcion,  iif(activo=0, 'NO', 'SI') activo FROM TBL_Asociacion ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string Asociacion = row.Cells[0].Text;

            Response.Redirect("~/frmTblAsociacion.aspx?cmd=edit&Asociacion=" + Asociacion);
        }

        protected void btnModificarAsociacion_Click(object sender, EventArgs e)
        {
            string Asociacion = (Request.Form["ctl00$contenido$txtAsociacion"] != null)?Request.Form["ctl00$contenido$txtAsociacion"].ToString():"";
            string Descripcion = (Request.Form["ctl00$contenido$txtDescripcion"] != null)?Request.Form["ctl00$contenido$txtDescripcion"].ToString():"";
            string Activo = (Request.Form["ctl00$contenido$ckbActivo"] != null)?Request.Form["ctl00$contenido$ckbActivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_ASOCIACION 
                                SET 
                                    Descripcion=?,
                                    Activo=?
                                WHERE
                                    Asociacion=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Descripcion", Descripcion));
            cmd.Parameters.Add(new OdbcParameter("Activo", (Activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("Asociacion", Asociacion));

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
            Response.Redirect("~/admin/frmTblAsociacion.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_ASOCIACION WHERE Asociacion = ? ";
                cmd.Parameters.Add("@Asociacion", OdbcType.VarChar).Value = txtAsociacion.Value;
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

        protected void btnAgregarAsociacion_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Tbl_ASOCIACION (Asociacion, Descripcion, Activo) VALUES (?,?,?)";
                cmd.Parameters.Add("@Asociacion", OdbcType.VarChar).Value = txtAsociacionAdd.Value;
                cmd.Parameters.Add("@Descripcion", OdbcType.VarChar).Value = txtDescripcionAdd.Value;
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
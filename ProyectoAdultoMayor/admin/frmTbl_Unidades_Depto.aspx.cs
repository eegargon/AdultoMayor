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
    public partial class frmTbl_Unidades_Depto: System.Web.UI.Page
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
            string Cod = Request.QueryString["Cod"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM TBL_Unidades_Depto WHERE Cod = '{Cod}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCod.Value = dt.Rows[0]["Cod"].ToString();
            txtCantidad.Value = dt.Rows[0]["Cantidad"].ToString();
            txtAsociacion.Value = dt.Rows[0]["Asociacion"].ToString();
            txtDepto.Value = dt.Rows[0]["Depto"].ToString();
            txtMuni.Value = dt.Rows[0]["Muni"].ToString();
            txtOrderInstalacion.Value = dt.Rows[0]["OrderInstalacion"].ToString();            
            ckbactivo.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT Cod, Cantidad, Asociacion, Depto, Muni, OrderInstalacion, iif(Activo=0, 'NO', 'SI') activo FROM TBL_Unidades_Depto", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string Cod = row.Cells[0].Text;

            Response.Redirect("~/frmTbl_Unidades_Depto.aspx?cmd=edit&Cod=" + Cod);
        }

        protected void btnModificarUnidadesDepto_Click(object sender, EventArgs e)
        {
            string Cod = (Request.Form["ctl00$contenido$txtCod"] != null) ? Request.Form["ctl00$contenido$txtCod"].ToString() : "";
            string Cantidad= (Request.Form["ctl00$contenido$txtCantidad"] != null) ? Request.Form["ctl00$contenido$txtCantidad"].ToString() : "";
            string Asociacion = (Request.Form["ctl00$contenido$txtAsociacion"] != null) ? Request.Form["ctl00$contenido$txtAsociacion"].ToString() : "";
            string Depto = (Request.Form["ctl00$contenido$txtDepto"] != null) ? Request.Form["ctl00$contenido$txtDepto"].ToString() : "";
            string Muni = (Request.Form["ctl00$contenido$txtMuni"] != null) ? Request.Form["ctl00$contenido$txtMuni"].ToString() : "";
            string OrderInstalacion = (Request.Form["ctl00$contenido$txtOrderInstalacion"] != null) ? Request.Form["ctl00$contenido$txtOrderInstalacion"].ToString() : "";            
            string Activo = (Request.Form["ctl00$contenido$ckbactivo"] != null) ? Request.Form["ctl00$contenido$ckbactivo"].ToString() : "";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_Unidades_Depto
                                SET 
                                    Cod=?,
                                    Cantidad=?,
                                    Asociacion=?,
                                    Depto=?,
                                    Muni=?,
                                    OrderInstalacion=?,
                                    Activo=?
                                WHERE
                                    Cod=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("Cod", Cod));
            cmd.Parameters.Add(new OdbcParameter("Cantidad", Cantidad));
            cmd.Parameters.Add(new OdbcParameter("Asociacion", Asociacion));
            cmd.Parameters.Add(new OdbcParameter("Depto", Depto));
            cmd.Parameters.Add(new OdbcParameter("Muni", Muni));
            cmd.Parameters.Add(new OdbcParameter("OrderInstalacion", OrderInstalacion));
            cmd.Parameters.Add(new OdbcParameter("Activo", (Activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("Cod", Cod));

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
            Response.Redirect("~/frmTbl_Unidades_Depto.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_Unidades_Depto WHERE Cod = ? ";
                cmd.Parameters.Add("@UnidadesDepto", OdbcType.VarChar).Value = txtCod.Value;
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

        protected void btnAgregarUnidadesDepto_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO TBL_Unidades_Depto (Cod, Cantidad, Asociacion, Depto, Muni, OrderInstalacion, Activo) VALUES (?,?,?,?,?,?,?)";
                cmd.Parameters.Add("@Cod", OdbcType.VarChar).Value = txtCodAdd.Value;
                cmd.Parameters.Add("@Cantidad", OdbcType.VarChar).Value = txtCantidadAdd.Value;
                cmd.Parameters.Add("@Asociacion", OdbcType.VarChar).Value = txtAsociacionAdd.Value;
                cmd.Parameters.Add("@Depto", OdbcType.VarChar).Value = txtDeptoAdd.Value;
                cmd.Parameters.Add("@Muni", OdbcType.VarChar).Value = txtMuniAdd.Value;
                cmd.Parameters.Add("@OrderInstalacion", OdbcType.VarChar).Value = txtOrderInstalacionAdd.Value;
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
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
    public partial class frmRefMunis : System.Web.UI.Page
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
                // Cargar el combo de departamento
                CargarDepto();
            }
        }

        private void CargarDepto()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            departmentcode, 
                                                            departmentname, 
                                                            iif(active IS NULL OR active=0, 'NO', 'SI') active 
                                                        FROM REF_DEPTOS
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDepartmentCodeAdd.DataTextField = "departmentcode";
            txtDepartmentCodeAdd.DataTextField = "departmentname";
            txtDepartmentCodeAdd.DataSource = dt;
            txtDepartmentCodeAdd.DataBind();
        }

        private void LoadData()
        {
            string MunicipalityCode = Request.QueryString["MUNICIPALITYCODE"];

            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT 
                                                             d.departmentname departmentcode,
                                                             m.MUNICIPALITYCODE,   
                                                             m.MUNICIPALITYNAME,
                                                            iif(m.active=0, 'NO', 'SI') AS active 
                                                        FROM REF_MUNIS  m
                                                        INNER JOIN REF_DEPTOS d ON m.departmentcode = d.departmentcode
                                                        WHERE m.MUNICIPALITYCODE = '{MunicipalityCode}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDepartmentCode.Text = dt.Rows[0]["departmentcode"].ToString();
            txtMunicipalityCode.Value = dt.Rows[0]["MUNICIPALITYCODE"].ToString();
            txtMunicipalityName.Value = dt.Rows[0]["MUNICIPALITYNAME"].ToString();
            ckbactivo.Checked = dt.Rows[0]["active"].ToString().Equals("True");
        }

        private void BindTable()
        {
            // Cargar el grid
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT 
                                                             d.departmentname departmentcode,
                                                             m.MUNICIPALITYCODE,   
                                                             m.MUNICIPALITYNAME,
                                                            iif(m.active=0, 'NO', 'SI') AS active 
                                                        FROM REF_MUNIS  m
                                                        INNER JOIN REF_DEPTOS d ON m.departmentcode = d.departmentcode 
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string MUNICIPALITYCODE = row.Cells[0].Text;
            string departmentcode = row.Cells[1].Text;

            Response.Redirect("~/admin/frmRefMunis.aspx?cmd=edit&MUNICIPALITYCODE=" + MUNICIPALITYCODE + "departmentcode=" + departmentcode);
        }

        protected void btnModificarMunicipio_Click(object sender, EventArgs e)
        {
            string departmentcode = (Request.Form["ctl00$contenido$ttxtDepartmentCode"] != null)?Request.Form["ctl00$contenido$txtDepartmentCode"].ToString():"";
            string MUNICIPALITYCODE = (Request.Form["ctl00$contenido$txtMunicipalityCode"] != null)?Request.Form["ctl00$contenido$txtMunicipalityCode"].ToString():"";
            string MUNICIPALITYNAME = (Request.Form["ctl00$contenido$txtMunicipalityName"] != null)?Request.Form["ctl00$contenido$txtMunicipalityName"].ToString():"";
            string activo = (Request.Form["ctl00$contenido$ckbactivo"] != null)?Request.Form["ctl00$contenido$ckbactivo"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    REF_MUNIS 
                                SET 
                                    departmentcode=?,
                                    MUNICIPALITYNAME=?,
                                    active=?
                                WHERE
                                    MUNICIPALITYCODE=?
                                ";

            cmd.Parameters.Add(new OdbcParameter("departmentcode", departmentcode));
            cmd.Parameters.Add(new OdbcParameter("MUNICIPALITYNAME", MUNICIPALITYNAME));
            cmd.Parameters.Add(new OdbcParameter("active", (activo == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("MUNICIPALITYCODE", MUNICIPALITYCODE));

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
            Response.Redirect("~/admin/frmRefMunis.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM REF_MUNIS WHERE MUNICIPALITYCODE = ?";
                cmd.Parameters.Add("@MUNICIPALITYCODE", OdbcType.VarChar).Value = txtMunicipalityCode.Value;
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

        protected void btnAgregarMunicipio_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO REF_MUNIS (departmentcode,MUNICIPALITYCODE,MUNICIPALITYNAME,active) VALUES (?,?,?,?)";
                cmd.Parameters.Add("@departmentcode", OdbcType.VarChar).Value = txtDepartmentCodeAdd.SelectedIndex;
                cmd.Parameters.Add("@MUNICIPALITYCODE", OdbcType.VarChar).Value = txtMunicipalityCodeAdd.Value;
                cmd.Parameters.Add("@MUNICIPALITYNAME", OdbcType.VarChar).Value = txtMunicipalityNameAdd.Value;
                cmd.Parameters.Add("@active", OdbcType.Bit).Value = ckbActivoAdd.Checked;
                cmd.Connection = new OdbcConnection(Utilities.ObtenerCadenaConexion());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                IrAlListadoPrincipal();
            }
            catch (DbException ex)
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
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
    public partial class frmRefDeptos : System.Web.UI.Page
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
            string departmentcode = Request.QueryString["departmentcode"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM REF_DEPTOS WHERE departmentcode = '{departmentcode}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDepartmentcode.Value = dt.Rows[0]["departmentcode"].ToString();
            txtDepartmentname.Value = dt.Rows[0]["departmentname"].ToString();
            txtdeptCedula.Value = dt.Rows[0]["deptCedula"].ToString();
            ckbactive.Checked = dt.Rows[0]["Active"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT departmentcode, departmentname, deptCedula,  iif(active=0, 'NO', 'SI') activo FROM REF_DEPTOS ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string departmentcode = row.Cells[0].Text;

            Response.Redirect("~/admin/frmRefDeptos.aspx?cmd=edit&departmentcode=" + departmentcode);
        }

        protected void btnModificardepartmentcode_Click(object sender, EventArgs e)
        {
            string departmentcode = (Request.Form["ctl00$contenido$txtdepartmentcode"] != null)?Request.Form["ctl00$contenido$txtdepartmentcode"].ToString():"";
            string departmentname = (Request.Form["ctl00$contenido$txtdepartmentname"] != null)?Request.Form["ctl00$contenido$txtdepartmentname"].ToString():"";
            string deptCedula = (Request.Form["ctl00$contenido$txtdeptCedula"] != null) ? Request.Form["ctl00$contenido$txtdeptCedula"].ToString() : ""; 
            string active = (Request.Form["ctl00$contenido$ckbactive"] != null)? Request.Form["ctl00$contenido$ckbactive"].ToString():"";

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    REF_DEPTOS 
                                SET 
                                    departmentname=?,
                                    deptCedula=?,
                                    active=?
                                WHERE
                                    departmentcode=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("departmentname", departmentname));
            cmd.Parameters.Add(new OdbcParameter("deptCedula", deptCedula));
            cmd.Parameters.Add(new OdbcParameter("active", (active == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("departmentcode", departmentcode));

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
            Response.Redirect("~/admin/frmRefDeptos.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM REF_DEPTOS WHERE departmentcode = ? ";
                cmd.Parameters.Add("@departmentcode", OdbcType.VarChar).Value = txtDepartmentcode.Value;
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

        protected void btnAgregardepartmentcode_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO REF_DEPTOS (departmentcode, departmentname, deptCedula, Active) VALUES (?,?,?,?)";
                cmd.Parameters.Add("@departmentcode", OdbcType.VarChar).Value = txtDepartmentcodeAdd.Value;
                cmd.Parameters.Add("@departmentname", OdbcType.VarChar).Value = txtDepartmentnameAdd.Value;
                cmd.Parameters.Add("@deptCedula", OdbcType.VarChar).Value = txtdeptcedullaAdd.Value;
                cmd.Parameters.Add("@Active", OdbcType.Bit).Value = ckbActiveAdd.Checked;
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

    }
}
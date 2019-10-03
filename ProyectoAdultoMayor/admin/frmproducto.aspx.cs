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
    public partial class frmproducto : System.Web.UI.Page
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
            string idproducto= Request.QueryString["idproducto"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT * FROM producto WHERE idproducto= '{idproducto}' ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtidproducto.Value = dt.Rows[0]["idproducto"].ToString();
            txtnombreproducto.Value = dt.Rows[0]["nombreproducto"].ToString();
            txtprecio.Value = dt.Rows[0]["precio"].ToString();            
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                             idproducto,
                                                             nombreproducto,
                                                             precio                                                   
                                                        FROM producto", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string idproducto = row.Cells[0].Text;

            Response.Redirect("~/frmproducto.aspx?cmd=edit&idproducto=" + idproducto);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
             string idproducto = (Request.Form["ctl00$contenido$txtidproducto"] != null) ? Request.Form["ctl00$contenido$txtidproducto"].ToString() : "";
            string nombreproducto = (Request.Form["ctl00$contenido$txtnombreproducto"] != null) ? Request.Form["ctl00$contenido$txtnombreproducto"].ToString() : "";
            string precio = (Request.Form["ctl00$contenido$txtprecio"] != null) ? Request.Form["ctl00$contenido$txtprecio"].ToString() : "";
           

            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    producto
                                SET 
                                    nombreproducto=?,                                    
                                    precio=?                                    
                                WHERE
                                    idproducto=?
                                ";
            cmd.Parameters.Add(new OdbcParameter("nombreproducto", nombreproducto));
            cmd.Parameters.Add(new OdbcParameter("precio", precio));
            cmd.Parameters.Add(new OdbcParameter("idproducto", idproducto));

            /*
                         cmd.CommandText = $@"UPDATE 
                                                producto
                                            SET 
                                                nombreproducto='{nombreproducto}',
                                                precio={precio}
                                            WHERE
                                                idproducto={idproducto}
                                            ";
                        //cmd.Parameters.Add(new OdbcParameter("idproducto", idproducto));
                        //cmd.Parameters.Add(new OdbcParameter("nombreproducto", nombreproducto));
                        //cmd.Parameters.Add(new OdbcParameter("precio", precio));
            */

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
            Response.Redirect("~/frmproducto.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM producto WHERE idproducto= ? ";
                cmd.Parameters.Add("@idproducto", OdbcType.BigInt).Value = txtidproducto.Value;
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
                cmd.CommandText = "INSERT INTO producto (nombreproducto, precio) VALUES (?,?)";
                cmd.Parameters.Add("@nombreproducto", OdbcType.VarChar).Value = txtnombreproductoAdd.Value;
                cmd.Parameters.Add("@precio", OdbcType.BigInt).Value = txtprecioAdd.Value;                
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
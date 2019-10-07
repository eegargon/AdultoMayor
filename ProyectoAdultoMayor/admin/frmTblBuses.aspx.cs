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
    public partial class frmTblBuses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Listar)
            {
                BindTable();
            }

            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Editar)
            {
                CargarMunicipio();
                CargarDepartamento();
                CargarAsociacion();
                CargarRuta();
                CargarCUIPropietario();
                CargarCuiPiloto();
                LoadData();
            }

            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Agregar)
            {
                CargarMunicipioAdd();
                CargarDepartamentoAdd();
                CargarAsociacionAdd();
                CargarRutaAdd();
                CargarCUIPropietarioAdd();
                CargarCuiPilotoAdd();
            }
        }

        private void CargarMunicipio()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            MUNICIPALITYCODE, 
                                                            MUNICIPALITYNAME                                                            
                                                        FROM REF_MUNIS
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtMunicipio.DataValueField = "MUNICIPALITYCODE";
            txtMunicipio.DataTextField = "MUNICIPALITYNAME";
            txtMunicipio.DataSource = dt;
            txtMunicipio.DataBind();
        }

        private void CargarMunicipioAdd()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            MUNICIPALITYCODE, 
                                                            MUNICIPALITYNAME                                                            
                                                        FROM REF_MUNIS
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtMunicipioAdd.DataValueField = "MUNICIPALITYCODE";
            txtMunicipioAdd.DataTextField = "MUNICIPALITYNAME";
            txtMunicipioAdd.DataSource = dt;
            txtMunicipioAdd.DataBind();
        }

        private void CargarDepartamento()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            departmentCode, DepartmentName                                                            
                                                        FROM REF_DEPTOS
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDepartamento.DataValueField = "departmentcode";
            txtDepartamento.DataTextField = "departmentname";
            txtDepartamento.DataSource = dt;
            txtDepartamento.DataBind();
        }

        private void CargarDepartamentoAdd()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            departmentCode, DepartmentName                                                            
                                                        FROM REF_DEPTOS
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDepartamentoAdd.DataValueField = "departmentcode";
            txtDepartamentoAdd.DataTextField = "departmentname";
            txtDepartamentoAdd.DataSource = dt;
            txtDepartamentoAdd.DataBind();
        }

        private void CargarAsociacion()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select 
		                                                    Asociacion, Descripcion 		                                                   
		                                                    from TBL_ASOCIACION 
                                                            where Activo = 1
                                                      ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtAsociacion.DataValueField = "Asociacion";
            txtAsociacion.DataTextField = "Descripcion";
            txtAsociacion.DataSource = dt;
            txtAsociacion.DataBind();
        }
        private void CargarAsociacionAdd()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select 
		                                                    Asociacion, Descripcion 		                                                   
		                                                    from TBL_ASOCIACION 
                                                            where Activo = 1
                                                      ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtAsociacionAdd.DataValueField = "Asociacion";
            txtAsociacionAdd.DataTextField = "Descripcion";
            txtAsociacionAdd.DataSource = dt;
            txtAsociacionAdd.DataBind();
        }
        private void CargarRuta()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            Ruta, 
                                                            Descripcion                                                            
                                                        FROM TBL_RUTA
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtRuta.DataValueField = "Ruta";
            txtRuta.DataTextField = "Descripcion";
            txtRuta.DataSource = dt;
            txtRuta.DataBind();
        }
        private void CargarRutaAdd()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            Ruta, 
                                                            Descripcion                                                            
                                                        FROM TBL_RUTA
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtRutaAdd.DataValueField = "Ruta";
            txtRutaAdd.DataTextField = "Descripcion";
            txtRutaAdd.DataSource = dt;
            txtRutaAdd.DataBind();
        }
        private void CargarCUIPropietario()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            CUI, 
                                                            Nombre                                                             
                                                        FROM TBL_PROPIETARIO
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCUIPropietario.DataValueField = "CUI";
            txtCUIPropietario.DataTextField = "Nombre";
            txtCUIPropietario.DataSource = dt;
            txtCUIPropietario.DataBind();
        }
        private void CargarCUIPropietarioAdd()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            CUI, 
                                                            Nombre                                                             
                                                        FROM TBL_PROPIETARIO
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCUIPropietarioAdd.DataValueField = "CUI";
            txtCUIPropietarioAdd.DataTextField = "Nombre";
            txtCUIPropietarioAdd.DataSource = dt;
            txtCUIPropietarioAdd.DataBind();
        }
        private void CargarCuiPiloto()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                        CUI, 
                                                        Nombre                                                        
                                                        FROM TBL_PILOTO
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCuiPiloto.DataValueField = "CUI";
            txtCuiPiloto.DataTextField = "Nombre";
            txtCuiPiloto.DataSource = dt;
            txtCuiPiloto.DataBind();
        }
        private void CargarCuiPilotoAdd()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                        CUI, 
                                                        Nombre                                                        
                                                        FROM TBL_PILOTO
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCuiPilotoAdd.DataValueField = "CUI";
            txtCuiPilotoAdd.DataTextField = "Nombre";
            txtCuiPilotoAdd.DataSource = dt;
            txtCuiPilotoAdd.DataBind();
        }

        private void LoadData()
        {
            string NoUNidad = Request.QueryString["NoUNidad"];
            OdbcDataAdapter da = new OdbcDataAdapter($@"SELECT
                                                    b.NoUNidad, m.MUNICIPALITYNAME as Municipio, dep.departmentname as Departamento, a.Descripcion as Asociacion, r.Descripcion as Ruta, pro.CUI as CUIPropietario, pil.CUI as CuiPiloto, b.NoAfiliacion, b.PinAcceso, b.Consola, b.Lector, b.FechaInstalacion, b.RegularoSuplente, b.Marca, b.Modelo, b.Ano, b.Color, b. NoPlaca, b.NoPasajeros, b.Combustible, b.Tanque, b.FechaMant, b.TipoLLantas, b.CantidadLlantas, b.EstadoVehiculo, b.ComentariosInstalacion, b.SIM,
                                                    iif(b.Activo=0, 'NO', 'SI') AS Activo 
                                                    from TBL_BUSES AS b 
                                                    inner join TBL_ASOCIACION as a on b.Asociacion = a.Asociacion
                                                    inner join TBL_RUTA as r ON b.Ruta = r.Ruta
                                                    inner join TBL_PROPIETARIO as pro ON b.CUIPropietario = pro.CUI
                                                    inner join TBL_PILOTO as pil on b.CuiPiloto = pil.CUI                                                    
                                                    INNER JOIN REF_MUNIS AS m ON b.Municipio = m.MUNICIPALITYCODE And m.departmentcode = b.Departamento
													INNER JOIN REF_DEPTOS as dep on m.departmentcode = dep.departmentcode
                                                    WHERE b.NoUNidad = '{NoUNidad}'", Utilities.ObtenerCadenaConexion());

            DataTable dt = new DataTable();
            da.Fill(dt);        
            txtNoUNidad.Value = dt.Rows[0]["NoUNidad"].ToString();
            txtMunicipio.SelectedValue= dt.Rows[0]["Municipio"].ToString();
            txtDepartamento.SelectedValue = dt.Rows[0]["Departamento"].ToString();
            txtAsociacion.SelectedValue = dt.Rows[0]["Asociacion"].ToString();
            txtRuta.SelectedValue = dt.Rows[0]["Ruta"].ToString();
            txtCUIPropietario.SelectedValue = dt.Rows[0]["CUIPropietario"].ToString();
            txtCuiPiloto.SelectedValue = dt.Rows[0]["CuiPiloto"].ToString();
            txtNoAfiliacion.Value = dt.Rows[0]["NoAfiliacion"].ToString();
            txtPinAcceso.Value = dt.Rows[0]["PinAcceso"].ToString();
            txtConsola.Value = dt.Rows[0]["Consola"].ToString();
            txtLector.Value = dt.Rows[0]["Lector"].ToString();
            txtFechaInstalacion.Value = dt.Rows[0]["FechaInstalacion"].ToString();
            txtRegularoSuplente.Value = dt.Rows[0]["RegularoSuplente"].ToString();
            txtMarca.Value = dt.Rows[0]["Marca"].ToString();
            txtModelo.Value = dt.Rows[0]["Modelo"].ToString();
            txtAno.Value = dt.Rows[0]["Ano"].ToString();
            txtColor.Value = dt.Rows[0]["Color"].ToString();
            txtNoPlaca.Value = dt.Rows[0]["NoPlaca"].ToString();
            txtNoPasajeros.Value = dt.Rows[0]["NoPasajeros"].ToString();
            txtCombustible.Value = dt.Rows[0]["Combustible"].ToString();
            txtTanque.Value = dt.Rows[0]["Tanque"].ToString();
            txtFechaMant.Value = dt.Rows[0]["FechaMant"].ToString();
            txtTipoLLantas.Value = dt.Rows[0]["TipoLLantas"].ToString();
            txtCantidadLlantas.Value = dt.Rows[0]["CantidadLlantas"].ToString();
            txtEstadoVehiculo.Value = dt.Rows[0]["EstadoVehiculo"].ToString();
            txtComentariosInstalacion.Value = dt.Rows[0]["ComentariosInstalacion"].ToString();
            txtSIM.Value = dt.Rows[0]["SIM"].ToString();
            ckbactive.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select b.NoUNidad, m.MUNICIPALITYNAME as Municipio, dep.departmentname as Departamento, a.Descripcion as Asociacion, r.Descripcion as Ruta, pro.CUI as CUIPropietario, pil.CUI as CuiPiloto, b.NoAfiliacion, b.PinAcceso, b.Consola, b.Lector, b.FechaInstalacion, b.RegularoSuplente, b.Marca, b.Modelo, b.Ano, b.Color, b. NoPlaca, b. NoPasajeros, b. Combustible, b.Tanque, b.FechaMant, b.TipoLLantas, b.CantidadLlantas, b.EstadoVehiculo, b.ComentariosInstalacion, b.SIM,
                                                iif(b.activo=0, 'NO', 'SI') AS activo 
                                                   from TBL_BUSES AS b 
                                                    inner join TBL_ASOCIACION as a on b.Asociacion = a.Asociacion
                                                    inner join TBL_RUTA as r ON b.Ruta = r.Ruta
                                                    inner join TBL_PROPIETARIO as pro ON b.CUIPropietario = pro.CUI
                                                    inner join TBL_PILOTO as pil on b.CuiPiloto = pil.CUI
                                                    INNER JOIN REF_MUNIS AS m ON b.Municipio = m.MUNICIPALITYCODE And m.departmentcode = b.Departamento
													INNER JOIN REF_DEPTOS as dep on m.departmentcode = dep.departmentcode", 
                                                   

            Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];

            string NoUNidad = row.Cells[0].Text;

            Response.Redirect("~/admin/frmTblBuses.aspx?cmd=edit&NoUNidad=" + NoUNidad);
        }

        protected void btnModificarNoUNidad_Click(object sender, EventArgs e)
        {
            string NoUNidad = (Request.Form["ctl00$contenido$txtNoUNidad"] != null) ? Request.Form["ctl00$contenido$txtNoUNidad"].ToString() : "";
            string Municipio = (Request.Form["ctl00$contenido$txtMunicipio"] != null) ? Request.Form["ctl00$contenido$txtMunicipio"].ToString() : "";
            string Departamento = (Request.Form["ctl00$contenido$txtDepartamento"] != null) ? Request.Form["ctl00$contenido$txtDepartamento"].ToString() : "";
            string Asociacion = (Request.Form["ctl00$contenido$txtAsociacion"] != null) ? Request.Form["ctl00$contenido$txtAsociacion"].ToString() : "";
            string Ruta = (Request.Form["ctl00$contenido$txtRuta"] != null) ? Request.Form["ctl00$contenido$txtRuta"].ToString() : "";
            string CUIPropietario = (Request.Form["ctl00$contenido$txtCUIPropietario"] != null) ? Request.Form["ctl00$contenido$txtCUIPropietario"].ToString() : "";
            string CuiPiloto = (Request.Form["ctl00$contenido$txtCuiPiloto"] != null) ? Request.Form["ctl00$contenido$txtCuiPiloto"].ToString() : "";
            string NoAfiliacion = (Request.Form["ctl00$contenido$txtNoAfiliacion"] != null) ? Request.Form["ctl00$contenido$txtNoAfiliacion"].ToString() : "";
            string PinAcceso = (Request.Form["ctl00$contenido$txtPinAcceso"] != null) ? Request.Form["ctl00$contenido$txtPinAcceso"].ToString() : "";
            string Consola = (Request.Form["ctl00$contenido$txtConsola"] != null) ? Request.Form["ctl00$contenido$txtConsola"].ToString() : "";
            string Lector = (Request.Form["ctl00$contenido$txtLector"] != null) ? Request.Form["ctl00$contenido$txtLector"].ToString() : "";
            string FechaInstalacion = (Request.Form["ctl00$contenido$txtFechaInstalacion"] != null) ? Request.Form["ctl00$contenido$txtFechaInstalacion"].ToString() : "";
            string RegularoSuplente = (Request.Form["ctl00$contenido$txtRegularoSuplente"] != null) ? Request.Form["ctl00$contenido$txtRegularoSuplente"].ToString() : "";
            string Marca = (Request.Form["ctl00$contenido$txtMarca"] != null) ? Request.Form["ctl00$contenido$txtMarca"].ToString() : "";
            string Modelo = (Request.Form["ctl00$contenido$txtModelo"] != null) ? Request.Form["ctl00$contenido$txtModelo"].ToString() : "";
            string Ano = (Request.Form["ctl00$contenido$txtAno"] != null) ? Request.Form["ctl00$contenido$txtAno"].ToString() : "";
            string Color = (Request.Form["ctl00$contenido$txtColor"] != null) ? Request.Form["ctl00$contenido$txtColor"].ToString() : "";
            string NoPlaca = (Request.Form["ctl00$contenido$txtNoPlaca"] != null) ? Request.Form["ctl00$contenido$txtNoPlaca"].ToString() : "";
            string NoPasajeros = (Request.Form["ctl00$contenido$txtNoPasajeros"] != null) ? Request.Form["ctl00$contenido$txtNoPasajeros"].ToString() : "";
            string Combustible = (Request.Form["ctl00$contenido$txtCombustible"] != null) ? Request.Form["ctl00$contenido$txtCombustible"].ToString() : "";
            string Tanque = (Request.Form["ctl00$contenido$txtTanque"] != null) ? Request.Form["ctl00$contenido$txtTanque"].ToString() : "";
            string FechaMant = (Request.Form["ctl00$contenido$txtFechaMant"] != null) ? Request.Form["ctl00$contenido$txtFechaMant"].ToString() : "";
            string TipoLLantas = (Request.Form["ctl00$contenido$txtTipoLLantas"] != null) ? Request.Form["ctl00$contenido$txtTipoLLantas"].ToString() : "";
            string CantidadLlantas = (Request.Form["ctl00$contenido$txtCantidadLlantas"] != null) ? Request.Form["ctl00$contenido$txtCantidadLlantas"].ToString() : "";
            string EstadoVehiculo = (Request.Form["ctl00$contenido$txtEstadoVehiculo"] != null) ? Request.Form["ctl00$contenido$txtEstadoVehiculo"].ToString() : "";
            string ComentariosInstalacion = (Request.Form["ctl00$contenido$txtComentariosInstalacion"] != null) ? Request.Form["ctl00$contenido$txtComentariosInstalacion"].ToString() : "";
            string SIM = (Request.Form["ctl00$contenido$txtSIM"] != null) ? Request.Form["ctl00$contenido$txtSIM"].ToString() : "";
            string active = (Request.Form["ctl00$contenido$ckbactive"] != null) ? Request.Form["ctl00$contenido$ckbactive"].ToString() : "";


            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = @"UPDATE 
                                    TBL_BUSES
                                SET                                                                                        
                                                             Municipio=?,
                                                             Departamento=?,
                                                             Asociacion=?,
                                                             Ruta=?,
                                                             CUIPropietario=?,
                                                             CuiPiloto=?,
                                                             NoAfiliacion=?,
                                                             PinAcceso=?,
                                                             Consola=?,
                                                             Lector=?, 
                                                             FechaInstalacion=?,
                                                             RegularoSuplente=?,
                                                             Marca=?,
                                                             Modelo=?,
                                                             Ano=?,
                                                             Color=?,
                                                             NoPlaca=?,
                                                             NoPasajeros=?,
                                                             Combustible=?,
                                                             Tanque=?,
                                                             FechaMant=?,    
                                                             TipoLLantas=?,
                                                             CantidadLlantas=?,
                                                             EstadoVehiculo=?,
                                                             ComentariosInstalacion=?,
                                                             SIM=?,
                                                             Activo=?
                                                            WHERE
                                                                NoUNidad=?
                                                            ";

            cmd.Parameters.Add(new OdbcParameter("Municipio", Municipio));
            cmd.Parameters.Add(new OdbcParameter("Departamento", Departamento));
            cmd.Parameters.Add(new OdbcParameter("Asociacion", Asociacion));
            cmd.Parameters.Add(new OdbcParameter("Ruta", Ruta));
            cmd.Parameters.Add(new OdbcParameter("CUIPropietario", CUIPropietario));
            cmd.Parameters.Add(new OdbcParameter("CuiPiloto", CuiPiloto));
            cmd.Parameters.Add(new OdbcParameter("NoAfiliacion", NoAfiliacion));
            cmd.Parameters.Add(new OdbcParameter("PinAcceso", PinAcceso));
            cmd.Parameters.Add(new OdbcParameter("Consola", Consola));
            cmd.Parameters.Add(new OdbcParameter("Lector", Lector));
            cmd.Parameters.Add(new OdbcParameter("FechaInstalacion", FechaInstalacion));
            cmd.Parameters.Add(new OdbcParameter("RegularoSuplente", RegularoSuplente));
            cmd.Parameters.Add(new OdbcParameter("Marca", Marca));
            cmd.Parameters.Add(new OdbcParameter("Modelo", Modelo));
            cmd.Parameters.Add(new OdbcParameter("Ano", Ano));
            cmd.Parameters.Add(new OdbcParameter("Color", Color));
            cmd.Parameters.Add(new OdbcParameter("NoPlaca", NoPlaca));
            cmd.Parameters.Add(new OdbcParameter("NoPasajeros", NoPasajeros));
            cmd.Parameters.Add(new OdbcParameter("Combustible", Combustible));
            cmd.Parameters.Add(new OdbcParameter("Tanque", Tanque));
            cmd.Parameters.Add(new OdbcParameter("FechaMant", FechaMant));
            cmd.Parameters.Add(new OdbcParameter("TipoLLantas", TipoLLantas));
            cmd.Parameters.Add(new OdbcParameter("CantidadLlantas", CantidadLlantas));
            cmd.Parameters.Add(new OdbcParameter("EstadoVehiculo", EstadoVehiculo));
            cmd.Parameters.Add(new OdbcParameter("ComentariosInstalacion", ComentariosInstalacion));
            cmd.Parameters.Add(new OdbcParameter("SIM", SIM));
            cmd.Parameters.Add(new OdbcParameter("Activo", (active == "on") ? 1 : 0));
            cmd.Parameters.Add(new OdbcParameter("NoUNidad", NoUNidad));

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
            Response.Redirect("~/admin/frmTblBuses.aspx");
            Response.End();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "DELETE FROM TBL_BUSES WHERE NoUNidad= ? ";
                cmd.Parameters.Add("@NoUNidad", OdbcType.VarChar).Value = txtNoUNidad.Value;
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

        protected void btnAgregarNoUNidad_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                string NoUNidad = txtNoUNidad.Value;
                string Municipio = txtMunicipio.SelectedValue;
                string Departamento = txtDepartamento.SelectedValue;
                string Asociacion = txtAsociacion.SelectedValue;
                string Ruta = txtRuta.SelectedValue;
                string CUIPropietario = txtCUIPropietario.SelectedValue;
                string CuiPiloto = txtCuiPiloto.SelectedValue;
                string NoAfiliacion = txtNoAfiliacion.Value;
                string PinAcceso = txtPinAcceso.Value;
                string Consola = txtConsola.Value;
                string Lector = txtLector.Value;
                string FechaInstalacion = string.IsNullOrEmpty(txtFechaInstalacion.Value) ? DateTime.Now.ToShortDateString() : txtFechaInstalacion.Value;
                string RegularoSuplente = string.IsNullOrEmpty(txtRegularoSuplente.Value) ? "0" : txtRegularoSuplente.Value;
                string Marca = txtMarca.Value;
                string Modelo = txtModelo.Value;
                string Ano = string.IsNullOrEmpty(txtAno.Value) ? "1900" : txtAno.Value;
                string Color = txtColor.Value;
                string NoPlaca = txtNoPlaca.Value;
                string NoPasajeros = txtNoPasajeros.Value;
                string Combustible = txtCombustible.Value;
                string Tanque = txtTanque.Value;
                string FechaMant = (txtFechaMant.Value == null) ? DateTime.Now.ToShortDateString() : txtFechaMant.Value;
                string TipoLLantas = txtTipoLLantas.Value;
                string CantidadLlantas = string.IsNullOrEmpty(txtCantidadLlantas.Value) ? "0" : txtCantidadLlantas.Value;
                string EstadoVehiculo = txtEstadoVehiculo.Value;
                string ComentariosInstalacion = txtComentariosInstalacion.Value;
                string SIM = txtSIM.Value;
                string Activo = (ckbactive.Checked) ? "1" : "0";
                string sqlQuery = string.Format("UPDATE TBL_BUSES  SET" +
                    "                               Municipio = '{0}', Departamento = '{1}', Asociacion = '{2}', Ruta = '{3}', " +
                    "                               CUIPropietario = '{4}', CuiPiloto = '{5}', NoAfiliacion = '{6}', PinAcceso = '{7}',Consola = '{8}'," +
                    "                               Lector = '{9}', FechaInstalacion = '{10}', RegularoSuplente = {11}, Marca = '{12}', Modelo = '{13}', " +
                    "                               Ano = {14},Color = '{15}', NoPlaca = '{16}', NoPasajeros = '{17}',Combustible = '{18}', Tanque = '{19}', " +
                    "                               FechaMant = '{20}', TipoLLantas = '{21}', CantidadLlantas = {22}, EstadoVehiculo = '{23}', ComentariosInstalacion = '{24}', " +
                    "                               SIM = '{25}', Activo = {26}" +
                    "                           WHERE " +
                    "                               NoUNidad = '{27}' ", 
                            Municipio, Departamento, Asociacion, Ruta,
                            CUIPropietario, CuiPiloto, NoAfiliacion, PinAcceso, Consola,
                            Lector, FechaInstalacion, RegularoSuplente, Marca, Modelo,
                            Ano, Color, NoPlaca, NoPasajeros, Combustible,Tanque, 
                            FechaMant, TipoLLantas, CantidadLlantas, EstadoVehiculo, ComentariosInstalacion,
                            SIM, Activo, NoUNidad);

                cmd.CommandText = sqlQuery;
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
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
                LoadData();
            }

            if (!IsPostBack && Utilities.ObtenerComandoActual(Request.QueryString["cmd"]) == Utilities.Comandos.Agregar)
            {
                CargarMunicipio();
                CargarDepartamento();
                CargarAsociacion();
                CargarRuta();
                CargarCUIPropietario();
                CargarCuiPiloto();
            }
        }

        private void CargarMunicipio()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            MunicipalityCode, 
                                                            MunicipalityName, 
                                                            iif(active IS NULL OR active=0, 'NO', 'SI') active 
                                                        FROM REF_MUNIS
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtMunicipalityCodeAdd.DataTextField = "MunicipalityCode";
            txtMunicipalityCodeAdd.DataTextField = "MunicipalityName";
            txtMunicipalityCodeAdd.DataSource = dt;
            txtMunicipalityCodeAdd.DataBind();
        }

        private void CargarDepartamento()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            DepartmentCode, 
                                                            DepartmentName, 
                                                            iif(active IS NULL OR active=0, 'NO', 'SI') active 
                                                        FROM REF_DEPTOS
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtdepartmentcodeAdd.DataTextField = "departmentcode";
            txtdepartmentcodeAdd.DataTextField = "departmentname";
            txtdepartmentcodeAdd.DataSource = dt;
            txtdepartmentcodeAdd.DataBind();
        }

        private void CargarAsociacion()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            Asociacion, 
                                                            Asociacion, 
                                                            iif(active IS NULL OR active=0, 'NO', 'SI') active 
                                                        FROM TBL_ASOCIACION
                                                        WHERE active = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtAsociacionAdd.DataTextField = "Asociacion";
            txtAsociacionAdd.DataTextField = "Asociacion";
            txtAsociacionAdd.DataSource = dt;
            txtAsociacionAdd.DataBind();
        }
        private void CargarRuta()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            Ruta, 
                                                            Ruta, 
                                                            iif(active IS NULL OR active=0, 'NO', 'SI') active 
                                                        FROM TBL_RUTA
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtRutaAdd.DataTextField = "Ruta";
            txtRutaAdd.DataTextField = "Ruta";
            txtRutaAdd.DataSource = dt;
            txtRutaAdd.DataBind();
        }
        private void CargarCUIPropietario()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                            CUI, 
                                                            Nombre, 
                                                            iif(active IS NULL OR active=0, 'NO', 'SI') active 
                                                        FROM TBL_PROPIETARIO
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCUIAdd.DataTextField = "CUI";
            txtCUIAdd.DataTextField = "Nombre";
            txtCUIAdd.DataSource = dt;
            txtCUIAdd.DataBind();
        }
        private void CargarCuiPiloto()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT
                                                        CUI, 
                                                        Nombre, 
                                                        iif(active IS NULL OR active=0, 'NO', 'SI') active 
                                                        FROM TBL_PILOTO
                                                        WHERE Activo = 1
                                                    ", Utilities.ObtenerCadenaConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCUIAdd.DataTextField = "CUI";
            txtCUIAdd.DataTextField = "Nombre";
            txtCUIAdd.DataSource = dt;
            txtCUIAdd.DataBind();
        }

        private void LoadData()
        {
            string NoUNidad = Request.QueryString["NoUNidad"];
            OdbcDataAdapter da = new OdbcDataAdapter(@"select b.NoUNidad, m.MUNICIPALITYNAME, m.departmentcode, a.Asociacion, r.Ruta, pro.CUI, pil.CUI, b.NoAfiliacion, b.PinAcceso, b.Consola, b.Lector, b.FechaInstalacion, b.RegularoSuplente, b.Marca, b.Modelo, b.Ano, b.Color, b. NoPlaca, b. NoPasajeros, b. Combustible, b.Tanque, b.FechaMant, b.TipoLLantas, b.CantidadLlantas, b.EstadoVehiculo, b.ComentariosInstalacion, b.SIM, b.Campo1, b.Campo2, b.Campo3, b.Campo4, b.Campo5, b.Campo6, b.Campo7,
                                                iif(b.Activo=0, 'NO', 'SI') AS Activo 
                                                   from TBL_BUSES AS b 
                                                    inner join TBL_ASOCIACION as a on b.Asociacion = a.Asociacion
                                                    inner join TBL_RUTA as r ON b.Ruta = r.Ruta
                                                    inner join TBL_PROPIETARIO as pro ON b.CUIPropietario = pro.CUI
                                                    inner join TBL_PILOTO as pil on b.CuiPiloto = pil.CUI
                                                    INNER JOIN REF_MUNIS AS m ON b.Municipio = m.MUNICIPALITYCODE And m.departmentcode = b.Departamento
                                                    WHERE NoUnidad = '{NoUnidad}'",
                                                    
             Utilities.ObtenerCadenaConexion());

            DataTable dt = new DataTable();
            da.Fill(dt);
            txtNoUNidad.Value = dt.Rows[0]["NoUNidad"].ToString();
            txtMunicipio.Value = dt.Rows[0]["Municipio"].ToString();
            txtDepartamento.Value = dt.Rows[0]["Departamento"].ToString();
            txtAsociacion.Value = dt.Rows[0]["Asociacion"].ToString();
            txtRuta.Value = dt.Rows[0]["Ruta"].ToString();
            txtCUIPropietario.Value = dt.Rows[0]["CUIPropietario"].ToString();
            txtCuiPiloto.Value = dt.Rows[0]["CuiPiloto"].ToString();
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
            txtCampo1.Value = dt.Rows[0]["Campo1"].ToString();
            txtCampo2.Value = dt.Rows[0]["Campo2"].ToString();
            txtCampo3.Value = dt.Rows[0]["Campo3"].ToString();
            txtCampo4.Value = dt.Rows[0]["Campo4"].ToString();
            txtCampo5.Value = dt.Rows[0]["Campo5"].ToString();
            txtCampo6.Value = dt.Rows[0]["Campo6"].ToString();
            txtCampo7.Value = dt.Rows[0]["Campo7"].ToString();
            ckbactive.Checked = dt.Rows[0]["Activo"].ToString().Equals("True");
        }

        private void BindTable()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(@"select b.NoUNidad, m.municipalityname as Municipio, m.departmentcode as Departamento, a.Asociacion, r.Ruta, pro.CUI as CUIPropietario, pil.CUI as CuiPiloto, b.NoAfiliacion, b.PinAcceso, b.Consola, b.Lector, b.FechaInstalacion, b.RegularoSuplente, b.Marca, b.Modelo, b.Ano, b.Color, b. NoPlaca, b. NoPasajeros, b. Combustible, b.Tanque, b.FechaMant, b.TipoLLantas, b.CantidadLlantas, b.EstadoVehiculo, b.ComentariosInstalacion, b.SIM, b.Campo1, b.Campo2, b.Campo3, b.Campo4, b.Campo5, b.Campo6, b.Campo7,
                                                iif(b.activo=0, 'NO', 'SI') AS activo 
                                                   from TBL_BUSES AS b 
                                                    inner join TBL_ASOCIACION as a on b.Asociacion = a.Asociacion
                                                    inner join TBL_RUTA as r ON b.Ruta = r.Ruta
                                                    inner join TBL_PROPIETARIO as pro ON b.CUIPropietario = pro.CUI
                                                    inner join TBL_PILOTO as pil on b.CuiPiloto = pil.CUI
                                                    INNER JOIN REF_MUNIS AS m ON b.Municipio = m.MUNICIPALITYCODE And m.departmentcode = b.Departamento", 
                                                   

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

            Response.Redirect("~/frmTblBuses.aspx?cmd=edit&NoUNidad=" + NoUNidad);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
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
            string Campo1 = (Request.Form["ctl00$contenido$txtCampo1"] != null) ? Request.Form["ctl00$contenido$txtCampo1"].ToString() : "";
            string Campo2 = (Request.Form["ctl00$contenido$txtCampo2"] != null) ? Request.Form["ctl00$contenido$txtCampo2"].ToString() : "";
            string Campo3 = (Request.Form["ctl00$contenido$txtCampo3"] != null) ? Request.Form["ctl00$contenido$txtCampo3"].ToString() : "";
            string Campo4 = (Request.Form["ctl00$contenido$txtCampo4"] != null) ? Request.Form["ctl00$contenido$txtCampo4"].ToString() : "";
            string Campo5 = (Request.Form["ctl00$contenido$txtCampo5"] != null) ? Request.Form["ctl00$contenido$txtCampo5"].ToString() : "";
            string Campo6 = (Request.Form["ctl00$contenido$txtCampo6"] != null) ? Request.Form["ctl00$contenido$txtCampo6"].ToString() : "";
            string Campo7 = (Request.Form["ctl00$contenido$txtCampo7"] != null) ? Request.Form["ctl00$contenido$txtCampo7"].ToString() : "";
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
                                                             Campo1=?,
                                                             Campo2=?,
                                                             Campo3=?,
                                                             Campo4=?,
                                                             Campo5=?,
                                                             Campo6=?,
                                                             Campo7=?,  
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
            cmd.Parameters.Add(new OdbcParameter("Campo1", Campo1));
            cmd.Parameters.Add(new OdbcParameter("Campo2", Campo2));
            cmd.Parameters.Add(new OdbcParameter("Campo3", Campo3));
            cmd.Parameters.Add(new OdbcParameter("Campo4", Campo4));
            cmd.Parameters.Add(new OdbcParameter("Campo5", Campo5));
            cmd.Parameters.Add(new OdbcParameter("Campo6", Campo6));
            cmd.Parameters.Add(new OdbcParameter("Campo7", Campo7));
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.CommandText = "INSERT INTO TBL_BUSES (Municipio, Departamento, Asociacion, Ruta, CUIPropietario, CuiPiloto, NoAfiliacion, PinAcceso,Consola,Lector, FechaInstalacion, RegularoSuplente, Marca, Modelo, Ano,Color, NoPlaca, NoPasajeros,Combustible, Tanque, FechaMant, TipoLLantas, CantidadLlantas, EstadoVehiculo, ComentariosInstalacion, SIM, Campo1, Campo2, Campo3, Campo4, Campo5, Campo6, Campo7, Activo) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.Parameters.Add("@Municipio", OdbcType.NVarChar).Value = txtMunicipalityCodeAdd.SelectedValue;
                cmd.Parameters.Add("@Departamento", OdbcType.NVarChar).Value = txtdepartmentcodeAdd.SelectedValue;
                cmd.Parameters.Add("@Asociacion", OdbcType.VarChar).Value = txtAsociacionAdd.SelectedValue;
                cmd.Parameters.Add("@Ruta", OdbcType.VarChar).Value = txtRutaAdd.SelectedValue;
                cmd.Parameters.Add("@CUIPropietario", OdbcType.VarChar).Value = txtCUIAdd.SelectedValue;
                cmd.Parameters.Add("@CuiPiloto", OdbcType.VarChar).Value = txtCUIAdd1.SelectedValue;
                cmd.Parameters.Add("@NoAfiliacion", OdbcType.VarChar).Value = txtNoAfiliacionAdd.Value;
                cmd.Parameters.Add("@PinAcceso", OdbcType.VarChar).Value = txtPinAccesoAdd.Value;
                cmd.Parameters.Add("@Consola", OdbcType.VarChar).Value = txtConsolaAdd.Value;
                cmd.Parameters.Add("@Lector", OdbcType.VarChar).Value = txtLectorAdd.Value;
                cmd.Parameters.Add("@FechaInstalacion", OdbcType.DateTime).Value = txtFechaInstalacionAdd.Value;
                cmd.Parameters.Add("@RegularoSuplente", OdbcType.VarChar).Value = txtRegularoSuplenteAdd.Value;
                cmd.Parameters.Add("@Marca", OdbcType.VarChar).Value = txtMarcaAdd.Value;
                cmd.Parameters.Add("@Modelo", OdbcType.VarChar).Value = txtModeloAdd.Value;
                cmd.Parameters.Add("@Ano", OdbcType.Int).Value = txtAnoAdd.Value;
                cmd.Parameters.Add("@Color", OdbcType.VarChar).Value = txtColorAdd.Value;
                cmd.Parameters.Add("@NoPlaca", OdbcType.VarChar).Value = txtNoPlacaAdd.Value;
                cmd.Parameters.Add("@NoPasajeros", OdbcType.VarChar).Value = txtNoPasajerosAdd.Value;
                cmd.Parameters.Add("@Combustible", OdbcType.VarChar).Value = txtCombustibleAdd.Value;
                cmd.Parameters.Add("@Tanque", OdbcType.VarChar).Value = txtTanqueAdd.Value;
                cmd.Parameters.Add("@FechaMant", OdbcType.DateTime).Value = txtFechaMantAdd.Value;
                cmd.Parameters.Add("@TipoLLantas", OdbcType.VarChar).Value = txtTipoLLantasAdd.Value;
                cmd.Parameters.Add("@CantidadLlantas", OdbcType.Int).Value = txtCantidadLlantasAdd.Value;
                cmd.Parameters.Add("@EstadoVehiculo", OdbcType.VarChar).Value = txtEstadoVehiculoAdd.Value;
                cmd.Parameters.Add("@ComentariosInstalacion", OdbcType.VarChar).Value = txtComentariosInstalacionAdd.Value;
                cmd.Parameters.Add("@SIM", OdbcType.VarChar).Value = txtSIMAdd.Value;
                cmd.Parameters.Add("@Campo1", OdbcType.VarChar).Value = txtCampo1Add.Value;
                cmd.Parameters.Add("@Campo2", OdbcType.VarChar).Value = txtCampo2Add.Value;
                cmd.Parameters.Add("@Campo3", OdbcType.VarChar).Value = txtCampo3Add.Value;
                cmd.Parameters.Add("@Campo4", OdbcType.VarChar).Value = txtCampo4Add.Value;
                cmd.Parameters.Add("@Campo5", OdbcType.VarChar).Value = txtCampo5Add.Value;
                cmd.Parameters.Add("@Campo6", OdbcType.VarChar).Value = txtCampo6Add.Value;
                cmd.Parameters.Add("@Campo7", OdbcType.VarChar).Value = txtCampo7Add.Value;               
                cmd.Parameters.Add("@Activo", OdbcType.VarChar).Value = ckbactiveAdd.Checked;
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
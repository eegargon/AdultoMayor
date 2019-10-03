<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblBuses.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblBuses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <form id="form1" method="post" runat="server">
    <div class ="container">
        <% if (Request.QueryString["cmd"] == "edit")
            { %>
            <ol class="breadcrumb">
                <li><a href="default.aspx">Inicio</a></li>
                <li><a href="frmTblBuses.aspx">GESTI&Oacute;N DE BUSES</a></li>
                <li class="active">GESTIONAR BUSES</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">MODIFICAR BUSES</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                         <div class="form-group">
                        <label for="contenido_txtNoUNidad">NUMERO DE UNIDAD</label>
                        <input type="text" class="form-control" id="txtNoUNidad" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtMunicipio">NOMBRE DEL MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMunicipio" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtDepartamento">NOMBRE DEL DEPARTAMENTO</label>
                        <input type="text" class="form-control" id="txtDepartamento" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtAsociacion">TIPO DE ASOCIACION</label>
                        <input type="text" class="form-control" id="txtAsociacion" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtRuta">NOMBRE DE LA RUTA</label>
                        <input type="text" class="form-control" id="txtRuta" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtCUIPropietario">NUMERO DE CUI DEL PROPIETARIO</label>
                        <input type="text" class="form-control" id="txtCUIPropietario" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtCuiPiloto">NUMERO DE CUI DEL PILOTO</label>
                        <input type="text" class="form-control" id="txtCuiPiloto" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtNoAfiliacion">NUMERO DE AFILIACION</label>
                        <input type="text" class="form-control" id="txtNoAfiliacion" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtPinAcceso">PIN PARA ACCEDER</label>
                        <input type="text" class="form-control" id="txtPinAcceso" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtConsola">CONSOLA</label>
                        <input type="text" class="form-control" id="txtConsola" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtLector">LECTOR</label>
                        <input type="text" class="form-control" id="txtLector" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtFechaInstalacion">FECHA DE INSTALACION</label>
                        <input type="date" class="form-control" id="txtFechaInstalacion" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtRegularoSuplente">REGULAR O SUPLENTE</label>
                        <input type="text" class="form-control" id="txtRegularoSuplente" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtMarca">MARCA DEL BUS</label>
                        <input type="text" class="form-control" id="txtMarca" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtModelo">MODELO DEL BUS</label>
                        <input type="text" class="form-control" id="txtModelo" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtAno">ANO DEL BUS</label>
                        <input type="text" class="form-control" id="txtAno" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtColor">COLOR DEL BUS</label>
                        <input type="text" class="form-control" id="txtColor" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtNoPlaca">NUMERO DE PLACA</label>
                        <input type="text" class="form-control" id="txtNoPlaca" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtNoPasajeros">NUMERO DE PASAJEROS</label>
                        <input type="text" class="form-control" id="txtNoPasajeros" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtCombustible">TIPO DE COMBUSTIBLE</label>
                        <input type="text" class="form-control" id="txtCombustible" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtTanque">TANQUE</label>
                        <input type="text" class="form-control" id="txtTanque" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtFechaMant">FECHA DE MANTENIMIENTO</label>
                        <input type="date" class="form-control" id="txtFechaMant" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtTipoLLantas">TIPO DE LLANTAS</label>
                        <input type="text" class="form-control" id="txtTipoLLantas" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtCantidadLlantas">CANTIDAD DE LLANTAS</label>
                        <input type="text" class="form-control" id="txtCantidadLlantas" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtEstadoVehiculo">ESTADO DEL VEHICULO</label>
                        <input type="text" class="form-control" id="txtEstadoVehiculo" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtComentariosInstalacion">COMENTARIOS SOBRE LA INSTALACION</label>
                        <input type="text" class="form-control" id="txtComentariosInstalacion" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtSIM">NUMERO DE SIM</label>
                        <input type="text" class="form-control" id="txtSIM" runat="server" >         
                        </div>        
                        <div class="form-group">
                        <label for="contenido_txtCampo1">CAMPO 1</label>
                        <input type="text" class="form-control" id="txtCampo1" runat="server" >         
                        </div>       
                         <div class="form-group">
                        <label for="contenido_txtCampo2">CAMPO 2</label>
                        <input type="text" class="form-control" id="txtCampo2" runat="server" >         
                        </div>     
                         <div class="form-group">
                        <label for="contenido_txtCampo3">CAMPO 3</label>
                        <input type="text" class="form-control" id="txtCampo3" runat="server" >         
                        </div>     
                         <div class="form-group">
                        <label for="contenido_txtCampo4">CAMPO 4</label>
                        <input type="text" class="form-control" id="txtCampo4" runat="server" >         
                        </div>     
                         <div class="form-group">
                        <label for="contenido_txtCampo5">CAMPO 5</label>
                        <input type="text" class="form-control" id="txtCampo5" runat="server" >         
                        </div>     
                         <div class="form-group">
                        <label for="contenido_txtCampo6">CAMPO 6</label>
                        <input type="text" class="form-control" id="txtCampo6" runat="server" >         
                        </div>     
                         <div class="form-group">
                        <label for="contenido_txtCampo7">CAMPO 7</label>
                        <input type="text" class="form-control" id="txtCampo7" runat="server" >         
                        </div>     
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactive" runat="server">
                        <label class="form-check-label" for="contenido_ckbactive">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("NoUNidad") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificar" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificar_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="default.aspx">Inicio</a></li>
            <li><a href="frmTblBuses.aspx">GESTI&Oacute;N DE BUSES</a></li>
            <li class="active">AGREGAR BUSES</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">AGREGAR BUSES</div>
            <div class="panel panel-body">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
<asp:ScriptManager ID="sm1" runat="server">  
  <Scripts>  
    <asp:ScriptReference Name="jquery"/>  
  </Scripts>  
</asp:ScriptManager>     
                         <div class="form-group">
                        <label for="Municipio">SELECCIONE UN MUNICIPIO</label>
                        &nbsp;
                        <asp:DropDownList ID="txtMunicipalityCodeAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>  
                        <div class="form-group">
                        <label for="Departamento">SELECCIONE EL DEPARTAMENTO</label>
                        &nbsp;
                        <asp:DropDownList ID="txtdepartmentcodeAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>           
                        <div class="form-group">
                        <label for="Asociacion">SELECCIONE UNA ASOCIACION</label>
                        &nbsp;
                        <asp:DropDownList ID="txtAsociacionAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>                              
                        <div class="form-group">
                        <label for="Ruta">SELECCIONE UNA RUTA</label>
                        &nbsp;
                        <asp:DropDownList ID="txtRutaAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>                              
                        <div class="form-group">
                        <label for="CUIPropietario">SELECCIONE UN CUI DE PROPIETARIO</label>
                        &nbsp;
                        <asp:DropDownList ID="txtCUIAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>                              
                        <div class="form-group">
                        <label for="CuiPiloto">SELECCIONE UN CUI DE PILOTO</label>
                        &nbsp;
                        <asp:DropDownList ID="txtCUIAdd1" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>                              
                            <div class="form-group">
                        <label for="txtNoAfiliacionAdd">INGRESE EL NUMERO DE AFILIACION</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNoAfiliacionAdd" ErrorMessage="EL CAMPO NUMERO DE AFILIACION ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNoAfiliacionAdd" runat="server" placeholder="INGRESE EL NUMERO DE AFILIACION">
                        </div>         
                            <div class="form-group">
                        <label for="txtPinAccesoAdd">INGRESE EL PIN DE ACCESO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPinAccesoAdd" ErrorMessage="EL CAMPO PIN DE ACCESO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtPinAccesoAdd" runat="server" placeholder="INGRESE EL PIN DE ACCESO">
                        </div>         
                            <div class="form-group">
                        <label for="txtConsolaAdd">INGRESE EL NUMERO DE CONSOLA</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtConsolaAdd" ErrorMessage="EL CAMPO CONSOLA ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtConsolaAdd" runat="server" placeholder="INGRESE EL NUMERO DE CONSOLA">
                        </div>         
                            <div class="form-group">
                        <label for="txtLectorAdd">INGRESE EL LECTOR </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLectorAdd" ErrorMessage="EL CAMPO LECTOR ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtLectorAdd" runat="server" placeholder="INGRESE EL LECTOR">
                        </div>  
                           <div class="form-group">
                        <label for="txtFechaInstalacionAdd">FECHA DE INSTALACION</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFechaInstalacionAdd" ErrorMessage="LA FECHA DE INSTALACION ES OBLIGATORIA"></asp:RequiredFieldValidator>
                        <input type="date" class="form-control" id="txtFechaInstalacionAdd" runat="server" placeholder="FECHA DE INSTALACION">
                        </div>  
                           <div class="form-group">
                        <label for="txtRegularoSuplenteAdd">INGRESE SI ES REGULAR O SUPLENTE </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRegularoSuplenteAdd" ErrorMessage="EL CAMPO REGULAR O SUPLENTE ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtRegularoSuplenteAdd" runat="server" placeholder="INGRESE SI ES REGULAR O SUPLENTE">
                        </div>  
                           <div class="form-group">
                        <label for="txtMarcaAdd">INGRESE LA MARCA</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMarcaAdd" ErrorMessage="LA MARCA DEL BUS ES OBLIGATORIA"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtMarcaAdd" runat="server" placeholder="INGRESE LA MARCA DEL BUS">
                        </div>  
                           <div class="form-group">
                        <label for="txtModeloAdd">INGRESE EL MODELO DEL BUS</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtModeloAdd" ErrorMessage="EL MODELO DEL BUS ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtModeloAdd" runat="server" placeholder="INGRESE EL MODELO DEL BUS">
                        </div>  
                           <div class="form-group">
                        <label for="txtAnoAdd">INGRESE EL ANO DEL BUS</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAnoAdd" ErrorMessage="EL ANO DEL BUS ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtAnoAdd" runat="server" placeholder="INGRESE ANO DEL BUS">
                        </div>  
                           <div class="form-group">
                        <label for="txtColorAdd">INGRESE EL COLOR DEL BUS</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtColorAdd" ErrorMessage="EL COLOR DEL BUS ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtColorAdd" runat="server" placeholder="INGRESE EL COLOR DEL BUS">
                        </div>  
                           <div class="form-group">
                        <label for="txtNoPlacaAdd">INGRESE EL NUMERO DE PLACA</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtNoPlacaAdd" ErrorMessage="EL NUMERO DE PLACA ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNoPlacaAdd" runat="server" placeholder="INGRESE EL NUMERO DE PLACA">
                        </div>  
                           <div class="form-group">
                        <label for="txtNoPasajerosAdd">INGRESE EL NUMERO DE PASAJEROS </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNoPasajerosAdd" ErrorMessage="EL NUMERO DE PASAJEROS ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNoPasajerosAdd" runat="server" placeholder="INGRESE EL NUMERO DE PASAJEROS">
                        </div>  
                           <div class="form-group">
                        <label for="txtCombustibleAdd">INGRESE EL TIPO DE COMBUSTIBLE </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtCombustibleAdd" ErrorMessage="EL TIPO DE COMBUSTIBLE ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCombustibleAdd" runat="server" placeholder="INGRESE EL TIPO DE COMBUSTIBLE">
                        </div>  
                           <div class="form-group">
                        <label for="txtTanqueAdd">INGRESE EL TANQUE </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtTanqueAdd" ErrorMessage="EL CAMPO TANQUE ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtTanqueAdd" runat="server" placeholder="INGRESE EL TANQUE">
                        </div>  
                           <div class="form-group">
                        <label for="txtFechaMantAdd">INGRESE EL FECHA DE MANTENIMIENTO </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtFechaMantAdd" ErrorMessage="LA FECHA DE MANTENIMIENTO ES OBLIGATORIA"></asp:RequiredFieldValidator>
                        <input type="Date" class="form-control" id="txtFechaMantAdd" runat="server" placeholder="INGRESE LA FECHA DE MANTENIMIENTO">
                        </div>  
                           <div class="form-group">
                        <label for="txtTipoLLantasAdd">INGRESE EL TIPO DE LLANTAS </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtTipoLLantasAdd" ErrorMessage="EL TIPO DE LLANTAS ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtTipoLLantasAdd" runat="server" placeholder="INGRESE EL TIPO DE LLANTAS">
                        </div>  
                           <div class="form-group">
                        <label for="txtCantidadLlantasAdd">INGRESE LA CANTIDAD DE LLANTAS </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtCantidadLlantasAdd" ErrorMessage="LA CANTIDAD DE LLANTAS ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCantidadLlantasAdd" runat="server" placeholder="INGRESE LA CANTIDAD DE LLANTAS">
                        </div>  
                           <div class="form-group">
                        <label for="txtEstadoVehiculoAdd">INGRESE EL ESTADO DEL VEHICULO </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEstadoVehiculoAdd" ErrorMessage="EL ESTADO DEL VEHICULO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtEstadoVehiculoAdd" runat="server" placeholder="INGRESE EL ESTADO DEL VEHICULO ">
                        </div>  
                           <div class="form-group">
                        <label for="txtComentariosInstalacionAdd">INGRESE LOS COMENTARIOS DE INSTALACION </label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtComentariosInstalacionAdd" ErrorMessage="LOS GASTOS DE INSTALACION ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtComentariosInstalacionAdd" runat="server" placeholder="INGRESE LOS COMENTARIOS DE INSTALACION">
                        </div>  
                           <div class="form-group">
                        <label for="txtSIMAdd">INGRESE EL NUMERO DE SIM</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtSIMAdd" ErrorMessage="EL NUMERO DE SIM ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtSIMAdd" runat="server" placeholder="INGRESE EL NUMERO DE SIM">
                        </div>  
                           <div class="form-group">
                        <label for="txtCampo1Add">INGRESE EL CAMPO 1</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtCampo1Add" ErrorMessage="EL CAMPO 1 ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCampo1Add" runat="server" placeholder="INGRESE EL CAMPO 1">
                        </div>  
                        <div class="form-group">
                        <label for="txtCampo2Add">INGRESE EL CAMPO 2</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtCampo2Add" ErrorMessage="EL CAMPO 2 ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCampo2Add" runat="server" placeholder="INGRESE EL CAMPO 2">
                        </div>  
                        <div class="form-group">
                        <label for="txtCampo3Add">INGRESE EL CAMPO 3</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtCampo3Add" ErrorMessage="EL CAMPO 3 ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCampo3Add" runat="server" placeholder="INGRESE EL CAMPO 3">
                        </div>  
                        <div class="form-group">
                        <label for="txtCampo4Add">INGRESE EL CAMPO 4</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtCampo4Add" ErrorMessage="EL CAMPO 4 ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCampo4Add" runat="server" placeholder="INGRESE EL CAMPO 4">
                        </div>  
                        <div class="form-group">
                        <label for="txtCampo5Add">INGRESE EL CAMPO 5</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtCampo5Add" ErrorMessage="EL CAMPO 5 ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCampo5Add" runat="server" placeholder="INGRESE EL CAMPO 5">
                        </div>  
                        <div class="form-group">
                        <label for="txtCampo6Add">INGRESE EL CAMPO 6</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtCampo6Add" ErrorMessage="EL CAMPO 6 ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCampo6Add" runat="server" placeholder="INGRESE EL CAMPO 6">
                        </div>  
                        <div class="form-group">
                        <label for="txtCampo7Add">INGRESE EL CAMPO 7</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtCampo7Add" ErrorMessage="EL CAMPO 7 ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCampo7Add" runat="server" placeholder="INGRESE EL CAMPO 7">
                        </div>  
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactiveAdd" runat="server">
                        <label class="form-check-label" for="contenido_ckbactiveAdd">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="default.aspx">Inicio</a></li>
            <li class="active">GESTI&Oacute;N DE BUSES</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">GESTI&Oacute;N DE BUSES</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTblBuses.aspx?cmd=add" class="btn btn-success">AGREGAR BUSES</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="NoUNidad" HeaderText="NUMERO DE UNIDAD" />
                        <asp:BoundField DataField="Municipio" HeaderText="MUNICIPIO" />
                        <asp:BoundField DataField="Departamento" HeaderText="DEPARTAMENTO" />
                        <asp:BoundField DataField="Asociacion" HeaderText="TIPO DE ASOCIACION" />
                        <asp:BoundField DataField="Ruta" HeaderText="RUTA" />
                        <asp:BoundField DataField="CUIPropietario" HeaderText="CUI DEL PROPIETARIO" />
                        <asp:BoundField DataField="CuiPiloto" HeaderText="CUI DEL PILOTO" />
                        <asp:BoundField DataField="NoAfiliacion" HeaderText="NUMERO DE AFILIACION" />
                        <asp:BoundField DataField="PinAcceso" HeaderText="PIN DE ACCESO" />
                        <asp:BoundField DataField="Consola" HeaderText="CONSOLA" />
                        <asp:BoundField DataField="Lector" HeaderText="LECTOR" />
                        <asp:BoundField DataField="FechaInstalacion" HeaderText="FECHA DE INSTALACION" />
                        <asp:BoundField DataField="RegularoSuplente" HeaderText="REGULAR O SUPLENTE" />
                        <asp:BoundField DataField="Marca" HeaderText="MARCA DEL BUS" />
                        <asp:BoundField DataField="Modelo" HeaderText="MODELO DEL BUS" />
                        <asp:BoundField DataField="Ano" HeaderText="ANO DEL BUS" />
                        <asp:BoundField DataField="Color" HeaderText="COLOR DEL BUS" />
                        <asp:BoundField DataField="NoPlaca" HeaderText="NUMERO DE PLACA" />
                        <asp:BoundField DataField="NoPasajeros" HeaderText="NUMERO DE PASAJEROS" />
                        <asp:BoundField DataField="Combustible" HeaderText="TIPO DE COMBUSTIBLE" />
                        <asp:BoundField DataField="Tanque" HeaderText="TANQUE" />
                        <asp:BoundField DataField="FechaMant" HeaderText="FECHA DE MANTENIMIENTO" />
                        <asp:BoundField DataField="TipoLLantas" HeaderText="TIPO DE LLANTAS" />
                        <asp:BoundField DataField="CantidadLlantas" HeaderText="CANTIDAD DE LLANTAS" />
                        <asp:BoundField DataField="EstadoVehiculo" HeaderText="ESTADO DEL VEHICULO" />
                        <asp:BoundField DataField="ComentariosInstalacion" HeaderText="COMENTARIOS SOBRE LA INSTALACION" />
                        <asp:BoundField DataField="SIM" HeaderText="SIM" />
                        <asp:BoundField DataField="Campo1" HeaderText="CAMPO 1" />
                        <asp:BoundField DataField="Campo2" HeaderText="CAMPO 2" />
                        <asp:BoundField DataField="Campo3" HeaderText="CAMPO 3" />
                        <asp:BoundField DataField="Campo4" HeaderText="CAMPO 4" />
                        <asp:BoundField DataField="Campo5" HeaderText="CAMPO 5" />
                        <asp:BoundField DataField="Campo6" HeaderText="CAMPO 6" />
                        <asp:BoundField DataField="Campo7" HeaderText="CAMPO 7" />
                        <asp:BoundField DataField="Activo" HeaderText="ACTIVO" />
                        <asp:CommandField ShowSelectButton="True" SelectText="GESTIONAR"  />
                    </Columns>
                </asp:GridView>                
            </div>          
        </div>
        <% } %>

<script type="text/javascript">
    function checkDelete() {
        if (confirm('Esta seguro de eliminar este registro?')) {
            return true;
        }
        else {
            return false;
        }
    }
</script>
    </div>
    </form>
</asp:Content>

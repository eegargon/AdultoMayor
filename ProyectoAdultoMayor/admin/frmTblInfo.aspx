<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblInfo.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblInfo" %>
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
                <li><a href="frmTblInfo.aspx">GESTI&Oacute;N DE INFORMACI&Oacute;N</a></li>
                <li class="active">GESTIONAR INFORMACI&Oacute;N</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">MODIFICAR INFORMACI&Oacute;N</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                         <div class="form-group">
                        <label for="contenido_txtIdInfo">ID DE INFORMACI&Oacute;N</label>
                        <input type="text" class="form-control" id="txtIdInfo" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtBus">INGRESE BUS</label>
                        <input type="text" class="form-control" id="txtBus" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtDepto">NOMBRE DEL DEPARTAMENTO</label>
                        <input type="text" class="form-control" id="txtDepto" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtMuni">NOMBRE DEL MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMuni" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtRuta">INGRESE LA RUTA</label>
                        <input type="text" class="form-control" id="txtRuta" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtMRZ">MRZ</label>
                        <input type="text" class="form-control" id="txtMRZ" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtDPI">INGRESE EL DPI</label>
                        <input type="text" class="form-control" id="txtDPI" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtNombre">NOMBRE DEL USUARIO</label>
                        <input type="text" class="form-control" id="txtNombre" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtApellido">APELLIDO DEL USUARIO</label>
                        <input type="text" class="form-control" id="txtApellido" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtFechaNac">FECHA DE NACIMIENTO</label>
                        <input type="date" class="form-control" id="txtFechaNac" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtAbordaje">FECHA DE ABORDAJE</label>
                        <input type="date" class="form-control" id="txtAbordaje" runat="server" >         
                        </div>                         
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactive" runat="server">
                        <label class="form-check-label" for="contenido_ckbactive">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("IdInfo") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificar" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificar_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="default.aspx">Inicio</a></li>
            <li><a href="frmTblInfo.aspx">GESTI&Oacute;N DE INFORMACI&Oacute;N </a></li>
            <li class="active">AGREGAR INFORMACI&Oacute;N</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">AGREGAR INFORMACI&Oacute;N</div>
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
                        <label for="txtBusAdd">INGRESE EL NUMERO DE BUS</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBusAdd" ErrorMessage="EL CAMPO BUS ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtBusAdd" runat="server" placeholder="INGRESE EL BUS">
                        </div>    
                         <div class="form-group">
                        <label for="txtDeptoAdd">INGRESE EL DEPARTAMENTO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDeptoAdd" ErrorMessage="EL DEPARTAMENTO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtDeptoAdd" runat="server" placeholder="INGRESE EL DEPARTAMENTO">
                        </div>         
                            <div class="form-group">
                        <label for="txtMuniAdd">INGRESE EL MUNICIPIO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMuniAdd" ErrorMessage="EL MUNICIPIO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtMuniAdd" runat="server" placeholder="INGRESE EL MUNICIPIO">
                        </div>         
                            <div class="form-group">
                        <label for="txtRutaAdd">INGRESE LA RUTA</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRutaAdd" ErrorMessage="LA RUTA ES OBLIGATORIA"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtRutaAdd" runat="server" placeholder="INGRESE LA RUTA">
                        </div>         
                            <div class="form-group">
                        <label for="txtMRZAdd">INGRESE MRZ</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMRZAdd" ErrorMessage="EL CAMPO MRZ ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtMRZAdd" runat="server" placeholder="INGRESE MRZ">
                        </div>         
                            <div class="form-group">
                        <label for="txtDPIAdd">INGRESE NUMERO DE DPI</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDPIAdd" ErrorMessage="EL CAMPO DPI ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtDPIAdd" runat="server" placeholder="INGRESE DPI DEL USUARIO">
                        </div>         
                        <div class="form-group">
                        <label for="txtNombreAdd">INGRESE EL NOMBRE DEL USUARIO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNombreAdd" ErrorMessage="EL  NOMBRE DEL USUARIO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNombreAdd" runat="server" placeholder="INGRESE EL NOMBRE DEL USUARIO">
                        </div>         
                            <div class="form-group">
                        <label for="txtApellidoAdd">INGRESE EL APELLIDO DEL USUARIO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtApellidoAdd" ErrorMessage="EL APELLIDO DEL USUARIO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtApellidoAdd" runat="server" placeholder="INGRESE EL APELLIDO DEL USUARIO">
                        </div>
                            <div class="form-group">
                        <label for="txtFechaNacAdd">INGRESE LA FECHA DE NACIMIENTO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFechaNacAdd" ErrorMessage="LA FECHA DE NACIMIENTO ES OBLIGATORIA"></asp:RequiredFieldValidator>
                        <input type="date" class="form-control" id="txtFechaNacAdd" runat="server" placeholder="INGRESE LA FECHA DE NACIMIENTO">
                        </div>         
                            <div class="form-group">
                        <label for="txtAbordajeAdd">INGRESE LA FECHA DE ABORDAJE</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAbordajeAdd" ErrorMessage="LA FECHA DE ABORDAJE ES OBLIGATORIA"></asp:RequiredFieldValidator>
                        <input type="date" class="form-control" id="txtAbordajeAdd" runat="server" placeholder="INGRESE LA FECHA DE ABORDAJE">
                        </div>                                              
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActiveAdd" runat="server">
                        <label class="form-check-label" for="contenido_ckbActiveAdd">ACTIVO</label>
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
            <li class="active">GESTI&Oacute;N DE INFORMACI&Oacute;N</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">GESTI&Oacute;N DE INFORMACI&Oacute;N</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTblInfo.aspx?cmd=add" class="btn btn-success">AGREGAR INFORMACI&Oacute;N</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="IdInfo" HeaderText="ID DE INFORMACION" />
                        <asp:BoundField DataField="Bus" HeaderText="BUS" />
                        <asp:BoundField DataField="Depto" HeaderText="NOMBRE DEL DEPARTAMENTO" />
                        <asp:BoundField DataField="Muni" HeaderText="NOMBRE DEL MUNICIPIO" />
                        <asp:BoundField DataField="Ruta" HeaderText="NOMBRE DE LA RUTA" />
                        <asp:BoundField DataField="MRZ" HeaderText="MRZ" />
                        <asp:BoundField DataField="DPI" HeaderText="NUMERO DE DPI" />
                        <asp:BoundField DataField="Nombre" HeaderText="NOMBRE DEL USUARIO" />
                        <asp:BoundField DataField="Apellido" HeaderText="APELLIDO DEL USUARIO" />
                        <asp:BoundField DataField="FechaNac" HeaderText="FECHA DE NACIMIENTO" />
                        <asp:BoundField DataField="Abordaje" HeaderText="ABORDAJE" />
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

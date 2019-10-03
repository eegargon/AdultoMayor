<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblPurga.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblPurga" %>
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
                <li><a href="frmTblPurga.aspx">GESTI&Oacute;N DE PURGA</a></li>
                <li class="active">GESTIONAR PURGA</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">MODIFICAR PURGA</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                         <div class="form-group">
                        <label for="contenido_txtIdPurga">ID DE UNIDAD</label>
                        <input type="text" class="form-control" id="txtIdPurga" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtNoUnidad">NUMERO DE LA UNIDAD</label>
                        <input type="text" class="form-control" id="txtNoUnidad" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtDpi">DPI DEL USUARIO</label>
                        <input type="text" class="form-control" id="txtDpi" runat="server" >         
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
                        <label for="contenido_txtEdad">EDAD DEL USUARIO</label>
                        <input type="text" class="form-control" id="txtEdad" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtFechaAbordaje">FECHA DE ABORDAJE</label>
                        <input type="date" class="form-control" id="txtFechaAbordaje" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtMRZ">MRZ</label>
                        <input type="text" class="form-control" id="txtMRZ" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtLatitud">LATITUD</label>
                        <input type="text" class="form-control" id="txtLatitud" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtLongitud">LONGITUD</label>
                        <input type="text" class="form-control" id="txtLongitud" runat="server" >         
                        </div>                         
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactive" runat="server">
                        <label class="form-check-label" for="contenido_ckbactive">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("IdPurga") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificar" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificar_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="default.aspx">Inicio</a></li>
            <li><a href="frmTblPurga.aspx">GESTI&Oacute;N DE PURGA</a></li>
            <li class="active">AGREGAR PURGA</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">AGREGAR PURGA</div>
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
                        <label for="txtNoUnidadAdd">INGRESE EL NUMERO DE UNIDAD</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoUnidadAdd" ErrorMessage="EL CAMPO NUMERO DE UNIDAD ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNoUnidadAdd" runat="server" placeholder="INGRESE EL NUMERO DE UNIDAD">
                        </div>    
                         <div class="form-group">
                        <label for="txtDpiAdd">INGRESE EL DPI DEL USUARIO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDpiAdd" ErrorMessage="EL CAMPO DPI ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtDpiAdd" runat="server" placeholder="INGRESE EL DPI DEL USUARIO">
                        </div>         
                            <div class="form-group">
                        <label for="txtNombreAdd">INGRESE EL NOMBRE DEL USUARIO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreAdd" ErrorMessage="EL CAMPO NOMBRE ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNombreAdd" runat="server" placeholder="INGRESE EL NOMBRE DEL USUARIO">
                        </div>         
                            <div class="form-group">
                        <label for="txtApellidoAdd">INGRESE EL APELLIDO DEL USUARIO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtApellidoAdd" ErrorMessage="EL CAMPO APELLIDO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtApellidoAdd" runat="server" placeholder="INGRESE EL APELLIDO DEL USUARIO">
                        </div>         
                            <div class="form-group">
                        <label for="txtFechaNacAdd">INGRESE LA FECHA DE NACIMIENTO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaNacAdd" ErrorMessage="EL CAMPO FECHA DE NACIMIENTO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="Date" class="form-control" id="txtFechaNacAdd" runat="server" placeholder="INGRESE LA FECHA DE NACIMIENTO DEL USUARIO">
                        </div>         
                            <div class="form-group">
                        <label for="txtEdadAdd">INGRESE LA EDAD DEL USUARIO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEdadAdd" ErrorMessage="EL CAMPO EDAD ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtEdadAdd" runat="server" placeholder="INGRESE LA EDAD DEL USUARIO">
                        </div>         
                            <div class="form-group">
                        <label for="txtFechaAbordajeAdd">INGRESE LA FECHA DE ABORDAJE</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFechaAbordajeAdd" ErrorMessage="EL CAMPO FECHA DE ABORDAJE ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="Date" class="form-control" id="txtFechaAbordajeAdd" runat="server" placeholder="INGRESE LA FECHA DE ABORDAJE">
                        </div>         
                            <div class="form-group">
                        <label for="txtMRZAdd">INGRESE EL MRZ</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMRZAdd" ErrorMessage="EL CAMPO MRZ ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtMRZAdd" runat="server" placeholder="INGRESE EL MRZ">
                        </div>         
                            <div class="form-group">
                        <label for="txtLatitudAdd">INGRESE LA LATITUD</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtLatitudAdd" ErrorMessage="EL CAMPO LATITUD ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtLatitudAdd" runat="server" placeholder="INGRESE LA LATITUD">
                        </div>         
                            <div class="form-group">
                        <label for="txtLongitudAdd">INGRESE LA LONGITUD</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLongitudAdd" ErrorMessage="EL CAMPO LONGITUD ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtLongitudAdd" runat="server" placeholder="INGRESE LA LONGITUD">
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
            <li class="active">GESTI&Oacute;N DE PURGA</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">GESTI&Oacute;N DE PURGA</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTblPurga.aspx?cmd=add" class="btn btn-success">AGREGAR PURGA</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="IdPurga" HeaderText="ID DE PURGA" />
                        <asp:BoundField DataField="NoUnidad" HeaderText="NUMERO DE UNIDAD" />
                        <asp:BoundField DataField="Dpi" HeaderText="DPI DEL USUARIO" />
                        <asp:BoundField DataField="Nombre" HeaderText="NOMBRE DEL USUARIO" />
                        <asp:BoundField DataField="Apellido" HeaderText="APELLIDO DEL USUARIO" />
                        <asp:BoundField DataField="FechaNac" HeaderText="FECHA DE NACIMIENTO" />
                        <asp:BoundField DataField="Edad" HeaderText="EDAD DEL USUARIO" />
                        <asp:BoundField DataField="FechaAbordaje" HeaderText="FECHA DE ABORDAJE" />
                        <asp:BoundField DataField="MRZ" HeaderText="MRZ" />
                        <asp:BoundField DataField="Latitud" HeaderText="LATITUD" />
                        <asp:BoundField DataField="Longitud" HeaderText="LONGITUD" />
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

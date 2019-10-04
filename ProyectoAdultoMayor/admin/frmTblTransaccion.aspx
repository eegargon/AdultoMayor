<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblTransaccion.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblTransaccion" %>
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
                <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
                <li><a href="/admin/frmTblTransaccion.aspx">Gesti&oacute;n de Transaccion</a></li>
                <li class="active">Gestionar Transaccion</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Transaccion</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtNoUnidad">Numero de Unidad</label>
                        <input type="text" class="form-control" id="txtNoUnidad"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtDpi">Dpi</label>
                        <input type="text" class="form-control" id="txtDpi" runat="server" />         
                        </div>                        
                        <div class="form-group">
                        <label for="contenido_txtNombre">Nombre</label>
                        <input type="text" class="form-control" id="txtNombre" runat="server"  />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtApellido">Apellido</label>
                        <input type="text" class="form-control" id="txtApellido" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtFechaNac">FechaNac</label>
                        <input type="text" class="form-control" id="txtFechaNac" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtEdad">Edad</label>
                        <input type="text" class="form-control" id="txtEdad" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtFechaAbordaje">FechaAbordaje</label>
                        <input type="text" class="form-control" id="txtFechaAbordaje" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtMrz">Mrz</label>
                        <input type="text" class="form-control" id="txtMrz" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtLatitud">Latitud</label>
                        <input type="text" class="form-control" id="txtLatitud" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtLongitud">Longitud</label>
                        <input type="text" class="form-control" id="txtLongitud" runat="server" />
                        </div>
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Transaccion") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarTransaccion" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarTransaccion_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmTblTransaccion.aspx">Gesti&oacute;n de Transaccion</a></li>
            <li class="active">Agregar Transaccion</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Transaccion</div>
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
                        <label for="txtNoUnidad">Numero de Unidad</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoUnidadAdd" ErrorMessage="El campo Numero de Unidad es obligatorio"></asp:RequiredFieldValidator>
                            <input type="text" class="form-control" id="txtNoUnidadAdd"  runat="server" placeholder="Ingresar el Numero de Unidad">
                        </div>
                        <div class="form-group">
                        <label for="Dpi">Dpi</label>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDpiAdd" ErrorMessage="El campo Dpi es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtDpiAdd" runat="server" placeholder="Ingresar el Dpi" />         
                        </div>
                        <div class="form-group">
                        <label for="Nombre">Nombre</label>
                        <input type="text" class="form-control" id="txtNombreAdd" runat="server"  placeholder="Ingresar el Nombre">
                        </div>
                        <div class="form-group">
                        <label for="Apellido">Apellido</label>
                        <input type="text" class="form-control" id="txtApellidoAdd" runat="server" placeholder="Ingresar el Apellido">
                        </div>
                        <div class="form-group">
                        <label for="FechaNac">Fecha de Nacimiento</label>
                        <input type="text" class="form-control" id="txtFechaNacAdd" runat="server" placeholder="Ingresar la Fecha de nacimiento"/>
                        </div>
                        <div class="form-group">
                        <label for="Edad">Edad</label>
                        <input type="text" class="form-control" id="txtEdadAdd" runat="server" placeholder="Ingrese la edad"/>
                        </div>
                        <div class="form-group">
                        <label for="FechaAbordaje">Fecha de Abordaje</label>
                        <input type="text" class="form-control" id="txtFechaAbordajeAdd" runat="server" placeholder="Ingrese la fecha de abordaje"/>
                        </div>
                        <div class="form-group">
                        <label for="Mrz">Mrz</label>
                        <input type="text" class="form-control" id="txtMrzAdd" runat="server" placeholder="Ingresar Mrz"/>
                        </div>
                        <div class="form-group">
                        <label for="Latitud">Latitud</label>
                        <input type="text" class="form-control" id="txtLatitudAdd" runat="server" placeholder="Ingrese la latitud"/>
                        </div>
                        <div class="form-group">
                        <label for="Longitud">Longitud</label>
                        <input type="text" class="form-control" id="txtLongitudAdd" runat="server" placeholder="Ingrese la longitud"/>
                        </div>

                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label for="contenido_txtActivoAdd">ACTIVO</label> 
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarTransaccion" runat="server" OnClick="btnAgregarTransaccion_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Transaccion</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Transaccion</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmTblTransaccion.aspx?cmd=add" class="btn btn-success">Agregar Transaccion</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="NoUnidad" HeaderText="Numero de Unidad" />
                        <asp:BoundField DataField="Dpi" HeaderText="Dpi" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />   
                        <asp:BoundField DataField="FechaNac" HeaderText="Fecha de nacimiento" />
                        <asp:BoundField DataField="Edad" HeaderText="Edad" />
                        <asp:BoundField DataField="FechaAbordaje" HeaderText="Fecha de abordaje" />
                        <asp:BoundField DataField="Mrz" HeaderText="Mrz" />
                        <asp:BoundField DataField="Latitud" HeaderText="Latitud" />
                        <asp:BoundField DataField="Longitud" HeaderText="Longitud" />
                        <asp:BoundField DataField="activo" HeaderText="ACTIVO" />
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

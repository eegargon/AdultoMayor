<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblPiloto.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblPiloto" %>
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
                <li><a href="/admin/frmTblPiloto.aspx">Gesti&oacute;n de Pilotos</a></li>
                <li class="active">Gesti&oacute;n del Piloto</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Gestionar Piloto</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtCui">CUI</label>
                        <input type="text" class="form-control" id="txtCui"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtNombre">NOMBRE</label>
                        <input type="text" class="form-control" id="txtNombre" runat="server" >         
                        </div>                        
                        <div class="form-group">
                        <label for="contenido_txtNit">NIT</label>
                        <input type="text" class="form-control" id="txtNit" runat="server"  >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtLicencia">LICENCIA</label>
                        <input type="text" class="form-control" id="txtLicencia" runat="server" />
                        </div>
                            <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">Activo</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("cui") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarPiloto" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarPiloto_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmTblPiloto.aspx">Gesti&oacute;n de Pilotos</a></li>
            <li class="active">Agregar Piloto</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Piloto</div>
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
                        <label for="txtCUI">CUI</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCuiAdd" ErrorMessage="El campo CUI es obligatorio"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCuiAdd" ErrorMessage="El CUI debe ser num&eacute;rico de longitud 13" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            <input type="text" class="form-control" id="txtCuiAdd"  runat="server" placeholder="Ingresar el CUI">
                        </div>
                        <div class="form-group">
                        <label for="nombre">NOMBRE</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreAdd" ErrorMessage="El campo Nombre es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNombreAdd" runat="server" placeholder="Ingresar los Nombres y Apellidos">         
                        </div>
                        <div class="form-group">
                        <label for="nit">NIT</label>
                        <input type="text" class="form-control" id="txtNitAdd" runat="server"  placeholder="Ingresar el NIT">
                        </div>
                        <div class="form-group">
                        <label for="licencia">LICENCIA</label>
                        <input type="text" class="form-control" id="txtLicenciaAdd" runat="server" placeholder="Ingresar el n&uacute;mero de Licencia">
                        </div>
                            <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="activo">Activo</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarPiloto" runat="server" OnClick="btnAgregarPiloto_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Pilotos</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Pilotos</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmTblPiloto.aspx?cmd=add" class="btn btn-success">Agregar Piloto</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="cui" HeaderText="CUI" />
                        <asp:BoundField DataField="nombre" HeaderText="NOMBRE" />
                        <asp:BoundField DataField="nit" HeaderText="NIT" />
                        <asp:BoundField DataField="licencia" HeaderText="LICENCIA" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmRefTipoFoto.aspx.cs" Inherits="ProyectoAdultoMayor.frmRefTipoFoto" %>
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
                <li><a href="frmRefTipoFoto.aspx">Gesti&oacute;n de Tipo de Foto</a></li>
                <li class="active">Gestionar Tipo de Foto</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Tipo de Foto</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtCodTipoFoto">CODIGO</label>
                        <input type="text" class="form-control" id="txtCodTipoFoto"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtTipoFoto">TIPO DE FOTO</label>
                        <input type="text" class="form-control" id="txtTipoFoto" runat="server" >         
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("CodTipoFoto") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarCodTipoFoto" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarCodTipoFoto_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="frmRefTipoFoto.aspx">Gesti&oacute;n de Tipo de Foto</a></li>
            <li class="active">Agregar Tipo de Foto</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Tipo de Foto</div>
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
                        <label for="txtCodTipoFoto">CODIGO</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodTipoFotoAdd" ErrorMessage="El campo C&oacute;digo Tipo de Foto es obligatorio"></asp:RequiredFieldValidator>                            
                            <input type="text" class="form-control" id="txtCodTipoFotoAdd"  runat="server" placeholder="Ingresar el C&oacute;digo">
                        </div>
                        <div class="form-group">
                        <label for="Descripcion">TIPO DE FOTO</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTipoFotoAdd" ErrorMessage="El campo Tipo de Foto es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtTipoFotoAdd" runat="server" placeholder="Ingresar la Descripci&oacute;n">         
                        </div>         
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarCodTipoFoto" runat="server" OnClick="btnAgregarCodTipoFoto_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Tipo de Foto</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Tipo de Foto</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmRefTipoFoto.aspx?cmd=add" class="btn btn-success">Agregar Tipo de Foto</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="CodTipoFoto" HeaderText="CODIGO" />
                        <asp:BoundField DataField="TipoFoto" HeaderText="TIPO DE FOTO" />
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

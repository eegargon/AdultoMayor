<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblFoto.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblFoto" %>
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
                <li><a href="/admin/frmTblFoto.aspx">GESTI&Oacute;N DE FOTOS</a></li>
                <li class="active">GESTIONAR FOTOS</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">MODIFICAR FOTOS</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtIdFoto">ID DE FOTO</label>
                        <input type="text" class="form-control" id="txtIdFoto"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtUnidad">UNIDAD</label>
                        <input type="text" class="form-control" id="txtUnidad" runat="server" readonly="readonly">         
                        </div> 
                         <div class="form-group">
                        <label for="contenido_txtTipoFoto">TIPO DE FOTO</label>
                        <input type="text" class="form-control" id="txtTipoFoto" runat="server" readonly="readonly">         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtimagen">IMAGEN</label>
                        <input type="text" class="form-control" id="txtimagen" runat="server" >         
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("IdFoto") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarIdFoto" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarIdFoto_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmTblFoto.aspx">GESTI&Oacute;N DE FOTOS</a></li>
            <li class="active">AGREGAR FOTOS</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">AGREGAR FOTOS</div>
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
                        <label for="Unidad">UNIDAD</label>
                        &nbsp;
                        <asp:DropDownList ID="txtUnidadAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>     
                          <div class="form-group">
                        <label for="TipoFoto">TIPO DE FOTO</label>
                        &nbsp;
                        <asp:DropDownList ID="txtTipoFotoAdd" runat="server" CssClass="form-control">                        
                        </asp:DropDownList>
                        </div>     
                        <div class="form-group">
                          <label for="imagen">IMAGEN</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtimagenAdd" ErrorMessage="EL CAMPO  IMAGEN ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtimagenAdd" runat="server" placeholder="INGRESAR LA IMAGEN">         
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarIdFoto" runat="server" OnClick="btnAgregarIdFoto_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">GESTI&Oacute;N DE FOTOS<</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">GESTI&Oacute;N DE FOTOS</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmTblFoto.aspx?cmd=add" class="btn btn-success">AGREGAR FOTO</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="IdFoto" HeaderText="ID DE FOTO" />
                        <asp:BoundField DataField="Unidad" HeaderText="UNIDAD" />
                        <asp:BoundField DataField="TipoFoto" HeaderText="TIPO DE FOTO" />
                        <asp:BoundField DataField="imagen" HeaderText="IMAGEN" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTbl_Foto.aspx.cs" Inherits="ProyectoAdultoMayor.frmTbl_Foto" %>
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
                <li><a href="default.aspx">Inicio</a>&nbsp;&nbsp;&nbsp;&nbsp; </li>
                <li><a href="frmTbl_Foto.aspx">Gesti&oacute;n de Foto</a>&nbsp;&nbsp;&nbsp; </li>
                <li class="active">&nbsp;&nbsp;&nbsp;&nbsp; Gestionar Fotos</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Fotos</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">
                        <label for="txtUnidad1">Unidad1</label>
                        &nbsp;
                            <asp:TextBox ID="txtUnidad1" runat="server" CssClass="form-control muted-text" ReadOnly="True" ></asp:TextBox>
                        </div> 
                         <div class="form-group">                        
                        <label for="contenido_txtIdFoto">Id de foto</label>
                        <input type="text" class="form-control" id="txtIdFoto"  runat="server" readonly="readonly" >
                        </div>
                         <div class="form-group">                        
                        <label for="contenido_txtUnidad">UNIDAD</label>
                        <input type="text" class="form-control" id="txtUnidad"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtTipoFoto">TIPO DE FOTO</label>
                        <input type="text" class="form-control" id="txtTipoFoto" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtImagen">IMAGEN</label>
                        <input type="text" class="form-control" id="txtImagen" runat="server" >         
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactive" runat="server">
                        <label class="form-check-label" for="contenido_ckbactive">ACTIVO</label>
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
            <li><a href="default.aspx">Inicio</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
            <li><a href="frmTbl_Foto.aspx">Gesti&oacute;n de Fotos</a></li>
            <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
            <li class="active">Agregar Foto</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Foto</div>
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
                        <label for="">NUMERO DE UNIDAD</label> 
                        &nbsp;                            
                        <asp:DropDownList ID="DropDownNoUnidadAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>                  
                        </div>        
                        <div class="form-group">
                        <label for="">TIPO FOTO</label> 
                        &nbsp;                            
                        <asp:DropDownList ID="txtTipoFotoAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>                  
                        </div>                                              
                        <div class="form-group">
                        <label for="Imagen">Imagen</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtimagenAdd" ErrorMessage="El campo Imagen es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtImagenAdd" runat="server" placeholder="Ingresar una Imagen">
                        </div>         
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActiveAdd" runat="server">
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
            <li><a href="default.aspx">Inicio</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
            <li class="active">Gesti&oacute;n de Foto</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Foto</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTbl_Foto.aspx?cmd=add" class="btn btn-success">Agregar Foto</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Unidad" HeaderText="UNIDAD DE FOTO" />
                        <asp:BoundField DataField="IdFoto" HeaderText="ID DE FOTO" />
                        <asp:BoundField DataField="TipoFoto" HeaderText="TIPO DE LA FOTO" />
                        <asp:BoundField DataField="Imagen" HeaderText="IMAGEN" />
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

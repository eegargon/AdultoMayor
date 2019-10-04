<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblLector.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblLector" %>
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
                <li><a href="/admin/frmTblLector.aspx">Gesti&oacute;n de Lector</a></li>
                <li class="active">Gestionar Lector</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Lector</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtLector">LECTOR</label>
                        <input type="text" class="form-control" id="txtLector"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtNoSerie">No. SERIE</label>
                        <input type="text" class="form-control" id="txtNoSerie" runat="server" >         
                        </div>                        
                        <div class="form-group">
                        <label for="contenido_txtModelo">MODELO</label>
                        <input type="text" class="form-control" id="txtModelo" runat="server"  >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtColorFOB">COLOR FOB</label>
                        <input type="text" class="form-control" id="txtColorFOB" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtInstalada">INSTALADA</label>
                        <input type="text" class="form-control" id="txtInstalada" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtControlInventario">CONTROL INVENTARIO</label>
                        <input type="text" class="form-control" id="txtControlInventario" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtUbicacion">UBICACION</label>
                        <input type="text" class="form-control" id="txtUbicacion" runat="server" />
                        </div>
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Lector") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarLector" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarLector_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmTblLector.aspx">Gesti&oacute;n de Lector</a></li>
            <li class="active">Agregar Lector</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Lector</div>
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
                        <label for="txtLector">LECTOR</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLectorAdd" ErrorMessage="El campo Lector es obligatorio"></asp:RequiredFieldValidator>
                            <input type="text" class="form-control" id="txtLectorAdd"  runat="server" placeholder="Ingresar el Lector">
                        </div>
                        <div class="form-group">
                        <label for="NoTelefono">No. SERIE</label>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoSerieAdd" ErrorMessage="El campo Serie es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNoSerieAdd" runat="server" placeholder="Ingresar el N&uacute;mero de Serie">         
                        </div>
                        <div class="form-group">
                        <label for="Modelo">MODELO</label>
                        <input type="text" class="form-control" id="txtModeloAdd" runat="server"  placeholder="Ingresar el Modelo">
                        </div>                        
                        <div class="form-group">
                        <label for="ColorFOB">COLOR FOB</label>
                        <input type="text" class="form-control" id="txtColorFOBAdd" runat="server" placeholder="Ingresar el Color"/>
                        </div>
                        <div class="form-group">
                        <label for="Instalado">INSTALADA</label>
                        <input type="text" class="form-control" id="txtInstaladaAdd" runat="server" placeholder="Ingresar Si/No"/>
                        </div>
                        <div class="form-group">
                        <label for="CostoInventario">CONTROL INVENTARIO</label>
                        <input type="text" class="form-control" id="txtControlInventarioAdd" runat="server" placeholder="Ingresar el Control "/>
                        </div>
                        <div class="form-group">
                        <label for="Ubicacion">UBICACION</label>
                        <input type="text" class="form-control" id="txtUbicacionAdd" runat="server" placeholder="Ingresar la Ubicaci&oacute;m"/>
                        </div>
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server" checked="checked">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarLector" runat="server" OnClick="btnAgregarLector_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Lector</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Lector</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmTblLector.aspx?cmd=add" class="btn btn-success">Agregar Lector</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Lector" HeaderText="LECTOR" />
                        <asp:BoundField DataField="NoSerie" HeaderText="No. SERIE" />
                        <asp:BoundField DataField="Modelo" HeaderText="MODELO" /> 
                        <asp:BoundField DataField="ColorFOB" HeaderText="COLOR FOB" />
                        <asp:BoundField DataField="Instalada" HeaderText="INSTALADA" />
                        <asp:BoundField DataField="ControlInventario" HeaderText="CONTROL INVENTARIO" />
                        <asp:BoundField DataField="Ubicacion" HeaderText="UBICACION" />
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

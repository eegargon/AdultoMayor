<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblTablet.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblTablet" %>
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
                <li><a href="/admin/frmTblTablet.aspx">Gesti&oacute;n de Tablet</a></li>
                <li class="active">Gestionar Tablet</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Tablet</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtConsola">CONSOLA</label>
                        <input type="text" class="form-control" id="txtConsola"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtNoSerie">SERIE</label>
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
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Consola") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarTablet" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarTablet_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmTblTablet.aspx">Gesti&oacute;n de Tablet</a></li>
            <li class="active">Agregar Tablet</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Tablet</div>
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
                        <label for="txtConsola">CONSOLA</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConsolaAdd" ErrorMessage="El campo Consola es obligatorio"></asp:RequiredFieldValidator>
                            <input type="text" class="form-control" id="txtConsolaAdd"  runat="server" placeholder="Ingresar Consola">
                        </div>
                        <div class="form-group">
                        <label for="NoSerie">NUMERO DE SERIE</label>
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
                        <label for="ControlInventario">CONTROL DE INVENTARIO</label>
                        <input type="text" class="form-control" id="txtControlInventarioAdd" runat="server" placeholder="Ingresar el Control de Inventario"/>
                        </div>
                        <div class="form-group">
                        <label for="Ubicacion">UBICACION</label>
                        <input type="text" class="form-control" id="txtUbicacionAdd" runat="server" placeholder="Ingresar la Ubicaci&oacute;m"/>
                        </div>
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarTablet" runat="server" OnClick="btnAgregarTablet_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Tablet</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Tablet</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmTblTablet.aspx?cmd=add" class="btn btn-success">Agregar Tablet</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Consola" HeaderText="CONSOLA" />
                        <asp:BoundField DataField="NoSerie" HeaderText="NUMERO DE SERIE" />
                        <asp:BoundField DataField="Modelo" HeaderText="MODELO" />  
                        <asp:BoundField DataField="ColorFOB" HeaderText="COLOR FOB" />
                        <asp:BoundField DataField="Instalada" HeaderText="INSTALADA" />
                        <asp:BoundField DataField="ControlInventario" HeaderText="CONTROL DE INVENTARIO" />
                        <asp:BoundField DataField="Ubicacion" HeaderText="UBICACION" />
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

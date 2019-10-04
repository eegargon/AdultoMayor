<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblSim.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblSim" %>
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
                <li><a href="/admin/frmTblSIM.aspx">Gesti&oacute;n de SIM</a></li>
                <li class="active">Gestionar SIM</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar SIM</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtSIM">SIM</label>
                        <input type="text" class="form-control" id="txtSIM"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtNoTelefono">TELEFONO</label>
                        <input type="text" class="form-control" id="txtNoTelefono" runat="server" >         
                        </div>                        
                        <div class="form-group">
                        <label for="contenido_txtModelo">MODELO</label>
                        <input type="text" class="form-control" id="txtModelo" runat="server"  >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtOperador">OPERADOR</label>
                        <input type="text" class="form-control" id="txtOperador" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtColorFOB">COLOR FOB</label>
                        <input type="text" class="form-control" id="txtColorFOB" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtInstalado">INSTALADO</label>
                        <input type="text" class="form-control" id="txtInstalado" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtCostoInventario">COSTO</label>
                        <input type="text" class="form-control" id="txtCostoInventario" runat="server" />
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
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("SIM") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarSIM" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarSIM_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmTblSIM.aspx">Gesti&oacute;n de SIM</a></li>
            <li class="active">Agregar SIM</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar SIM</div>
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
                        <label for="txtSIM">SIM</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSIMAdd" ErrorMessage="El campo SIM es obligatorio"></asp:RequiredFieldValidator>
                            <input type="text" class="form-control" id="txtSIMAdd"  runat="server" placeholder="Ingresar el SIM">
                        </div>
                        <div class="form-group">
                        <label for="NoTelefono">TELEFONO</label>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoTelefonoAdd" ErrorMessage="El campo Tel&eacute;fono es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtNoTelefonoAdd" runat="server" placeholder="Ingresar el Tel&eacute;fono">         
                        </div>
                        <div class="form-group">
                        <label for="Modelo">MODELO</label>
                        <input type="text" class="form-control" id="txtModeloAdd" runat="server"  placeholder="Ingresar el Modelo">
                        </div>
                        <div class="form-group">
                        <label for="Operador">OPERADOR</label>
                        <input type="text" class="form-control" id="txtOperadorAdd" runat="server" placeholder="Ingresar el Operador">
                        </div>
                        <div class="form-group">
                        <label for="ColorFOB">COLOR FOB</label>
                        <input type="text" class="form-control" id="txtColorFOBAdd" runat="server" placeholder="Ingresar el Color"/>
                        </div>
                        <div class="form-group">
                        <label for="Instalado">INSTALADO</label>
                        <input type="text" class="form-control" id="txtInstaladoAdd" runat="server" placeholder="Ingresar Si/No"/>
                        </div>
                        <div class="form-group">
                        <label for="CostoInventario">COSTO</label>
                        <input type="text" class="form-control" id="txtCostoInventarioAdd" runat="server" placeholder="Ingresar el Costo "/>
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
                            <asp:Button ID="btnAgregarSIM" runat="server" OnClick="btnAgregarSIM_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de SIM</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de SIM</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmTblSIM.aspx?cmd=add" class="btn btn-success">Agregar SIM</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="SIM" HeaderText="SIM" />
                        <asp:BoundField DataField="NoTelefono" HeaderText="TELEFONO" />
                        <asp:BoundField DataField="Modelo" HeaderText="MODELO" />
                        <asp:BoundField DataField="Operador" HeaderText="OPERADOR" />   
                        <asp:BoundField DataField="ColorFOB" HeaderText="COLOR FOB" />
                        <asp:BoundField DataField="Instalado" HeaderText="INSTALADO" />
                        <asp:BoundField DataField="CostoInventario" HeaderText="COSTO" />
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

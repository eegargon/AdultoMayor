<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblRuta.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblRuta" %>
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
                <li><a href="/admin/frmTblRuta.aspx">Gesti&oacute;n de Rutas</a></li>
                <li class="active">Gestionar Ruta</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Ruta</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtRuta">RUTA</label>
                        <input type="text" class="form-control" id="txtRuta"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtDescripcion">DESCRIPCION</label>
                        <input type="text" class="form-control" id="txtDescripcion" runat="server" >         
                        </div>                        
                        <div class="form-group">
                        <label for="contenido_txtRecorrido">RECORRIDO</label>
                        <input type="text" class="form-control" id="txtRecorrido" runat="server"  >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtKilometrosRuta">DISTANCIA (KM)</label>
                        <input type="text" class="form-control" id="txtKilometrosRuta" runat="server" />
                        </div>
                            <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Ruta") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarRuta" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarRuta_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmTblRuta.aspx">Gesti&oacute;n de Rutas</a></li>
            <li class="active">Agregar Ruta</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Ruta</div>
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
                        <label for="txtRuta">RUTA</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRutaAdd" ErrorMessage="El campo Ruta es obligatorio"></asp:RequiredFieldValidator>                            
                            <input type="text" class="form-control" id="txtRutaAdd"  runat="server" placeholder="Ingresar la Ruta">
                        </div>
                        <div class="form-group">
                        <label for="Descripcion">DESCRIPCION</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcionAdd" ErrorMessage="El campo Descripci&oacute;n es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtDescripcionAdd" runat="server" placeholder="Ingresar la Descripcion">         
                        </div>
                        <div class="form-group">
                        <label for="Recorrido">RECORRIDO</label>
                        <input type="text" class="form-control" id="txtRecorridoAdd" runat="server"  placeholder="Ingresar el Recorrido">
                        </div>
                        <div class="form-group">
                        <label for="KilometrosRuta">DISTANCIA (KM)</label>
                        <input type="text" class="form-control" id="txtKilometrosRutaAdd" runat="server" placeholder="Ingresar el n&uacute;mero de Kilometros">
                        </div>
                            <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarRuta" runat="server" OnClick="btnAgregarRuta_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Rutas</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Rutas</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmTblRuta.aspx?cmd=add" class="btn btn-success">Agregar Ruta</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Ruta" HeaderText="RUTA" />
                        <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" />
                        <asp:BoundField DataField="Recorrido" HeaderText="RECORRIDO" />
                        <asp:BoundField DataField="KilometrosRuta" HeaderText="DISTANCIA (KM)" />
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

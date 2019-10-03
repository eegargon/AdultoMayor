<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblAsociacion.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblAsociacion" %>
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
                <li><a href="frmTblAsociacion.aspx">Gesti&oacute;n de Asociaci&oacute;n</a></li>
                <li class="active">Gestionar Asociaci&oacute;n</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Asociaci&oacute;n</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtAsociacion">ASOCIACION</label>
                        <input type="text" class="form-control" id="txtAsociacion"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtDescripcion">DESCRIPCION</label>
                        <input type="text" class="form-control" id="txtDescripcion" runat="server" >         
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Asociacion") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarAsociacion" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarAsociacion_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="frmTblAsociacion.aspx">Gesti&oacute;n de Asociaci&oacute;n</a></li>
            <li class="active">Agregar Asociaci&oacute;n</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Asociaci&oacute;n</div>
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
                        <label for="txtAsociacion">ASOCIACION</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAsociacionAdd" ErrorMessage="El campo Asociaci&oacute;n es obligatorio"></asp:RequiredFieldValidator>                            
                            <input type="text" class="form-control" id="txtAsociacionAdd"  runat="server" placeholder="Ingresar la Asociacion">
                        </div>
                        <div class="form-group">
                        <label for="Descripcion">DESCRIPCION</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcionAdd" ErrorMessage="El campo Descripci&oacute;n es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtDescripcionAdd" runat="server" placeholder="Ingresar la Descripcion">         
                        </div>         
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarAsociacion" runat="server" OnClick="btnAgregarAsociacion_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Asociaci&oacute;n</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Asociaci&oacute;n</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTblAsociacion.aspx?cmd=add" class="btn btn-success">Agregar Asociaci&oacute;n</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Asociacion" HeaderText="ASOCIACION" />
                        <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" />
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

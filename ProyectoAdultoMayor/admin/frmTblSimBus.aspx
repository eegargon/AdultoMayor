<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblSimBus.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblSimBus" %>
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
                <li><a href="frmTblSimBus.aspx">Gesti&oacute;n de Buses Por SIM</a></li>
                <li class="active">Gestionar SIM</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar SIM</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">
                        <label for="txtSIM">SIM</label>
                        &nbsp;
                            <asp:TextBox ID="txtSIM" runat="server" CssClass="form-control muted-text" ReadOnly="True" ></asp:TextBox>
                        </div> 
                        <div class="form-group">
                        <label for="Unidad">Unidad</label>
                        &nbsp;
                            &nbsp;<asp:TextBox ID="txtUnidad" runat="server" CssClass="form-control muted-text" ReadOnly="True" ></asp:TextBox>
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
            <li><a href="frmTblSimBus.aspx">Gesti&oacute;n de SIM</a></li>
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
                        <label for="SIM">SIM</label> 
                        &nbsp;                            
                        <asp:DropDownList ID="txtSIMAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>                  
                        </div>
                        <div class="form-group">
                        <label for="Unidad">Unidad</label>
                        &nbsp;
                        <asp:DropDownList ID="txtUnidadAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <asp:Label ID="lblError" runat="server" Text=" "></asp:Label>
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
                    <a href="frmTblSimBus.aspx?cmd=add" class="btn btn-success">Agregar SIM</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="SIM" HeaderText="SIM" />
                        <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
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

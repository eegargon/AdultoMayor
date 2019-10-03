<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblTabletBus.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblTabletBus" %>
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
                <li><a href="default.aspx">Inicio</a></li>
                <li><a href="frmTblSimBus.aspx">Gesti&oacute;n de Tablet Bus</a></li>
                <li class="active">Gestionar Tablet Bus</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Tablet Bus</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">
                        <label for="txtConsola">Consola</label>
                        &nbsp;
                            <asp:TextBox ID="txtConsola" runat="server" CssClass="form-control muted-text" ReadOnly="True" ></asp:TextBox>
                        </div> 
                        <div class="form-group">
                        <label for="Unidad">Bus</label>
                        &nbsp;
                            &nbsp;<asp:TextBox ID="txtUnidad" runat="server" CssClass="form-control muted-text" ReadOnly="True" ></asp:TextBox>
                        </div>                       
                        <div class="form-group">
                        <label for="contenido_txtEstatus">ESTADO</label>
                            <asp:TextBox ID="txtEstatus" runat="server" CssClass="form-control" ></asp:TextBox>
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
            <li><a href="default.aspx">Inicio</a></li>
            <li><a href="frmTblSimBus.aspx">Gesti&oacute;n de Tablet Bus</a></li>
            <li class="active">Agregar Tablet Bus</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Tablet Bus</div>
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
                        <label for="Consola">Consola</label> 
                        &nbsp;                            
                        <asp:DropDownList ID="txtConsolaAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>                  
                        </div>
                        <div class="form-group">
                        <label for="Bus">BUS</label>
                        &nbsp;
                        <asp:DropDownList ID="txtBusAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtEstatus">ESTADO</label>
                            <asp:TextBox ID="txtEstatusAdd" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>                        

                        <div class="form-check">
                            <asp:CheckBox runat="server" ID="ckbActivoAdd" CssClass="form-check-input" />
                        <label class="form-check-label" for="contenido_ckbActivoAdd">ACTIVO</label>
                                <br />
                        </div>
                        <asp:Label ID="lblError" runat="server" Text=" "></asp:Label>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarTabletBus" runat="server" OnClick="btnAgregarTabletBus_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="default.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Tablet Bus</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Tablet Bus</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTblTabletBus.aspx?cmd=add" class="btn btn-success">Agregar Tablet Bus</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Consola" HeaderText="CONSOLA" />
                        <asp:BoundField DataField="Bus" HeaderText="BUS" />
                        <asp:BoundField DataField="Estatus" HeaderText="ESTADO" />
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


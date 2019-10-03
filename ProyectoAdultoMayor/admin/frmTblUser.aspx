<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTblUser.aspx.cs" Inherits="ProyectoAdultoMayor.frmTblUser" %>
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
                <li><a href="frmTblUser.aspx">Gesti&oacute;n de Usuarios</a></li>
                <li class="active">GESTIONAR USUARIOS</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Usuarios</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">
                        <label for="contenido_txtUserName">NOMBRE DE USUARIO (SIN ESPACIOS)</label>
                        <input type="text" class="form-control" id="txtUserName" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtUserPassword">CONTRASENA DE USUARIO</label>
                        <input type="text" class="form-control" id="txtUserPassword" runat="server" >         
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactive" runat="server">
                        <label class="form-check-label" for="contenido_ckbactive">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("UserName") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarIdUser" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarIdUser_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="frmTblUser.aspx">Gesti&oacute;n de Usuarios</a></li>
            <li class="active">Agregar Usuario</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Usuario</div>
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
                        <label for="txtUsername">Nombre del Usuario</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserNameAdd" ErrorMessage="El Nombre de Usuario es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtUserNameAdd" runat="server" placeholder="Ingresar el Nombre">     
                         <div class="form-group">
                        <label for="txtUserPassword">Contrasena de Usuario</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserPasswordAdd" ErrorMessage="La contrasena del Usuario es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtUserPasswordAdd" runat="server" placeholder="Ingresar la contrasena del Usuario">
                        </div>         
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActiveAdd" runat="server">
                        <label class="form-check-label" for="contenido_ckbActiveAdd">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarIdUser" runat="server" OnClick="btnAgregar_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Usuarios</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Usuarios</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTblUser.aspx?cmd=add" class="btn btn-success">Agregar Usuario</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="NOMBRE DEL USUARIO" />
                        <asp:BoundField DataField="UserPassword" HeaderText="CONTRASENA DEL USUARIO" />
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

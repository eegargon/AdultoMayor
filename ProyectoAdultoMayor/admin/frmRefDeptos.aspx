<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmRefDeptos.aspx.cs" Inherits="ProyectoAdultoMayor.frmRefDeptos" %>
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
                <li><a href="frmRefDeptos.aspx">Gesti&oacute;n de Departamentos</a></li>
                <li class="active">Gestionar Departamentos</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Departamentos</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtDepartmentcode">CODIGO</label>
                        <input type="text" class="form-control" id="txtDepartmentcode"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtDepartmentname">NOMBRE</label>
                        <input type="text" class="form-control" id="txtDepartmentname" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtdeptCedula">CODIGO CEDULA</label>
                        <input type="text" class="form-control" id="txtdeptCedula" runat="server" >         
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactive" runat="server">
                        <label class="form-check-label" for="contenido_ckbactive">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("departmentcode") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificardepartmentcode" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificardepartmentcode_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="frmRefDeptos.aspx">Gesti&oacute;n de Departamentos</a></li>
            <li class="active">Agregar Departamento</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Departamento</div>
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
                        <label for="txtDepartmentcode">CODIGO</label> 
                            &nbsp;
                        <asp:CustomValidator ID="CV_Valida_Codigo" runat="server" ControlToValidate="txtDepartmentcodeAdd" ErrorMessage="El C&oacute;digo debe ser num&eacute;rico de longitud 2" OnServerValidate="Valida_Codigo"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDepartmentcodeAdd" ErrorMessage="El campo C&oacute;digo es obligatorio"></asp:RequiredFieldValidator>                            
                            <input type="text" class="form-control" id="txtDepartmentcodeAdd"  runat="server" placeholder="Ingresar el C&oacute;digo">
                        </div>
                        <div class="form-group">
                        <label for="Descripcion">NOMBRE</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDepartmentnameAdd" ErrorMessage="El campo Descripci&oacute;n es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtDepartmentnameAdd" runat="server" placeholder="Ingresar el Nombre">     
                         <div class="form-group">
                        <label for="Descripcion">CODIGO CEDULA</label>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDepartmentnameAdd" ErrorMessage="El campo C&oacute;digo de C&eacute;dula es obligatorio"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtdeptcedullaAdd" runat="server" placeholder="Ingresar el C&oacute;digo de C&eacute;dula">
                        </div>         
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActiveAdd" runat="server">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregardepartmentcode" runat="server" OnClick="btnAgregardepartmentcode_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Departamentos</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Departamentos</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmRefDeptos.aspx?cmd=add" class="btn btn-success">Agregar Departamento</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="departmentcode" HeaderText="CODIGO" />
                        <asp:BoundField DataField="departmentname" HeaderText="NOMBRE" />
                        <asp:BoundField DataField="deptcedula" HeaderText="CODIGO DE CEDULA" />
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

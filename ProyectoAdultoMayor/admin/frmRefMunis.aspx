<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmRefMunis.aspx.cs" Inherits="ProyectoAdultoMayor.frmRefMunis" %>
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
                <li><a href="/admin/frmRefMunis.aspx">Gesti&oacute;n de Municipios</a></li>
                <li class="active">Gestionar Municipio</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar Municipio</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">
                        <div class="form-group">                        
                        <label for="contenido_txtMunicipalityCode">CODIGO MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMunicipalityCode"  runat="server" readonly="readonly" >
                        </div>                        
                        <div class="form-group">
                        <label for="Unidad">CODIGO DEPARTAMENTO</label>
                        &nbsp;
                            &nbsp;<asp:TextBox ID="txtDepartmentCode" runat="server" CssClass="form-control muted-text"></asp:TextBox>
                        </div>   
                        <div class="form-group">                        
                        <label for="contenido_txtMunicipalityName">NOMBRE MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMunicipalityName"  runat="server" >
                        </div> 
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("MUNICIPALITYCODE") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarMunicipio" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarMunicipio_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmRefMunis.aspx">Gesti&oacute;n de Municipio</a></li>
            <li class="active">Agregar Municipio</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Municipio</div>
            <div class="panel panel-body">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
<asp:ScriptManager ID="sm1" runat="server">  
  <Scripts>  
    <asp:ScriptReference Name="jquery"/>  
  </Scripts>  
</asp:ScriptManager>  <div class="form-group">                        
                        <label for="contenido_txtMunicipalityCode">CODIGO MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMunicipalityCodeAdd"  runat="server" >
                        </div>                       
                        <div class="form-group">
                        <label for="departmentcode">CODIGO DEPARTAMENTO</label>
                        &nbsp;
                        <asp:DropDownList ID="txtDepartmentCodeAdd" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        </div>
                        <div class="form-group">                        
                        <label for="contenido_txtMunicipalityName">NOMBBRE MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMunicipalityNameAdd"  runat="server" >
                        </div>   
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server">
                        <label class="form-check-label" for="contenido_activo">ACTIVO</label>
                                <br />
                        </div>
                        <asp:Label ID="lblError" runat="server" Text=" "></asp:Label>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarMunicipio" runat="server" OnClick="btnAgregarMunicipio_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Municipio</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Municipio</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmRefMunis.aspx?cmd=add" class="btn btn-success">Agregar Municipio</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="MUNICIPALITYCODE" HeaderText="CODIGO MUNICIPIO" />
                        <asp:BoundField DataField="departmentcode" HeaderText="CODIGO DEPARTAMENTO" />
                        <asp:BoundField DataField="MUNICIPALITYNAME" HeaderText="NOMBRE MUNICIPIO" />
                        <asp:BoundField DataField="active" HeaderText="ACTIVO" />
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

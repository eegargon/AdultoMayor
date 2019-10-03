<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmTbl_Unidades_Depto.aspx.cs" Inherits="ProyectoAdultoMayor.frmTbl_Unidades_Depto" %>
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
                <li><a href="frmTbl_Unidades_Depto.aspx">Gesti&oacute;n de Unidades por departamento</a></li>
                <li class="active">Gestionar Unidades por departamento</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">Modificar UnidadesDepto</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                        <div class="form-group">                        
                        <label for="contenido_txtCod">CODIGO</label>
                        <input type="text" class="form-control" id="txtCod"  runat="server" readonly="readonly" >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtCantidad">CANTIDAD</label>
                        <input type="text" class="form-control" id="txtCantidad" runat="server" >         
                        </div>                        
                        <div class="form-group">
                        <label for="contenido_txtAsociacion">ASOCIACION</label>
                        <input type="text" class="form-control" id="txtAsociacion" runat="server"  >
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtDepto">DEPARTAMENTO</label>
                        <input type="text" class="form-control" id="txtDepto" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtMuni">MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMuni" runat="server" />
                        </div>
                        <div class="form-group">
                        <label for="contenido_txtOrderInstalacion">ORDEN DE INSTALACION</label>
                        <input type="text" class="form-control" id="txtOrderInstalacion" runat="server" />
                        </div>
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbactivo" runat="server">
                        <label class="form-check-label" for="contenido_ckbactivo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("UnidadesDepto") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificarUnidadesDepto" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificarUnidadesDepto_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="default.aspx">Inicio</a></li>
            <li><a href="frmTbl_Unidades_Depto.aspx">Gesti&oacute;n de Unidades por departamento</a></li>
            <li class="active">Agregar Unidades por departamento</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">Agregar Unidades por Departamento</div>
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
                        <label for="txtCod">CODIGO</label> 
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodAdd" ErrorMessage="EL CAMPO CODIGO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                            <input type="text" class="form-control" id="txtCodAdd"  runat="server" placeholder="INGRESAR EL CODIGO">
                        </div>
                        <div class="form-group">
                        <label for="Cantidad">CANTIDAD</label>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidadAdd" ErrorMessage="EL CAMPO CANTIDAD ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtCantidadAdd" runat="server" placeholder="INGRESAR LA CANTIDAD">         
                        </div>
                        <div class="form-group">
                        <label for="Asociacion">ASOCIACION</label>
                        <input type="text" class="form-control" id="txtAsociacionAdd" runat="server"  placeholder="INGRESAR LA ASOCIACION">
                        </div>                        
                        <div class="form-group">
                        <label for="Depto">DEPARTAMENTO</label>
                        <input type="text" class="form-control" id="txtDeptoAdd" maxlength ="2" runat="server" placeholder="INGRESAR EL DEPARTAMENTO"/>
                        </div>
                        <div class="form-group">
                        <label for="Muni">MUNICIPIO</label>
                        <input type="text" class="form-control" id="txtMuniAdd" maxlength ="2" runat="server" placeholder="INGRESAR EL MUNICIPIO"/>
                        </div>
                        <div class="form-group">
                        <label for="OrderInstalacion">ORDEN DE INSTALACION</label>
                        <input type="text" class="form-control" id="txtOrderInstalacionAdd" runat="server" placeholder="INGRESAR LA ORDEN DE INSTALACION"/>
                        </div>
                        <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="ckbActivoAdd" runat="server" checked="checked">
                        <label class="form-check-label" for="activo">ACTIVO</label>
                                <br />
                        </div>
                        <br />
                            <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                            <asp:Button ID="btnAgregarUnidadesDepto" runat="server" OnClick="btnAgregarUnidadesDepto_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="default.aspx">Inicio</a></li>
            <li class="active">Gesti&oacute;n de Unidades por departmento</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">Gesti&oacute;n de Unidades por departamento</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="frmTbl_Unidades_Depto.aspx?cmd=add" class="btn btn-success">AGREGAR A UNIDADES POR DEPARTAMENTO</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Cod" HeaderText="CODIGO" />
                        <asp:BoundField DataField="Cantidad" HeaderText="CANTIDAD" />
                        <asp:BoundField DataField="Asociacion" HeaderText="ASOCIACION" /> 
                        <asp:BoundField DataField="Depto" HeaderText="DEPARTAMENTO" />
                        <asp:BoundField DataField="Muni" HeaderText="MUNICIPIO" />
                        <asp:BoundField DataField="OrderInstalacion" HeaderText="ORDEN DE INSTALACION" />                        
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

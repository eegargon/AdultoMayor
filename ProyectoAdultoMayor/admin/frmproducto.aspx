<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmproducto.aspx.cs" Inherits="ProyectoAdultoMayor.frmproducto" %>
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
                <li><a href="/admin/frmproducto.aspx">GESTI&Oacute;N DE PRODUCTO</a></li>
                <li class="active">GESTIONAR PRODUCTO</li>
            </ol>
            <div class="panel panel-primary">
                <div class="panel-heading">MODIFICAR PRODUCTO</div>
                <div class="panel panel-body">
                    <div class="row">
                    <div class="col-md-3"></div>                   
                    <div class="col-md-6">
                         <div class="form-group">
                        <label for="contenido_txtidproducto">ID DE PRODUCTO</label>
                        <input type="text" class="form-control" id="txtidproducto" runat="server" readonly >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtnombreproducto">NOMBRE DEL PRODUCTO</label>
                        <input type="text" class="form-control" id="txtnombreproducto" runat="server" >         
                        </div> 
                        <div class="form-group">
                        <label for="contenido_txtprecio">PRECIO DEL PRODUCTO</label>
                        <input type="text" class="form-control" id="txtprecio" runat="server" >         
                        </div>                        
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("idproducto") %>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" OnClientClick="return checkDelete()"/>
                        <asp:Button ID="btnCancelarEdit" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnModificar" runat="server"  Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnModificar_Click" />
                     </div>
                    </div>
                </div>
            </div>
        <% } else if (Request.QueryString["cmd"] == "add") { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li><a href="/admin/frmproducto.aspx">GESTI&Oacute;N DE PRODUCTO</a></li>
            <li class="active">AGREGAR PRODUCTO</li>
        </ol>
        <div class="panel panel-primary">
            <div class="panel-heading">AGREGAR PRODUCTO</div>
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
                        <label for="txtnombreproductoAdd">INGRESE EL NOMBRE DEL PRODUCTO</label>                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnombreproductoAdd" ErrorMessage="EL CAMPO NOMBRE DEL PRODUCTO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtnombreproductoAdd" runat="server" placeholder="INGRESE EL NOMBRE DEL PRODUCTO">
                        </div>    
                        <div class="form-group">
                        <label for="txtprecioAdd">INGRESE EL PRECIO</label>&nbsp;&nbsp;&nbsp;                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtprecioAdd" ErrorMessage="EL CAMPO PRECIO ES OBLIGATORIO"></asp:RequiredFieldValidator>
                        <input type="text" class="form-control" id="txtprecioAdd" runat="server" placeholder="INGRESE EL PRECIO DEL USUARIO">
                        </div>                                                           
                        <asp:Button ID="btnCancelarAdd" runat="server"  Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelarEdicion_Click" />
                        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <% } else { %>
        <ol class="breadcrumb">
            <li><a href="/admin/frmInicio.aspx">Inicio</a></li>
            <li class="active">GESTI&Oacute;N DE PRODUCTO</li>
        </ol>
        <div class="panel panel-primary">
            <div class ="panel panel-heading">GESTI&Oacute;N DE PRODUCTO</div>
            <div class ="panel-body table-responsive">
                <p>
                    <a href="/admin/frmproducto.aspx?cmd=add" class="btn btn-success">AGREGAR PRODUCTO</a>
                </p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-condensed table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="idproducto" HeaderText="ID DE PRODUCTO" />
                        <asp:BoundField DataField="nombreproducto" HeaderText="NOMBRE DEL PRODUCTO" />
                        <asp:BoundField DataField="precio" HeaderText="PRECIO DEL PRODUCTO" />
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

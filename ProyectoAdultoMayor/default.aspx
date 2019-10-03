<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ProyectoAdultoMayor._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <div class="container">

<div class="row">
	<div class="col-md-2 col-sm-3 col-xs-4">
		<img src="/thirdparties/LogoCoordinadora1.png" class="img-responsive">
	</div>
	<div class="col-md-8 col-sm-6 col-xs-4">
    </div>    
	<div class="col-md-2 col-sm-3 col-xs-4">
		<img src="/thirdparties/LogoTecnologistica1.png" class="img-responsive">
	</div>
</div>
<div class="row">
	<div class="col-md-2 col-sm-3 col-xs-4">
	</div>
	<div class="col-md-8 col-sm-6 col-xs-4">

        <form id="form1" method="post" runat="server">
        <div>
 <p>Usuario: <input id="Username" runat="server"

type="text"/><br />
    Clave: <input id="Password" runat="server" type="password"/><br

/>
    <asp:Button id="btnLogin" runat="server" OnClick="btnLogin_Click"

     Text="Login"/>
    <asp:Label id="ErrorLabel" runat="Server" ForeColor="Red"

     Visible="false"/></p>


        </div>
                        </form>


    </div>    
	<div class="col-md-2 col-sm-3 col-xs-4">
	</div>

	</div>
</div>
</asp:Content>

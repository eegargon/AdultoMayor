<%@ Page Title="" Language="C#" MasterPageFile="~/AdultoMayor.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="ProyectoAdultoMayor.admin.frmInicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
<style>
    .icono {
        border: 3px double #ccc;
        padding: 10px;
        margin: 10px;
    }
    
</style>
<div class="container">
	<div class="row">	
        <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			 <a href="/admin/frmproducto.aspx">PRODUCTO </a>
			</div>
		</div>
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmRefDeptos.aspx">DEPARTAMENTOS</a>
			</div>
		</div>
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmRefMunis.aspx">MUNICIPIOS</a>			
			</div>
		</div>
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmRefTipoFoto.aspx">TIPO FOTO</a>			
			</div>
		</div>
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTbl_Unidades_Depto.aspx">UNIDADES DEPARTAMENTO</a>
			</div>
		</div>
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblAsociacion.aspx">ASOCIACION</a>			
			</div>
		</div>
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblBuses.aspx">BUSES</a>				
			</div>
		</div>
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblLector.aspx">LECTOR</a>			
			</div>
		</div>
            <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblLectorBus.aspx">LECTOR BUS</a>			
			</div>
		</div>
            <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblPiloto.aspx">PILOTO</a>			
			</div>
		</div>
            <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblPropietario.aspx">PROPIETARIO</a>			
			</div>
		</div>
            <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblRuta.aspx">RUTA</a>			
			</div>
		</div>
            <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblSim.aspx">SIM</a>			
			</div>
		</div>
        <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblSimBus.aspx">SIM BUS</a>			
			</div>
		</div>
        <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblTablet.aspx">TABLET</a>			
			</div>
		</div>
        <div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmTblTabletBus.aspx">TABLET BUS</a>			
			</div>
		</div>                  
		<div class="col-md-3 col-sm-4 col-xs-6">
			<div class="icono">
			<a href="/admin/frmLogout.aspx">SALIR</a>			
			</div>
		</div>
	</div>
</div>
</asp:Content>

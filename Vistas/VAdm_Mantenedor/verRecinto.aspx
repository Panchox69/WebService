<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="verRecinto.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.verRecinto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>Ver recinto</h1>
    </div>
    <br />
    <div class="col-md-12">
        <div class="form-group col-md-6">
            <label class="control-label">
                Nombre Recinto: </label>
            <asp:Label ID="lblNombre" runat="server" Text="" CssClass="control-label"></asp:Label>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Dirección Recinto: </label>
            <asp:Label ID="lblDireccion" runat="server" Text="" CssClass="control-label"></asp:Label>
        </div>
        <div class="form-group col-md-12">
            <label class="control-label">
                Imagen : </label>
            <asp:Image ID="imgRecinto" runat="server"/>
        </div>
    </div>
</asp:Content>

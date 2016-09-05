<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="VerEvento.aspx.cs" Inherits="Vistas.VAdm_OrganizadorDeEventos.VerEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Ver Evento</h1>
    </div>
    <br />
    <div class="col-md-12">
        <div class="form-group col-md-12">
            <label class="control-label">
                Rut Orgnizador</label>
            <asp:TextBox ID="txtRut" runat="server" class="form-control" Style="width: 290px;"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Nombre Evento</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Tipo de Evento</label>
            <asp:TextBox ID="txtEvento" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Recinto</label>
            <asp:TextBox ID="txtRecinto" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Cantidad Asientos</label>
            <asp:TextBox ID="txtAsientos" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-12">
            <asp:Image class="control-label" ID="Image1" runat="server" Width="200px" ImageUrl="~/img/movistar-arena.jpg" />
        </div>
        <div class="col-md-12" style="margin: 13px">
            <asp:Button ID="btnAtras" class="btn btn-default" runat="server" Text="Atras" OnClientClick="window.location.href='Eventos.aspx'; return false;" />
        </div>
    </div>
</asp:Content>

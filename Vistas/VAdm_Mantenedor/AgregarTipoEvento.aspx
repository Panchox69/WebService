<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="AgregarTipoEvento.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.AgregarTipoEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <asp:Label runat="server" ID="lblTitulo" Text="Agregar Evento"></asp:Label>
        <asp:Label runat="server" ID="idTipoEvento" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <div class="col-md-12">
        <div class="form-group">
            <asp:ValidationSummary ID="vasValidacionSumario" runat="server" DisplayMode="BulletList"
                ValidationGroup="ValidaIngreso" ForeColor="Red" />
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Nombre Tipo Evento</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSoloTexto" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Debe ingresar el Nombre" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSoloLetras" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El Nombre solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$">*</asp:RegularExpressionValidator>
        </div>
        <div class="col-md-12" style="margin: 13px">
            <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar"
                OnClick="btnGuardar_Click" ValidationGroup="ValidaIngreso" />
        </div>
    </div>
</asp:Content>

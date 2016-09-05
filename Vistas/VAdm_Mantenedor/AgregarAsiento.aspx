<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="AgregarAsiento.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.AgregarAsiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <asp:Label runat="server" ID="lblTitulo" Text="Agregar Asiento"></asp:Label>
        <asp:Label runat="server" ID="idAsiento" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="lblEstado" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <div class="col-md-12">
        <div class="form-group">
            <asp:ValidationSummary ID="vasValidacionSumario" runat="server" DisplayMode="BulletList"
                ValidationGroup="ValidaIngreso" ForeColor="Red" />
            <asp:Label ID="lblValImg" runat="server" Text="Formato imagen no soportado" ForeColor="Red"
                Visible="false"></asp:Label>
        </div>
        <div class="form-group col-md-6">
            <asp:Label ID="lblNumero" runat="server" Text="Número inicio" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtNumeroInicio" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumeroInicio"
                ErrorMessage="Debe ingresar el número de inicio" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNumeroInicio"
                ErrorMessage="Este campo debe contener solo números" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Número fin</label>
            <asp:TextBox ID="txtNumeroFin" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumeroFin"
                ErrorMessage="Debe ingresar el número de fin" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNumeroFin"
                ErrorMessage="Este campo debe contener solo números" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Tipo Asiento</label>
            <asp:DropDownList ID="ddlTipoAsiento" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvSeleccion" runat="server" ErrorMessage="Debe seleccionar tipo de asiento"
                ControlToValidate="ddlTipoAsiento" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                InitialValue="-1">*</asp:RequiredFieldValidator>
        </div>
        <div class="col-md-12" style="margin: 13px">
            <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar"
                OnClick="btnGuardar_Click" ValidationGroup="ValidaIngreso" />
        </div>
    </div>
</asp:Content>

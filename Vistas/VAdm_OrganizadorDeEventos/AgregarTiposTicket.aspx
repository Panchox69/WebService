<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="AgregarTiposTicket.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.AgregarTiposTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <asp:Label runat="server" ID="lblTitulo" Text="Agregar Tipo Ticket"></asp:Label>
        <asp:Label runat="server" ID="idTipoTicket" Text="" Visible="false"></asp:Label>
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
                <label class="control-label">
                    Tipo de Evento</label>
                <asp:DropDownList ID="ddlTipoAsiento" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Precio</label>
            <asp:TextBox ID="txtPrecio" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrecio"
                ErrorMessage="Debe ingresar Precio" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrecio"
                ErrorMessage="Este campo debe contener solo números" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
        </div>
        <div class="col-md-12" style="margin: 13px">
            <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar"
                OnClick="btnGuardar_Click" ValidationGroup="ValidaIngreso" />
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="AgregarOrganizador.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.AgregarOrganizador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <asp:Label ID="lblTitulo" runat="server" Text="Agregar Organizador"></asp:Label>
        <asp:Label runat="server" ID="lblEstado" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <div class="col-md-12">
        <div class="form-group">
            <asp:ValidationSummary ID="vasValidacionSumario" runat="server" DisplayMode="BulletList"
                ValidationGroup="ValidaIngreso" ForeColor="Red" />
            <asp:Label ID="lblValRut" runat="server" Text="Rut incorrecto" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div class="form-group col-md-12">
            <label class="control-label">
                Rut</label>
            <asp:TextBox ID="txtRut" runat="server" class="form-control" Style="width: 290px;"
                OnTextChanged="txtRut_OnTextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRut"
                ErrorMessage="Debe ingresar RUT" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRut"
                ErrorMessage="RUT formato incorrecto" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                ValidationExpression="\b\d{1,8}\-[K|k|0-9]">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Nombre o Razón Social</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSoloTexto" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Debe ingresar Nombre ó Razón Social" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSoloLetras" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El Nombre ó Razón Social solo puede contener letras" ForeColor="Red"
                Display="Dynamic" ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Dirección</label>
            <asp:TextBox ID="txtDireccion" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="Debe ingresar Dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Región</label>
            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" AutoPostBack="true"
                OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Comuna</label>
            <asp:DropDownList ID="ddlComuna" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Giro</label>
            <asp:TextBox ID="txtGiro" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGiro"
                ErrorMessage="Debe ingresar Giro" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtGiro"
                ErrorMessage="Giro solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Correo</label>
            <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIngreoEmail" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="Debe ingresar el Correo Electrónico" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCorreoElectronico" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="Formato de Correo Electrónico incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$">*</asp:RegularExpressionValidator>
        </div>
        <div class="col-md-12" style="margin: 13px">
            <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar"
                OnClick="btnGuardar_Click" ValidationGroup="ValidaIngreso" />
        </div>
    </div>
</asp:Content>

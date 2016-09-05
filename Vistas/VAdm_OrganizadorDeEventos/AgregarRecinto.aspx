<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="AgregarRecinto.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.AgregarRecinto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <asp:Label runat="server" ID="lblTitulo" Text="Agregar Recinto"></asp:Label>
        <asp:Label runat="server" ID="idRecinto" Text="" Visible="false"></asp:Label>
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
            <label class="control-label">
                Nombre Recinto</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSoloTexto" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Debe ingresar el Nombre" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Dirección Recinto</label>
            <asp:TextBox ID="txtDireccion" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="Debe ingresar Dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="El Giro solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú 0-9 #,-]+">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Región</label>
            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvSeleccion" runat="server" ErrorMessage="Debe seleccionar Región"
                ControlToValidate="ddlRegion" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                InitialValue="-1">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Comuna</label>
            <asp:DropDownList ID="ddlComuna" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe seleccionar Comuna"
                ControlToValidate="ddlComuna" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                InitialValue="-1">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-12">
            <asp:FileUpload ID="subirImagen" class="btn btn-default" runat="server" ToolTip="Suba una imagen que haga referencia al recinto que agregará." />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="subirImagen"
                ErrorMessage="Debe subir Imagen" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
        </div>
        <div class="col-md-12" style="margin: 13px">
            <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar"
                OnClick="btnGuardar_Click" ValidationGroup="ValidaIngreso" />
        </div>
    </div>
</asp:Content>

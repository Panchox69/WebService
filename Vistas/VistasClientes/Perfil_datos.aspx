<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Cliente.Master" AutoEventWireup="true" CodeBehind="Perfil_datos.aspx.cs" Inherits="Vistas.VistasClientes.Perfil_datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <ul class="nav nav-tabs nav-justified">
          <li role="perfil" class="active"><a href="#">Mis datos</a></li>
          <li role="perfil"><a href="Perfil_historico.aspx">Mis compras</a></li>
        </ul>
         </div>
        <div class="col-md-12">
         <div class="col-md-12">
                <h1>Mis Datos</h1>
            </div>
        <asp:Label runat="server" ID="lblTitulo" Text="Modificar Datos "></asp:Label>
        <asp:Label runat="server" ID="lblEstado" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <div class="col-md-12">
        <div class="form-group col-md-12">
            <asp:ValidationSummary ID="vasValidacionSumario" runat="server" DisplayMode="BulletList"
                ValidationGroup="ValidaIngreso" ForeColor="Red" />
            <label class="control-label">
                Rut</label>
            <asp:TextBox ID="txtRut" runat="server" class="form-control" Style="width: 290px;"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
           <strong>
                <asp:Label ID="lblCambian" runat="server" Text="Nombre" CssClass="control-label"></asp:Label></strong>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSoloTexto" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Debe ingresar el Nombre" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSoloLetras" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El Nombre solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
             <strong>
                <asp:Label ID="lblCambiante" runat="server" Text="Apellidos" CssClass="control-label"></asp:Label></strong>
            <asp:TextBox ID="txtApellidos" runat="server" class="form-control"></asp:TextBox>
             <asp:TextBox ID="txtGiro" runat="server" class="form-control" Visible="False" placeholder="Productora Audiovisual"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqApellido" runat="server" ControlToValidate="txtApellidos"
                ErrorMessage="Debe ingresar el Apellido" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regApellido" runat="server" ControlToValidate="txtApellidos"
                ErrorMessage="El Apellido solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$">*</asp:RegularExpressionValidator>
                 <asp:RequiredFieldValidator Enabled="false" ID="reqGiro" runat="server" ControlToValidate="txtGiro"
                ErrorMessage="Debe ingresar el Giro" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Enabled="false" ID="regGiro" runat="server" ControlToValidate="txtGiro"
                ErrorMessage="El Giro solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-md-6">
            <label class="control-label">
                Direccion</label>
            <asp:TextBox ID="txtDireccion" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="Debe ingresar Dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="El Giro solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú 0-9 #,-]+">*</asp:RegularExpressionValidator>
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
        <div class="form-group col-md-6">
        <strong>
                <asp:Label ID="lblCelular" runat="server" Text="Celular" CssClass="control-label"></asp:Label></strong>
            <asp:TextBox ID="txtCelular" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCelular"
                ErrorMessage="Debe ingresar el Teléfono" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCelular"
                ErrorMessage="El Teléfono solo puede contener números" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
        </div>
        <div class="col-md-12" style="margin: 13px">
            <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar"
                ValidationGroup="ValidaIngreso" onclick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>


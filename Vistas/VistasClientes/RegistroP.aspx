<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Cliente.Master" AutoEventWireup="true"
    CodeBehind="RegistroP.aspx.cs" Inherits="Vistas.RegistroP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>Registro</h1>
    </div>
    <div class="col-md-4" style="margin-left: 20px;">
    <div class="form-group">
            <asp:Label ID="lblSel" runat="server" Text="Debe seleccionar al menos 1 interés"
                ForeColor="Red" Visible="false"></asp:Label>
            <asp:Label ID="lblAce" runat="server" Text="Debe aceptar las condiciones" ForeColor="Red"
                Visible="false"></asp:Label>
            <asp:Label ID="lblCon" runat="server" Text="Contraseñas no coinciden" ForeColor="Red"
                Visible="false"></asp:Label>
        </div>
        <div class="form-group">
            <strong>
                <asp:Label ID="lblRUT" runat="server" Text="RUN" CssClass="control-label"></asp:Label></strong>
            <asp:TextBox ID="txtRut" runat="server" class="form-control" OnTextChanged="txtRut_TextChanged"
                placeholder="12345678-5" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfRUT" runat="server" ControlToValidate="txtRut"
                ErrorMessage="Debe ingresar Número de Identificación" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:Label ID="lblValRut" runat="server" Text="RUN no existente" ForeColor="Red"
                Visible="false"></asp:Label>
        </div>
        <div class="form-group">
            <label class="control-label">
                Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="José"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSoloTexto" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Debe ingresar el Nombre" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSoloLetras" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El Nombre solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <strong>
                <asp:Label ID="lblCambiante" runat="server" Text="Apellidos" CssClass="control-label"></asp:Label></strong>
            <asp:TextBox ID="txtApellidos" runat="server" class="form-control" placeholder="Oñate"></asp:TextBox>
            <asp:TextBox ID="txtGiro" runat="server" class="form-control" Visible="False" placeholder="Productora Audiovisual"></asp:TextBox>
            <asp:RequiredFieldValidator Enabled="true" ID="reqApellido" runat="server" ControlToValidate="txtApellidos"
                ErrorMessage="Debe ingresar el Apellido" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Enabled="true" ID="regApellido" runat="server" ControlToValidate="txtApellidos"
                ErrorMessage="El Apellido solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator Enabled="false" ID="reqGiro" runat="server" ControlToValidate="txtGiro"
                ErrorMessage="Debe ingresar el Giro" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Enabled="false" ID="regGiro" runat="server" ControlToValidate="txtGiro"
                ErrorMessage="El Giro solo puede contener letras" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Fecha de Ingreso</label>
            <asp:TextBox ID="txtFecha" runat="server" class="form-control" placeholder="17-03-2016"></asp:TextBox>
         </div>
        <div class="form-group">
            <label class="control-label">
                Sexo</label>
            <asp:TextBox ID="txtSexo" runat="server" class="form-control" placeholder="Masculino o Femenino"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSexo"
                ErrorMessage="Debe ingresar Sexo" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSexo"
                ErrorMessage="Formato sexo incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú 0-9 #,-]+"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Dirección</label>
            <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Las Urbinas"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="Debe ingresar Dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="Formato dirección incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú 0-9 #,-]+"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Numero</label>
            <asp:TextBox ID="txtnumero" runat="server" class="form-control" placeholder="3840"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtnumero"
                ErrorMessage="Debe ingresar Dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtnumero"
                ErrorMessage="Formato numero incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Correo</label>
            <asp:TextBox ID="txtCorreo" runat="server" class="form-control" placeholder="jose@onate.com"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIngreoEmail" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="Debe ingresar el Correo Electrónico" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCorreoElectronico" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="Formato de Correo Electrónico incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Teléfono</label>
            <asp:CheckBox ID="chbCell" runat="server" AutoPostBack="true" Text="Celular" OnCheckedChanged="chbCell_CheckedChanged" />
            <asp:TextBox ID="txtTelefono" runat="server" class="form-control" MaxLength="7"
                placeholder="2223344" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfTele" runat="server" ControlToValidate="txtTelefono"
                ErrorMessage="Debe ingresar el Teléfono" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="reTele" runat="server" ControlToValidate="txtTelefono"
                ErrorMessage="El Teléfono solo puede contener números" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^([2-9][0-9]{6})$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtCell" runat="server" Visible="false" class="form-control" MaxLength="9"
                placeholder="988774455" AutoPostBack="true" 
                ontextchanged="txtCell_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfCell" runat="server" Enabled="false" ControlToValidate="txtCell"
                ErrorMessage="Debe ingresar Número Celular" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="reCell" runat="server" Enabled="false" ControlToValidate="txtCell"
                ErrorMessage="N° incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^(9[6-9][0-9]{7})$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Región</label>
            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvSeleccion" runat="server" ErrorMessage="Debe seleccionar Región"
                ControlToValidate="ddlRegion" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                InitialValue="-1"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Comuna</label>
            <asp:DropDownList ID="ddlComuna" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe seleccionar Comuna"
                ControlToValidate="ddlComuna" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                InitialValue="-1"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Contraseña</label>
            <asp:TextBox ID="txtContrasena" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContrasena"
                ErrorMessage="Debe ingresar Contraseña" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="control-label">
                Repetir contraseña</label>
            <asp:TextBox ID="txtContrasena2" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContrasena2"
                ErrorMessage="Debe ingresar Contraseña" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
        </div>
        <div class="checkbox">
            <label>
                <asp:CheckBox ID="chkNegocio" runat="server"
                    AutoPostBack="true" oncheckedchanged="chkNegocio_CheckedChanged" />Direccion Distinta Negocio
            </label>
        </div>
        <div class="form-group">
            <strong>
                <asp:Label ID="lblDireccionNegocio" runat="server" Text="Direccion Negocio" CssClass="control-label"></asp:Label></strong>
            <asp:TextBox ID="txtDireccionNegocio" runat="server" class="form-control" placeholder="Las Urbinas"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDireccionNegocio"
                ErrorMessage="Debe ingresar Dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDireccionNegocio"
                ErrorMessage="Formato dirección incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú 0-9 #,-]+"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <strong>
                <asp:Label ID="lblNumeroNegocio" runat="server" Text="Numero Negocio" CssClass="control-label"></asp:Label></strong>
            <asp:TextBox ID="txtNumeroNegocio" runat="server" class="form-control" placeholder="3840"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNumeroNegocio"
                ErrorMessage="Debe ingresar Dirección" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtNumeroNegocio"
                ErrorMessage="Formato numero incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaIngreso" ValidationExpression="^([0-9])$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <strong>
                <asp:Label ID="lblRegionNegocio" runat="server" Text="Region" CssClass="control-label"></asp:Label></strong>
            <asp:DropDownList ID="ddlRegionNegocio" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRegionNegocio_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Debe seleccionar Región"
                ControlToValidate="ddlRegionNegocio" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                InitialValue="-1"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <strong>
                <asp:Label ID="lblComunaNegocio" runat="server" Text="Comuna" CssClass="control-label"></asp:Label></strong>
            <asp:DropDownList ID="ddlComunaNegocio" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Debe seleccionar Comuna"
                ControlToValidate="ddlComunaNegocio" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"
                InitialValue="-1"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lblcap" runat="server" Text="Captcha Erroneo" ForeColor="Red" Visible="false"></asp:Label>
            <div class="form-group">
                <asp:Image ID="Image1" runat="server" ImageUrl="CaptchaHandler.ashx" />
                <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="Debe ingresar Captcha" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>   
    <div class="col-md-12" style="text-align: center;">        
        <div class="col-md-12">
            <label>
                <asp:CheckBox ID="chkAcepto" runat="server" OnCheckedChanged="chkAcepto_CheckedChanged" />Acepto
                las condiciones de uso de Feria Frutos Frescos 
            </label>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnRegistro" class="btn btn-default" runat="server" Text="Registrarme"
                OnClick="btnRegistro_Click" ValidationGroup="ValidaIngreso" />
        </div>
    </div>
</asp:Content>

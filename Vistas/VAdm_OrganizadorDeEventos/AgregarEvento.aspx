<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="AgregarEvento.aspx.cs" Inherits="Vistas.VAdm_OrganizadorDeEventos.AgregarEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <asp:Label runat="server" ID="lblTitulo" Text="AGREGAR PRODUCTO"></asp:Label>
        <asp:Label runat="server" ID="idEvento" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="lblEstado" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                PRODUCTO</div>
            <div class="panel-body">
                <div class="form-group">
                   <div class="form-group col-md-4">
                        <label class="control-label">
                            Tipo</label>
                        <asp:DropDownList ID="ddlTipo" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">
                            Cultivo</label>
                        <asp:DropDownList ID="ddlCultivo" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                     <label class="control-label">
                            Oferta</label>
                        <asp:CheckBox ID="chkOferta" runat="server" class="form-control"> 
                        </asp:CheckBox>                      
                     </div>
                      <div class="form-group col-md-12">
                        <label class="control-label">
                            Descripción</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" TextMode="MultiLine"
                            Rows="5" MaxLength="1000"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">
                            Stock</label>
                        <asp:TextBox ID="txtStock" runat="server" class="form-control" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" Enabled="true" ControlToValidate="txtStock"
                            ErrorMessage="N° incorrecto" ForeColor="Red" Display="Dynamic"
                            ValidationGroup="validaEvento" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">
                            Unidad de Medida</label>
                        <asp:DropDownList ID="ddlMedida" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">
                            Precio Unitario $</label>
                        <asp:TextBox ID="txtPrecio" runat="server" class="form-control" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" Enabled="true" ControlToValidate="txtPrecio"
                            ErrorMessage="N° incorrecto" ForeColor="Red" Display="Dynamic"
                            ValidationGroup="validaEvento" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    </div>
              </div> 
          </div>
       </div> 
   </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                IMAGENES</div>
            <div class="panel-body">
                <div class="form-group">
                   <div class="form-group col-md-12">
                        <label class="control-label">
                          Nombre</label>
                          <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Naranja"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvSoloTexto" runat="server" ControlToValidate="txtNombre"
                          ErrorMessage="Debe ingresar el Nombre" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="revSoloLetras" runat="server" ControlToValidate="txtNombre"
                          ErrorMessage="El Nombre solo puede contener letras" ForeColor="Red" Display="Dynamic"
                          ValidationGroup="validaEvento" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-md-12">
                        <label class="control-label">
                          Descripcion</label>
                          <asp:TextBox ID="txtDescripcionI" runat="server" class="form-control" placeholder="Rica en Vitamina C"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcionI"
                          ErrorMessage="Debe ingresar el Nombre" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidaIngreso"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtDescripcionI"
                          ErrorMessage="El Nombre solo puede contener letras" ForeColor="Red" Display="Dynamic"
                          ValidationGroup="validaEvento" ValidationExpression="^[a-zA-Z ñÑÁÉÍÓÚáéióú]*$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-md-12">
                        <label class="control-label">
                            Orden</label>
                        <asp:TextBox ID="txtOrden" runat="server" class="form-control" MaxLength="1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Enabled="true"
                            ControlToValidate="txtOrden" ErrorMessage="N° incorrecto"
                            ForeColor="Red" Display="Dynamic" ValidationGroup="validaEvento" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-md-12">
                        <label class="control-label">
                            Subir Imagen</label>
                        <asp:FileUpload ID="subirImagen" class="form-control" runat="server" ToolTip="Suba una imagen que haga referencia al producto que agregará." />
                    </div>
              </div>
        </div>
    </div>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar"
            OnClick="btnGuardar_Click" ValidationGroup="validaEvento" />
    </div>
</asp:Content>

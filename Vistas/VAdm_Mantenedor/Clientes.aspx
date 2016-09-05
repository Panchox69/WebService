<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Clientes.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Clientes</h1>
    </div>
    
    <div class="col-md-12">
          <%--Se agrega ddl de filtro--%>
        <asp:DropDownList ID="ddlFiltro" runat="server" Width="300px" Height="25" 
                BackColor="White" onselectedindexchanged="ddlFiltro_SelectedIndexChanged" AutoPostBack="true"  AllowPaging="true" PageSize="5">
            <asp:ListItem Value="2" Selected="True">Todos</asp:ListItem>
            <asp:ListItem Value="1">Habilitados</asp:ListItem>
            <asp:ListItem Value="0">Deshabilitados</asp:ListItem>
        </asp:DropDownList>
        <%--Se agrega ddl de filtro--%>
        <asp:TextBox ID="txtBusqueda" runat="server" Width="300px" Height="25" BackColor="White"
            BorderStyle="Solid" BorderWidth="3px" BorderColor="Gray"></asp:TextBox>
        <asp:LinkButton ID="btnBusqueda" CssClass="btn btn-default btn-lg" runat="server"
            OnClick="btnBusqueda_Click1"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
        <div class="radiobutton">
            <asp:RadioButton Text="Rut" ID="Rut" GroupName="buscar" runat="server" Checked="true" />
            <asp:RadioButton Text="Nombre" ID="Nombre" GroupName="buscar" runat="server" />
            <asp:RadioButton Text="Apellido" ID="Apellido" GroupName="buscar" runat="server" />
        </div>
              
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvEventos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            EmptyDataText="No se encontraron registros" Visible="True" 
            CssClass="table_ticket table table-bordered" 
            onrowcommand="grvEventos_RowCommand" AllowPaging="true" PageSize="5" 
            onrowdatabound="grvEventos_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="RUN" DataField="Rut" />
                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                <asp:BoundField HeaderText="Correo" DataField="Correo" />
                <asp:BoundField HeaderText="Celular" DataField="Celular" />
                <asp:BoundField HeaderText="Estado" DataField="NombreEstado" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Modificar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default" Text="Modificar" CommandArgument='<%# Eval("Rut") %>' CommandName="modificar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Deshabilitar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Deshabilitar" CommandArgument='<%# Eval("Rut") %>' CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

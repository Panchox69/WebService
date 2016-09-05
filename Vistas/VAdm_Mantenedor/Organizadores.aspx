<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Organizadores.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.Organizadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Organizadores</h1>
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
      <asp:LinkButton ID="btnBusqueda" CssClass="btn btn-default btn-lg" runat="server" onclick="btnBusqueda_Click1" 
             ><span class="glyphicon glyphicon-search"></span></asp:LinkButton>                  
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvOrganizadores" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            EmptyDataText="No se encontraron registros" Visible="True" 
            CssClass="table_ticket table table-bordered" 
            onrowcommand="grvOrganizadores_RowCommand" AllowPaging="true" PageSize="5" 
            onrowdatabound="grvOrganizadores_RowDataBound">
             <Columns>
                <asp:BoundField HeaderText="Nombre / Razón Social" DataField="NombreRazonSocial" />
                <asp:BoundField HeaderText="Rut" DataField="Rut" />
                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                <asp:BoundField HeaderText="Giro" DataField="Giro" />
                <asp:BoundField HeaderText="Correo" DataField="Correo" />
                <asp:BoundField HeaderText="Estado" DataField="NombreEstado" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Modificar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default" Text="Modificar" CommandArgument='<%# Eval("Rut") %>' CommandName="modificarOrganizador" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Deshabilitar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Deshabilitar" CommandArgument='<%# Eval("Rut") %>' CommandName="EliminarOrganizador" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
<%--    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnAgregar" class="btn btn-default" runat="server" Text="Agregar Organizador"
            
            OnClientClick="window.location.href='AgregarOrganizador.aspx'; return false;" 
            onclick="btnAgregar_Click" />
    </div>--%>
</asp:Content>

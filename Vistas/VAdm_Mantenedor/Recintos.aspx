<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Recintos.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.Recintos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Recintos</h1>
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
        <asp:GridView ID="grvEventos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            EmptyDataText="No se encontraron registros" Visible="True" 
            CssClass="table_ticket table table-bordered" 
            onrowcommand="grvEventos_RowCommand" AllowPaging="true" PageSize="5" 
            onrowdatabound="grvEventos_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="IdRecinto" />
                <asp:BoundField HeaderText="Recinto" DataField="NombreRecinto" />
                <asp:BoundField HeaderText="Dirección" DataField="DireccionRecinto" />
                <asp:BoundField HeaderText="Estado" DataField="NombreEstado" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ver
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnVer" CssClass="btn btn-default" runat="server" Text="Ver" CommandArgument='<%# Eval("IdRecinto") %>' CommandName="ver" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Modificar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default" Text="Modificar" CommandArgument='<%# Eval("IdRecinto") %>' CommandName="modificar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Deshabilitar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Deshabilitar" CommandArgument='<%# Eval("IdRecinto") %>' CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnAgregar" class="btn btn-default" runat="server" Text="Agregar Recinto"
            OnClientClick="window.location.href='AgregarRecinto.aspx'; return false;" 
            onclick="btnAgregar_Click" />
    </div>
</asp:Content>

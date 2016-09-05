<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Eventos.aspx.cs" Inherits="Vistas.VAdm_OrganizadorDeEventos.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Eventos</h1>
    </div>
    <div class="col-md-12">
          <%--Se agrega ddl de filtro--%>
        <asp:DropDownList ID="ddlFiltro" runat="server" Width="300px" Height="25" 
                BackColor="White" onselectedindexchanged="ddlFiltro_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="" Selected="True">Todos</asp:ListItem>
            <asp:ListItem Value="A">Habilitados</asp:ListItem>
            <asp:ListItem Value="E">Deshabilitados</asp:ListItem>
        </asp:DropDownList>
        <%--Se agrega ddl de filtro--%>
        <asp:TextBox ID="txtBusqueda" runat="server" Width="200px" Height="25" BackColor="White"
            BorderStyle="Solid" BorderWidth="3px" BorderColor="Gray"></asp:TextBox>
        <asp:LinkButton ID="btnBusqueda" CssClass="btn btn-default btn-lg" runat="server"
            OnClick="btnBusqueda_Click1"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
        <asp:DropDownList ID="ddlRecintos" runat="server" Width="200px" Height="25" 
                BackColor="White" 
              onselectedindexchanged="ddlRecintos_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlTipoEventos" runat="server" Width="200px" Height="25" 
                BackColor="White" 
              onselectedindexchanged="ddlTipoEventos_SelectedIndexChanged" 
              AutoPostBack="true">
        </asp:DropDownList>
        <div class="radiobutton">
            <asp:RadioButton Text="Codigo" ID="Id_evento" GroupName="buscar" runat="server" Checked="true" />
            <asp:RadioButton Text="Nombre" ID="Nombre" GroupName="buscar" runat="server" />
        </div>
              
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvEventos" runat="server" Visible="true" AutoGenerateColumns="false"
            ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros" CssClass="table_ticket table table-bordered"
            onrowcommand="grvEventos_RowCommand" 
            onrowdatabound="grvEventos_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="IdEvento" />
                <asp:BoundField HeaderText="Rut Organizador" DataField="Rut" />
                <asp:BoundField HeaderText="Nombre Evento" DataField="Nombre" />
                <%--<asp:BoundField HeaderText="Cantidad Asientos" DataField="AsientosDisponibles" />--%>
                <asp:BoundField HeaderText="Estado" DataField="EstadoDesc" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Modificar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default" Text="Modificar" CommandArgument='<%# Eval("IdEvento") %>' CommandName="modificar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Deshabilitar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Deshabilitar" CommandArgument='<%# Eval("IdEvento") %>' CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Tipos de ticket
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnTipos" CssClass="btn btn-default" runat="server" Text="Tipos de ticket" CommandArgument='<%# Eval("IdEvento") %>' CommandName="tipos" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Agregar evento" OnClientClick="window.location.href='AgregarEvento.aspx'; return false;"  />
    </div>
</asp:Content>

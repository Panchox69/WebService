<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="TiposTicket.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.TiposTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="col-md-12">
        <h1>
            Tipos de ticket <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Agregar Tipo Ticket"
            OnClientClick="window.location.href='AgregarTiposTicket.aspx'; return false;" /></h1>
            
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvTipos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            EmptyDataText="No se encontraron registros" Visible="True" 
            CssClass="table_ticket table table-bordered" onrowcommand="grvTipos_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Modificar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default" Text="Modificar" CommandArgument='<%# Eval("IdTipoTicket") %>' CommandName="modificar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Deshabilitar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Deshabilitar" CommandArgument='<%# Eval("IdTipoTicket") %>' CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnAgregar" class="btn btn-default" runat="server" Text="Agregar tipo ticket"
            OnClientClick="window.location.href='AgregarTiposTicket.aspx'; return false;" />
    </div>
</asp:Content>

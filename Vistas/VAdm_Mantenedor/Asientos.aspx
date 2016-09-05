<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="Asientos.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.Asientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="col-md-12">
        <h1>
            Asientos <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Agregar Asientos"
            OnClientClick="window.location.href='AgregarAsiento.aspx'; return false;" /></h1>
            
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvAsientos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            EmptyDataText="No se encontraron registros" Visible="True" 
            CssClass="table_ticket table table-bordered" onrowcommand="grvAsientos_RowCommand"  AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Numero" DataField="Numero" />
                <asp:BoundField HeaderText="Tipo Asiento" DataField="TipoAsiento" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Modificar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default" Text="Modificar" CommandArgument='<%# Eval("IdAsiento") %>' CommandName="modificar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Deshabilitar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Deshabilitar" CommandArgument='<%# Eval("IdAsiento") %>' CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnAgregar" class="btn btn-default" runat="server" Text="Agregar Asientos"
            OnClientClick="window.location.href='AgregarAsiento.aspx'; return false;" />
    </div>
</asp:Content>

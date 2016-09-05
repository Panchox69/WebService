<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="TiposEventos.aspx.cs" Inherits="Vistas.VAdm_Mantenedor.TiposEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Tipos de Eventos</h1>
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvTipos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            EmptyDataText="No se encontraron registros" Visible="True" CssClass="table_ticket table table-bordered"
            OnRowCommand="grvTipos_RowCommand" AllowPaging="true" PageSize="5" OnPageIndexChanging="OnCambioDePagina">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="IdTipoEvento" />
                <asp:BoundField HeaderText="Descripción" DataField="DescripcionTipoEvento" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Modificar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default" Text="Modificar"
                            CommandArgument='<%# Eval("IdTipoEvento") %>' CommandName="modificar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Eliminar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Eliminar"
                            CommandArgument='<%# Eval("IdTipoEvento") %>' CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--<table class="table_ticket table table-bordered">
            <thead>
                <tr>
                    <th>
                        Tipo de Evento
                    </th>
                    <th>
                        Editar
                    </th>
                    <th>
                        Eliminar
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>--%>
    </div>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnAgregar" class="btn btn-default" runat="server" Text="Agregar Tipo Evento"
            OnClientClick="window.location.href='AgregarTipoEvento.aspx'; return false;"
            OnClick="btnAgregar_Click" />
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Ventas.aspx.cs" Inherits="Vistas.VAdm_OrganizadorDeEventos.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Ventas
        </h1>
        <br />
    </div>
    <div class="col-md-9">
        <table class="table">
            <tr>
                <th>
                    <label class="control-label">
                        Evento</label>
                </th>
                <th>
                    <asp:DropDownList ID="ddlEvento" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlEvento_SelectedIndexChanged">
                    </asp:DropDownList>
                </th>
            </tr>
        </table>
        <br />
    </div>
    <div class="col-md-12">
       
        <asp:GridView ID="grvContrato" runat="server" AutoGenerateColumns="false" 
            ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros"
            CssClass="table_ticket table table-bordered" 
            onrowcommand="grvContrato_RowCommand"  AllowPaging="true" PageSize="5" 
            onpageindexchanging="grvContrato_PageIndexChanging" >
            <Columns>
                <asp:BoundField HeaderText="Nº de Venta" DataField="IdTicket" />
                <asp:BoundField HeaderText="Evento" DataField="NombreEvento" />
                <asp:BoundField HeaderText="Cantidad Entradas" DataField="Cantidad" />
                <asp:BoundField HeaderText="Total" DataField="Total" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Deshabilitar
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" Text="Deshabilitar" CommandArgument='<%# Eval("IdTicket") %>' CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </div>
</asp:Content>

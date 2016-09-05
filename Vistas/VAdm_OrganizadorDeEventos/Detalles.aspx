<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Detalles.aspx.cs" Inherits="Vistas.VAdm_OrganizadorDeEventos.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <label style="font-size: 30px; margin-right: 15px;">
            Detalles:
        </label>
    </div>
    <br />
    <div class="col-md-12">
        <label style="font-size: 20px; margin-right: 15px;">
            Detalle Ventas de Entradas</label>
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvDetalleVentas" runat="server" AutoGenerateColumns="false" Visible="false"
            ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Tipo Entrada" DataField="Tipo Entrada" />
                <asp:BoundField HeaderText="Cantidad Total" DataField="Cantidad Total" />
                <asp:BoundField HeaderText="Cantidad Vendida" DataField="Cantidad Vendida" />
                <asp:BoundField HeaderText="Costo Unitario" DataField="Costo Unitario" />
                <asp:BoundField HeaderText="Total" DataField="Total" />
            </Columns>
        </asp:GridView>
        <table class="table_ticket table table-bordered">
            <thead>
                <tr>
                    <th>
                        Tipo de entrada
                    </th>
                    <th>
                        Cantidad total
                    </th>
                    <th>
                        Cantidad vendida
                    </th>
                    <th>
                        Costo unitario
                    </th>
                    <th>
                        Total
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
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
    <div class="col-md-12">
        <label style="font-size: 20px; margin-right: 15px;">
            Detalle Perdidas</label>
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvDetallePerdidas" runat="server" AutoGenerateColumns="false"
            Visible="false" ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros">
            <Columns>
                <asp:BoundField HeaderText="Tipo Entrada" DataField="Tipo Entrada" />
                <asp:BoundField HeaderText="Cantidad Total" DataField="Cantidad Total" />
                <asp:BoundField HeaderText="Cantidad Vendida" DataField="Cantidad Vendida" />
                <asp:BoundField HeaderText="Costo Unitario" DataField="Costo Unitario" />
                <asp:BoundField HeaderText="Total" DataField="Total" />
            </Columns>
        </asp:GridView>
        <table class="table_ticket table table-bordered">
            <thead>
                <tr>
                    <th>
                        Tipo de entrada
                    </th>
                    <th>
                        Cantidad total
                    </th>
                    <th>
                        Cantidad vendida
                    </th>
                    <th>
                        Costo unitario
                    </th>
                    <th>
                        Total
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
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

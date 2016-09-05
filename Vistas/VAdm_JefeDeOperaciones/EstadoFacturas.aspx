<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="EstadoFacturas.aspx.cs" Inherits="Vistas.VAdm_JefeDeOperaciones.EstadoFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h1>
            Estado de Facturas</h1>
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvFacturas" runat="server" AutoGenerateColumns="false"
            ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros" CssClass="table_ticket table table-bordered" 
             AllowPaging="true" PageSize="5"> 
            <Columns>
                <asp:BoundField HeaderText="N° Factura" DataField="Organizador" />
                <asp:BoundField HeaderText="Razón Social" DataField="Razon Social" />
                <asp:BoundField HeaderText="Rut" DataField="Rut" />
                 <asp:TemplateField>
                    <HeaderTemplate>
                        Cancelado
                    </HeaderTemplate>
                    <ItemTemplate>
                         <asp:CheckBox ID="chkCancelado" runat="server"/>
                    </ItemTemplate>                    
                </asp:TemplateField>    
            </Columns>
        </asp:GridView>       
    </div>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar" />
    </div>
</asp:Content>

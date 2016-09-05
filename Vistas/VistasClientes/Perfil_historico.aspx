<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Cliente.Master" AutoEventWireup="true" CodeBehind="Perfil_historico.aspx.cs" Inherits="Vistas.VistasClientes.Perfil_historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <ul class="nav nav-tabs nav-justified">
            <li role="perfil"><a href="Perfil_datos.aspx">Mis datos</a></li>
            <li role="perfil" class="active"><a href="#">Mis compras</a>
            </li>   
        </ul>
    </div>
    <div class="col-md-12">
            <h1>Mis compras</h1>
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvHistorico" runat="server" AutoGenerateColumns="false" 
            ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros"
        CssClass="table_ticket table table-bordered" AllowPaging="true" PageSize="5" 
            onpageindexchanging="grvHistorico_PageIndexChanging" >
            <Columns>
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:BoundField HeaderText="Total" DataField="Total" />
                <asp:BoundField HeaderText="Regalo" DataField="Regalo" />
            </Columns>        
        </asp:GridView>
    </div>
            
          
</asp:Content>

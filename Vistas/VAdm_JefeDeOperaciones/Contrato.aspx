<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Contrato.aspx.cs" Inherits="Vistas.VAdm_JefeDeOperaciones.Contrato" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[id*=chkHeader]").live("click", function () {
        var chkHeader = $(this);
        var grid = $(this).closest("table");
        $("input[type=checkbox]", grid).each(function () {
            if (chkHeader.is(":checked")) {
                $(this).attr("checked", "checked");
                $("td", $(this).closest("tr")).addClass("selected");
            } else {
                $(this).removeAttr("checked");
                $("td", $(this).closest("tr")).removeClass("selected");
            }
        });
    });
    $("[id*=chkRow]").live("click", function () {
        var grid = $(this).closest("table");
        var chkHeader = $("[id*=chkHeader]", grid);
        if (!$(this).is(":checked")) {
            $("td", $(this).closest("tr")).removeClass("selected");
            chkHeader.removeAttr("checked");
        } else {
            $("td", $(this).closest("tr")).addClass("selected");
            if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                chkHeader.attr("checked", "checked");
            }
        }
    });
</script>


   <div class="col-md-12">
        <h1>
            Contrato</h1>
    </div>
    <br />
    <div class="col-md-12">
            <asp:GridView ID="grvContrato" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
            EmptyDataText="No se encontraron registros" Visible="True" 
            CssClass="table_ticket table table-bordered" 
             AllowPaging="true" PageSize="5">              
            <Columns>        
                <asp:BoundField HeaderText="Folio" DataField="IdFolio" />
                <asp:BoundField HeaderText="Nombre / Razón Social" DataField="NombreRazonSocial" />
                <asp:BoundField HeaderText="Rut" DataField="Rut" />
                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                <asp:BoundField HeaderText="Giro" DataField="Giro" />
                <asp:BoundField HeaderText="Correo" DataField="Correo" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkHeader" runat="server" Text=" Seleccionar Todo"/>
                    </HeaderTemplate>                 
                    <ItemTemplate>
                         <asp:CheckBox ID="chkGenerar" runat="server"/>
                    </ItemTemplate>                    
                </asp:TemplateField>                 
            </Columns>
        </asp:GridView>
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnContrato" class="btn btn-default" runat="server" 
            Text="Generar Contrato" onclick="btnContrato_Click"/>
    </div>
</asp:Content>

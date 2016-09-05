<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdministrarOrganizadores.aspx.cs" Inherits="Vistas.VAdm_JefeDeOperaciones.AdministrarOrganizadores" %>
  

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    
      
    
    <div class="col-md-12">
        <h1>
            Administrar Organizadores</h1>
    </div>
    <br />
    <div class="col-md-12">
        <asp:GridView ID="grvOrganizador" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
             EmptyDataText="No se encontraron registros" Visible="True" 
            CssClass="table_ticket table table-bordered" 
             AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Organizador" DataField="NombreRazonSocial" />
                <asp:BoundField HeaderText="N° de Inscripción" DataField="IdFolio" />
                         
             <asp:TemplateField>
                    <HeaderTemplate>
                        Aprobado
                    </HeaderTemplate>
                    <ItemTemplate>                   
                    <asp:CheckBox ID="chkAprobado" runat="server" Checked='<%# Eval("Valido").ToString().Equals("v")%>' />                         
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Autorizado
                    </HeaderTemplate>
                    <ItemTemplate>
                         <asp:CheckBox ID="chkAutorizado" runat="server" Checked='<%# Eval("IdEstado").ToString().Equals("1")%>'/>
                    </ItemTemplate>                    
                </asp:TemplateField>
                </Columns>
        </asp:GridView>
        
    <div class="col-md-12" style="margin: 13px">
        <asp:Button ID="btnActualizar" class="btn btn-default" runat="server" 
            Text="Actualizar" onclick="btnActualizar_Click" />
    </div>


  

    </div>
</asp:Content>


 
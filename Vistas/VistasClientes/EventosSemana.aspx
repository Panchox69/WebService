<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Cliente.Master" AutoEventWireup="true"
    CodeBehind="EventosSemana.aspx.cs" Inherits="Vistas.VistasClientes.EventosSemana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <div class="col-md-12">
        <label style="font-size: 30px; margin-right: 15px;">
            Eventos de la Semana</label>
         <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltro_OnSelectedIndexChanged">
        </asp:DropDownList>
        <hr />
         <div class="col-md-12">
        <div class="col-md-8">
            <asp:GridView ID="grvEventos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                Visible="true" EmptyDataText="No se encontraron registros" CssClass="table_ticket table table-bordered"
                AllowPaging="true" PageSize="5" 
                OnPageIndexChanging="grvEventos_OnPageIndexChanging" >
                <Columns>                    
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <h3>Eventos</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <img src="<%#Eval("Imagen")%>" width="200" height="300" alt="">                            
                        </ItemTemplate>
                          </asp:TemplateField>  
                         <asp:TemplateField>
                         <ItemTemplate >                  
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre") %>' Font-Size="Large" Font-Bold="True"></asp:Label>
                             <br>
                    </br>
                             <br>
                    </br>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Descripcion") %>' ></asp:Label>
                             <br>
                    </br>
                             <br>
                    </br>
                    <a href="SeleccionEntradas.aspx?evento=<%# Eval("IdEvento") %>" style="text-align:right" ><h4>Comprar</h4></a>      
               
           </ItemTemplate>  
                    </asp:TemplateField>   
                                     
                </Columns>
            </asp:GridView>
        </div>
    
   
          <div class="col-md-4">
            <label style="font-size: 30px;">
                Próximos eventos</label>
            <br />
            <asp:Calendar ID="Calendar1" runat="server" Width="300" Height="200" OnSelectionChanged="Calendar1_SelectionChanged">
            </asp:Calendar>
            <br />
          </div>
    </div>
    </div>
</asp:Content>








    <%--    <label style="font-size: 30px; margin-right: 15px;">
            Eventos Actuales</label>
        <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltro_OnSelectedIndexChanged">
        </asp:DropDownList>
        <hr />
    </div>
    <div class="col-md-12">
        <div class="col-md-8">
            <asp:GridView ID="grvEventos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                Visible="true" EmptyDataText="No se encontraron registros" CssClass="table_ticket table table-bordered"
                AllowPaging="true" PageSize="5" OnPageIndexChanging="grvEventos_OnPageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="Nombre de Evento" DataField="Nombre" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Ir a
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a href="SeleccionEntradas.aspx?evento=<%# Eval("IdEvento") %>">Comprar</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-4">
            <label style="font-size: 30px;">
                Próximos eventos</label>
            <br />
            <asp:Calendar ID="Calendar1" runat="server" Width="300" Height="200" OnSelectionChanged="Calendar1_SelectionChanged">
            </asp:Calendar>
            <br />
          </div>
    </div>
</asp:Content>
--%>
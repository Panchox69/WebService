<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Cliente.Master" AutoEventWireup="true"
    CodeBehind="Inicio.aspx.cs" Inherits="Vistas.Inicio" %>

<%@ Import Namespace="BEL" %>
<%@ Import Namespace="BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/jquery.liquidcarousel.min.js"></script>
    <script type="text/javascript" src="js/jcarousel.basic.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <h2>
            Eventos destacados</h2>
    </div>
    <div class="col-md-12">
        <div id="liquid" class="liquid">
            <span class="previous"></span>
            <div class="wrapper">
                <ul>
                    <% 
                        EventoBLL events = new EventoBLL();
                        List<EventoBEL> eventos = new List<EventoBEL>();
                        eventos = events.traerEventosCercanos();
                        foreach (EventoBEL tmpEvent in eventos)
                        {
                    %>
                    <li><a href="/VistasClientes/SeleccionEntradas.aspx?evento=<%=tmpEvent.IdEvento %>">
                        <img src="<%=tmpEvent.Imagen %>" alt="" width="200" height="300" />
                    </a></li>
                    <%
                        } 
                    %>
                </ul>
            </div>
            <span class="next"></span>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#liquid').liquidcarousel({
                    height: 300, 	//the height of the list
                    hidearrows: false	//hide arrows if all of the list items are visible
                });
            });
        </script>
    </div>
</asp:Content>

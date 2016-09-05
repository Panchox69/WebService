<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Cliente.Master" AutoEventWireup="true" CodeBehind="Detalle_compra.aspx.cs" Inherits="Vistas.VistasClientes.Detalle_compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
body
{
font-family: Trebuchet MS;
}
</style>
<script type="text/javascript">
    function PrintThisDiv(id) {
        var HTMLContent = document.getElementById(id);
        var Popup = window.open('about:blank', id, 'width=500,height=500');

        Popup.document.writeln('<html><head>');
        Popup.document.writeln('<style type="text/css">');
        Popup.document.writeln('body{font-family: Trebuchet MS;}');
        Popup.document.writeln('.no-print{display: none;}');
        Popup.document.writeln('</style>');
        Popup.document.writeln('</head><body>');
//        Popup.document.writeln('<a href="javascript:;" onclick="window.print();">Imprimir</a>');
        Popup.document.writeln(HTMLContent.innerHTML);
        Popup.document.writeln('<a href="javascript:;" onclick="window.print();">Imprimir</a>');
        Popup.document.writeln('</body></html>');
        Popup.document.close();
        Popup.focus();
    }
</script>

    <div class="col-md-9">
    <div id="MainDiv" style="text-align: center" >

    <img src="/img/Imagen2.png" />
    <h2 style="text-align: center">Comprobante de Compra</h2>
    <h4 style="text-align: left">Estimado(a) <asp:Label ID="lblNombr" runat="server" Text=""></asp:Label></h4>
    <h5 style="text-align: left">Le informamos que su compra a sido realizada con éxito.</h5>
    <h2 style="text-align: left">Su transacción : <asp:Label ID="lblTran" runat="server" Text=""></asp:Label></h2>
    <h4 style="text-align: left">Evento : <asp:Label ID="lblEvento" runat="server" Text=""></asp:Label></h4>
    <h4 style="text-align: left">Recinto : <asp:Label ID="lblRecinto" runat="server" Text=""></asp:Label></h4>
    <h4 style="text-align: left">Fecha : <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></h4>
    </br>
    <h2 style="text-align: center">Datos del Ticket</h2>
        <table class="table_ticket table table-bordered">        
                        <tr style="background-color: #AEB404">
                            <th >
                                Cantidad
                            </th>
                            <th >
                                Tipo entrada
                            </th>
                            <th>
                                Precio unitario
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblCant" runat="server" Text=""></asp:Label> 
                            </th>
                            <th>
                                <asp:Label ID="lblTipoEntrada" runat="server" Text=""></asp:Label>
                            </th>
                            <th>
                                $<asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label>
                            </th>
                        </tr>
                        
                   </table>
                    <h3 style="text-align: left">Total: $<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h3>
                   </br>
                    <h2 style="text-align: center">Datos del Cliente</h2>
                   <table class="table_ticket table table-bordered">        
                         <tr>
                            <th>
                                <asp:Label ID="Label1" runat="server" Text="Nombre : "></asp:Label>                                 
                            </th>
                            <th>
                                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                            </th>
                         </tr>
                         <tr>
                            <th>
                                <asp:Label ID="Label2" runat="server" Text="Run : "></asp:Label>                                 
                            </th>
                            <th>
                                <asp:Label ID="lblRut" runat="server" Text=""></asp:Label>
                            </th>
                            
                            </tr>
                            <tr>
                            <th>
                                <asp:Label ID="Label3" runat="server" Text="Dirección  : "></asp:Label>                                 
                            </th>
                            <th>
                                <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label>
                            </th>
                            </tr>
                            <tr>
                            <th>
                                <asp:Label ID="Label4" runat="server" Text="Correo : "></asp:Label>                                 
                            </th>
                            <th>
                                <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label>
                            </th>
                            </tr>
                            <tr>
                            <th>
                                <asp:Label ID="Label5" runat="server" Text="Telefono : "></asp:Label>                                 
                            </th>
                            <th>
                                <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label>
                            </th>
                            
                        </tr>
                      
                   </table>
                   <br/>
                   <br/>
                   <h5 style="text-align: center">
                    Recuerde revisar siempre su bandeja de SPAM. Es su responsabilidad además verificar que su dirección de correo electrónico este correctamente escrita para que pueda recibir este comprobante.
                    </h5>
                    <h6 style="text-align: center">
                    Este mensaje ha sido generado automáticamente, por favor no responda a este correo. En caso de que necesite comunicarse con nosotros, escríbanos a serviciocliente@e-ticket.cl
                   </h6>
                   </div>

    </div>
            <div class="col-md-12">
                    <button type="button" class="btn btn-primary" OnClick="window.location.href='/Inicio.aspx'; return false;">Volver a inicio</button>
                   <button class="btn btn-primary"  onclick="PrintThisDiv('MainDiv')" >Previsualizar impresión de página</button>
                   </div>
</asp:Content>

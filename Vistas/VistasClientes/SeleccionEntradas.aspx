<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Cliente.Master" AutoEventWireup="true" CodeBehind="SeleccionEntradas.aspx.cs" Inherits="Vistas.VistasClientes.SeleccionEntradas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function BindEvents() {
            console.log($("#<%=chkRegalo.ClientID %>"));
            $(".chkRegalo input").on("click", function () {
                console.log("adasd");
                if ($(this).prop("checked"))
                    $(".modalRegalo").modal();
            });
        }
      </script>
     <script type="text/javascript">
      <!--
          function isNumberKey(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode > 31 && (charCode < 48 || charCode > 57))
                  return false;

              return true;
          }
      //-->
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(BindEvents);
            </script>
            <div class="col-md-12">
                <asp:Label ID="lblTitulo" runat="server" Text="Evento n" Font-Size="36px"></asp:Label>
            </div>
            <div class="col-md-12">
                <div class="panel panel-default">
                    <asp:Label runat="server" ID="lblIdEvento" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="lblIdRecinto" Visible="false"></asp:Label>
                    <div class="panel-body">
                        <div class="col-md-3" style="margin-bottom:15px;">
                            <asp:Image ID="imgEvento" Width="200" Height="300"
                                runat="server" />
                        </div>
                        <div class="col-md-9" style="text-align:justify;">
                            <p>
                            <asp:Label ID="lblContenido" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-md-9">
                            <table class="table_ticket table table-bordered">
                                <thead>
                                    <tr>
                                        <th>Tipo de Entrada</th>
                                        <th>Cantidad</th>
                                        <th>Precio</th>
                                        <th>Total</th>
                                        <th>Mapa</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td> 
                                            <asp:DropDownList ID="ddlTipoEntrada" runat="server" 
                                                onselectedindexchanged="ddlTipoEntrada_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList><br />
                                            <asp:Label ID="lblselect" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td> <asp:TextBox ID="txtCantEntradas" runat="server" TextMode="Number" min="0"
                                                ontextchanged="txtCantEntradas_TextChanged" Text="1" AutoPostBack="true"></asp:TextBox><br />
                                                <asp:RangeValidator id="Range1" ControlToValidate="txtCantEntradas" MinimumValue="1" MaximumValue="999" Type="Integer"
                                                    EnableClientScript="false" Text="La cantidad de entrada no puede ser menor que 1" runat="server" ValidationGroup="cantEntrada" ForeColor="Red" /> 
                                            <asp:Label ID="lblErrCant" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td> $<asp:Label ID="txtPrecio" runat="server" Text="0"></asp:Label> </td>
                                        <td> $<asp:Label ID="txtTotal" runat="server" Text="0"></asp:Label> </td>
                                        <td> <a href="#" data-toggle="modal" data-target=".modalRecinto">Recinto</a> </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:Label ID="lblquedan" runat="server" Text="" ForeColor="Blue"></asp:Label>
                    </div>
                     <div class="col-md-9" style="margin-top:20px;">
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlAsientos" runat="server" AutoPostBack="true" CssClass="form-control">
                            </asp:DropDownList> 
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnAgregarAsiento" runat="server" class="btn btn-default" 
                                Text="Agregar Asiento" onclick="btnAgregarAsiento_Click" ValidationGroup="cantEntrada"/>
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="grvAsientos" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                                CssClass="table_ticket table table-bordered">
                                <Columns>
                                    <asp:BoundField HeaderText="Ticket" DataField="Value" />
                                    <asp:BoundField HeaderText="Asiento" DataField="Text" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="col-md-9" style="margin-top:20px;">
                        <div class="col-md-6 col-md-offset-4">
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox ID="chkRegalo" runat="server" CssClass="chkRegalo" /> Para Regalar
                                </label>
                            </div>
                        </div>
                        <div class="col-md-3 col-md-offset-9">
                            <%--<asp:Button ID="btnPagar" runat="server" Text="Pagar" class="btn btn-primary" 
                                data-toggle="modal" data-target=".modalPago" onclick="btnPagar_Click" />--%>
                                <asp:Button ID="btnPagar" runat="server" Text="Pagar" class="btn btn-primary" 
                                onclick="btnPagar_Click" />
                        </div>
                    </div>
                </div>
             </div>
        </div>
        <div class="modal fade modalRecinto" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content" style="padding:10px;">
                    <div class="modal-header">
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <h4 class="modal-title" id="gridSystemModalLabel">Detalle Recinto</h4>
                    </div>
                   <div class="modal-body" align="center">
                       <asp:Image ID="imgRecinto" runat="server" Width="350" Height="350" />
                   </div>
                </div>
            </div>
        </div>
        <div class="modal fade modalPago" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content" style="padding:10px;">
                    <div class="modal-header">
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <h4 class="modal-title" id="H1">Detalle de compra</h4>
                    </div>
                   <div class="modal-body" align="center">
                       <table class="table table-bordered">
                            <tr>
                                <th>
                                    Cantidad
                                </th>
                                <th>
                                    Tipo Ticket
                                </th>
                                <th>
                                    Total
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="txtCantDetalle" runat="server" Text=""></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="txtTipoTicketDetalle" runat="server" Text="Label"></asp:Label>
                                </th>
                                <th>
                                    $<asp:Label ID="txtPrecioDetalle" runat="server" Text="Label"></asp:Label>
                                </th>
                            </tr>
                            <caption>
                                <h1>
                                    Total: $<asp:Label ID="txtTotalDetalle" runat="server" Text="Label"></asp:Label>
                                </h1>
                            </caption>
                       </table>
                       <asp:Button ID="btnFinalizarPago" runat="server" Text="Confirmar" class="btn btn-primary" 
                                data-toggle="modal" data-target=".modalCargoPago" />
                   </div>
                </div>
            </div>
        </div>
        <div class="modal fade modalCargoPago" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content" style="padding: 10px;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="H2">
                            Detalle de compra</h4>
                    </div>
                    <div class="modal-body" align="center">
                        <img src="../img/icon/loading.gif" />
                        <h1>Procesando.....</h1>
                    </div>
                </div>
            </div>
        </div>
         </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPagar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlTipoEntrada" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtCantEntradas" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnFinalizarPago" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="modal fade modalRegalo" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content" style="padding:10px;">
                    <div class="modal-header">
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <h4 class="modal-title" id="H3">Regalar Ticket</h4>
                    </div>
                   <div class="modal-body" align="center">
                            <div class="form-group">
                                <asp:Label ID="lblParaquien" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox ID="txtParaquien" class="form-control" runat="server" placeholder="Para Quien es"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblMensaje" runat="server" Text="Enviale un Mensaje"></asp:Label>
                                <asp:TextBox ID="txtMensaje" class="form-control" runat="server"  TextMode="MultiLine" Rows="3" placeholder="Ingrese en Mensaje"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblCorreoRegalo" runat="server" Text="Correo"></asp:Label>
                                <asp:TextBox ID="txtCorreoRegalo" class="form-control" runat="server" placeholder="Ingrese Correo"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfvIngreoEmail" runat="server" ControlToValidate="txtCorreoRegalo"
                ErrorMessage="Debe ingresar el Correo Electrónico" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaRegalo"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCorreoElectronico" runat="server" ControlToValidate="txtCorreoRegalo"
                ErrorMessage="Formato de Correo Electrónico incorrecto" ForeColor="Red" Display="Dynamic"
                ValidationGroup="ValidaRegalo" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group" style="height: auto;display: inline-block; width:100%">
                            <%--<button data-dismiss="modal" class="btn btn-primary pull-right" ValidationGroup="ValidaIngreso">Regalar</button>--%>
                                <asp:Button ID="btnRegalar" runat="server" Text="Regalar" 
                                    CssClass="btn btn-primary pull-right" ValidationGroup="ValidaRegalo" 
                                    onclick="btnRegalar_Click" />
                            </div>
                   </div>
                </div>
            </div>
        </div>
</asp:Content>


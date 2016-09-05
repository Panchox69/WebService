<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="InicioOrg.aspx.cs" Inherits="Vistas.VAdm_OrganizadorDeEventos.InicioOrg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
<script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
<script>
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '<Ant',
        nextText: 'Sig>',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
            <script type="text/javascript">
                var chartData; // globar variable for hold chart data
                google.load("visualization", "1", { packages: ["corechart"] });

                $(document).ready(function () {
                    $(".fecha").datepicker();
                    function cargarDatosEstadisticas() {
                        var value = $("#<%=ddlEvento.ClientID %>").val();
                        console.log(value);
                        $.ajax({
                            type: "POST",
                            url: '/VAdm_OrganizadorDeEventos/InicioOrg.aspx/GetChartData',

                            //data: JSON.stringify("{idEvento: value}"),
                            data: '{idEvento:' + value + '}',
                            dataType: "json",

                            contentType: "application/json; chartset=utf-8",
                            success: function (data) {
                                chartData = JSON.parse(data.d);
                            },
                            error: function () {
                                alert("Error");
                            }
                        }).done(function () {
                            // after complete loading data
                            google.setOnLoadCallback(drawChart);
                            drawChart();
                        });
                    }

                    function cargarDatosEstadisticasAsientos() {
                        var value = $("#<%=ddlTipoAsiento.ClientID %>").val();
                        console.log(value);
                        $.ajax({
                            type: "POST",
                            url: '/VAdm_OrganizadorDeEventos/InicioOrg.aspx/GetChartDataTipoAsiento',

                            //data: JSON.stringify("{idEvento: value}"),
                            data: '{idTipoAsiento:' + value + '}',
                            dataType: "json",

                            contentType: "application/json; chartset=utf-8",
                            success: function (data) {
                                chartData = JSON.parse(data.d);
                            },
                            error: function () {
                                alert("Error");
                            }
                        }).done(function () {
                            // after complete loading data
                            google.setOnLoadCallback(drawChart);
                            drawChart();
                        });
                    }

                    function cargarDatosEstadisticasPorFecha() {
                        var fecha1 = $("#fecha1").val();
                        var fecha2 = $("#fecha2").val();
                        $.ajax({
                            type: "POST",
                            url: '/VAdm_OrganizadorDeEventos/InicioOrg.aspx/GetChartDataFecha',

                            //data: JSON.stringify("{idEvento: value}"),
                            data: '{fecha1:"' + fecha1 + '",fecha2:"'+fecha2+'"}',
                            dataType: "json",

                            contentType: "application/json; chartset=utf-8",
                            success: function (data) {
                                chartData = JSON.parse(data.d);
                            },
                            error: function () {
                                alert("Error");
                            }
                        }).done(function () {
                            // after complete loading data
                            google.setOnLoadCallback(drawChart);
                            drawChart();
                        });
                    }

                    //cargarDatosEstadisticas();

                    $('#<%=ddlEvento.ClientID %>').change(function () {
                        cargarDatosEstadisticas();
                    });

                    $('#<%=ddlTipoAsiento.ClientID %>').change(function () {
                        cargarDatosEstadisticasAsientos();
                    });

                    $('.buscarFecha').click(function () {
                        cargarDatosEstadisticasPorFecha();
                    });
                });


                function drawChart() {
                    var data = google.visualization.arrayToDataTable(chartData);

                    var options = {
                        curveType: 'function',
                        legend: { position: 'bottom' }

                    };
                    //var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
                    /*var lineChart = new google.visualization.LineChart(document.getElementById('line_div'));
                    lineChart.draw(data, options);
                    */
                    var PieChart = new google.visualization.PieChart(document.getElementById('col_div'));
                    PieChart.draw(data, options);
                    /*var lineChart = new google.visualization.BarChart(document.getElementById('bar_div'));
                    lineChart.draw(data, options);
                    */


                }
 
            </script>
    <div class="col-md-12">
        <h1>
            Inicio Organizador Estadisticas de Eventos
        </h1>

        <br />
        <div class="col-md-3">
            <label>Seleccione Evento: </label><br />
            <asp:DropDownList ID="ddlEvento" runat="server" onselectedindexchanged="ddlEvento_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-md-5">
            <label>Seleccione Rango de Fechas</label><br />
            <input type="text" id="fecha1" class="fecha" /> - <input type="text" id="fecha2" class="fecha" />
            <button type="button" class="btn btn-default buscarFecha"><i class="glyphicon glyphicon-search"></i>Mostrar</button>
        </div> 
        <div class="col-md-3">
            <label>Seleccione Tipo de Entrada</label><br />
            <asp:DropDownList ID="ddlTipoAsiento" runat="server">
            </asp:DropDownList>
        </div> 
       
    </div>
 <div class="col-md-12">
    <div class="col-md-6">
        <div id="col_div" style="width:500px;height:400px">
                <%-- Here Chart Will Load --%>
        </div>
    </div>
 </div>
</asp:Content>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BLL;
using BEL;
using System.Web.Script.Serialization;

namespace Vistas.VAdm_OrganizadorDeEventos
{
    public partial class InicioOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioBEL usuario = (UsuarioBEL)Session["usuarioConectado"];
                TipoAsientoBLL bllTipo = new TipoAsientoBLL();
                EventoBLL eventoBLL = new EventoBLL();
                int rut = usuario.Rut;

                ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();

                ddlEvento.DataSource = eventoBLL.traerEventos(rut);
                ddlEvento.DataTextField = "Nombre";
                ddlEvento.DataValueField = "IdEvento";
                ddlEvento.DataBind();

                ddlTipoAsiento.DataSource = bllTipo.traerTiposAsientos();
                ddlTipoAsiento.DataTextField = "Nombre";
                ddlTipoAsiento.DataValueField = "IdTipoAsiento";
                ddlTipoAsiento.DataBind();
                if (eventoBLL.traerEventos(rut).Count != 0)
                {
                    string idEvento = ddlEvento.SelectedItem.Value;
                    GetChartDataTipoAsiento("1");
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string GetChartData(string idEvento)
        {
            var chartData = new object[3];
            chartData[0] = new object[]{
                    "Product Category",
                    "Asientos"
                };

            EventoBLL even = new EventoBLL();
            EventoBEL evento = even.traerEventoId(Int32.Parse(idEvento));
            int cantTotal = even.totalEntradasPorEventos(Int32.Parse(idEvento));
            int cantTotalVendidas = even.totalEntradasVendidasPorEventos(Int32.Parse(idEvento));
            chartData[1] = new object[] { "Asientos Disponibles", cantTotal };
            chartData[2] = new object[] { "Asientos Vendidos", cantTotalVendidas };
            var jsonSerializator = new JavaScriptSerializer();
            return jsonSerializator.Serialize(chartData);
        }

        [System.Web.Services.WebMethod]
        public static string GetChartDataFecha(string fecha1, string fecha2)
        {

            var chartData = new object[3];
            chartData[0] = new object[]{
                    "Product Category",
                    "Asientos"
                };
            EventoBLL even = new EventoBLL();
            int cantTotal = 0;
            int cantTotalVendidas = 0;
            DateTime fechaInicio = DateTime.Parse(fecha1);
            DateTime fechaFin = DateTime.Parse(fecha2);
            List<EventoBEL> eventos = even.buscarEventosRango(fechaInicio, fechaFin);
            foreach (EventoBEL evento in eventos)
            {
                cantTotal += even.totalEntradasPorEventos(evento.IdEvento);
                cantTotalVendidas += even.totalEntradasVendidasPorEventos(evento.IdEvento);
            }
            chartData[1] = new object[] { "Asientos Disponibles", cantTotal };
            chartData[2] = new object[] { "Asientos Vendidos", cantTotalVendidas };
            var jsonSerializator = new JavaScriptSerializer();
            return jsonSerializator.Serialize(chartData);
        }

        [System.Web.Services.WebMethod]
        public static string GetChartDataTipoAsiento(string idTipoAsiento)
        {

            var chartData = new object[3];
            chartData[0] = new object[]{
                    "Product Category",
                    "Asientos"
                };
            EventoBLL even = new EventoBLL();
            int cantTotal = even.totalEntradasPorTipoEntrada(Int32.Parse(idTipoAsiento));
            int cantTotalVendidas = even.totalEntradasVendidasPorTipoEntrada(Int32.Parse(idTipoAsiento));
            chartData[1] = new object[] { "Asientos Disponibles", cantTotal };
            chartData[2] = new object[] { "Asientos Vendidos", cantTotalVendidas };
            var jsonSerializator = new JavaScriptSerializer();
            return jsonSerializator.Serialize(chartData);
        }

        protected void ddlEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();
            int rut;
            if (usuario.Usuario.IndexOf('-') != -1)
            {
                String[] separadorRut = usuario.Usuario.Split('-');
                rut = Int32.Parse(separadorRut[0]);
            }
            else
            {
                rut = Int32.Parse(usuario.Usuario);
            }
            string idEvento = ddlEvento.SelectedItem.Value;
            GetChartData(idEvento);
        }
    }
}
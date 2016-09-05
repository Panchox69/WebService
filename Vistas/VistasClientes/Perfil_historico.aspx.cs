using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;

namespace Vistas.VistasClientes
{
    public partial class Perfil_historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla del cliente conectado con todas las compras realizadas
            /// </summary>
            if (!IsPostBack)
            {
                PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
                String[] separadorRut = usuario.Usuario.Split('-');
                ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();
                grvHistorico.DataSource = bllClienteTicket.traerClienteTicket(Int32.Parse(separadorRut[0]));
                grvHistorico.DataBind();
            }
        }

        /// <summary>
        /// Pagina la grilla trayendo los datos de 5 en 5
        /// </summary>
        protected void grvHistorico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            String[] separadorRut = usuario.Usuario.Split('-');
            ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();
            grvHistorico.DataSource = bllClienteTicket.traerClienteTicket(Int32.Parse(separadorRut[0]));
            grvHistorico.PageIndex = e.NewPageIndex;
            grvHistorico.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;

namespace Vistas.VAdm_OrganizadorDeEventos
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con las ventas del evento seleccionado en el select
            /// </summary>
            if(!IsPostBack)
            {
                PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
                EventoBLL eventoBLL = new EventoBLL();
                int rut;
                if(usuario.Usuario.IndexOf('-') != -1){
                    String[] separadorRut = usuario.Usuario.Split('-');
                    rut = Int32.Parse(separadorRut[0]);
                }else{
                    rut = Int32.Parse(usuario.Usuario);
                }
                
                ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();
                grvContrato.DataSource = bllClienteTicket.traerClienteTicketOrg(rut);
                grvContrato.DataBind();

                ddlEvento.DataSource = eventoBLL.traerEventos(rut);
                ddlEvento.DataTextField = "Nombre";
                ddlEvento.DataValueField = "IdEvento";
                ddlEvento.DataBind();
            }
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (Session["event_controle"] != null)
                {
                    TextBox controle = (TextBox)Session["event_controle"];

                    controle.Focus();
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// Deshabilita la venta seleccionada en la grilla
        /// </summary>
        protected void grvContrato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();
    
            if (e.CommandName.Equals("Eliminar"))
            {
                PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
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

                bllClienteTicket.eliminarClienteTicket(Int32.Parse(e.CommandArgument.ToString()));
                grvContrato.DataSource = bllClienteTicket.traerClienteTicketOrg(rut);
                grvContrato.DataBind();
            }
        }


        /// <summary>
        /// Select para traer los datos de las ventas por evento que se seleccione
        /// </summary>
        protected void ddlEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["event_controle"] = ((DropDownList)sender);
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

            int idEvento = Int32.Parse(ddlEvento.SelectedItem.Value);
            grvContrato.DataSource = bllClienteTicket.traerClienteTicketOrg(rut,idEvento);
            grvContrato.DataBind();
        }


        /// <summary>
        /// Pagina la grilla trayendo los datos de 5 en 5
        /// </summary>
        protected void grvContrato_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            EventoBLL eventoBLL = new EventoBLL();
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

            ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();
            grvContrato.DataSource = bllClienteTicket.traerClienteTicketOrg(rut);
            grvContrato.PageIndex = e.NewPageIndex;
            grvContrato.DataBind();
        }
    }
}
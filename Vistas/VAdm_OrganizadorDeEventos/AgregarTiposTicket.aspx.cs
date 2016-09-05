using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;

namespace Vistas.VAdm_Mantenedor
{
    public partial class AgregarTiposTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Trae los datos del tipo de ticket a modificar
            /// </summary>
            if (!IsPostBack)
            {
                TipoAsientoBLL asientosBLL = new TipoAsientoBLL();
                if (Request.QueryString["id"] != null)
                {
                    TiposTicketBLL tipoBLL = new TiposTicketBLL();
                    TiposTicketBEL tipo = tipoBLL.traerTiposTicketPorId(Int32.Parse(Request.QueryString["id"].ToString()));
                    lblTitulo.Text = "Editar Tipo Ticket";
                    idTipoTicket.Text = tipo.IdTipoTicket.ToString();
                    txtPrecio.Text = tipo.Precio.ToString();
                }
                ddlTipoAsiento.DataSource = asientosBLL.traerTiposAsientos();
                ddlTipoAsiento.DataValueField = "IdTipoAsiento";
                ddlTipoAsiento.DataTextField = "Nombre";
                ddlTipoAsiento.DataBind();
            }
        }

        /// <summary>
        /// Guarda o Edita el Tipo de Ticket
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TiposTicketBLL tipoBLL = new TiposTicketBLL();
            TiposTicketBEL tipoBEL = new TiposTicketBEL();

            tipoBEL.IdTipoAsiento = Int32.Parse(ddlTipoAsiento.SelectedItem.Value);
            tipoBEL.Precio = Int32.Parse(txtPrecio.Text);
            tipoBEL.IdEvento = Int32.Parse(Session["idEvento"].ToString());
            /// <summary>
            /// Edita el Tipo de Ticket
            /// </summary>
            if (lblTitulo.Text.Equals("Editar Tipo Ticket"))
            {
                tipoBEL.IdTipoTicket = Int32.Parse(idTipoTicket.Text);
                tipoBLL.actualizarTiposTicket(tipoBEL);
                Response.Write("<script>alert('Se editó correctamente');window.location='TiposTicket.aspx?idEvento="+tipoBEL.IdEvento+"';</script></script>");
            }
            /// <summary>
            /// Guarda el Tipo de Ticket
            /// </summary>
            else
            {
                tipoBLL.agregarTiposTicket(tipoBEL);
                Response.Write("<script>alert('Se agregó correctamente');window.location='TiposTicket.aspx?idEvento=" + tipoBEL.IdEvento + "';</script></script>");
            }
        }
    }
}
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
    public partial class TiposTicket : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con los tipos de tickets registrados
            /// </summary>
            if(!IsPostBack){
                int idEvento = 0;

                /// <summary>
                /// Revisa si el id del evento es distinto de null para traer los datos
                /// </summary>
                if (Request.QueryString["idEvento"] != null)
                {
                    Session["idEvento"] = Request.QueryString["idEvento"].ToString();
                    idEvento = Int32.Parse(Request.QueryString["idEvento"].ToString());
                }
                /// <summary>
                /// Si el id es null redirecciona a la pagina Eventos.aspx
                /// </summary>
                else
                {
                    Response.Redirect("Eventos.aspx");
                    return;
                }
                TiposTicketBLL tipoBLL = new TiposTicketBLL();
                grvTipos.DataSource = tipoBLL.traerTiposTicket(idEvento);
                grvTipos.DataBind();
            }
        }


        /// <summary>
        /// Elimina o modifica el tipo de ticket
        /// </summary>
        protected void grvTipos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TiposTicketBLL tipoBLL = new TiposTicketBLL();
            /// <summary>
            /// Modifica el tipo de ticket
            /// </summary>
            if (e.CommandName.Equals("modificar"))
            {
                Response.Redirect(string.Format("AgregarTiposTicket.aspx?id={0}", e.CommandArgument.ToString()), false);
            }
            /// <summary>
            /// Elimina el tipo de ticket
            /// </summary>
            else if (e.CommandName.Equals("Eliminar"))
            {
                int idEvento = Int32.Parse(Session["idEvento"].ToString());
                tipoBLL.eliminarTiposTicket(Int32.Parse(e.CommandArgument.ToString()));
                grvTipos.DataSource = tipoBLL.traerTiposTicket(idEvento);
                grvTipos.DataBind();
            }
        }
    }
}
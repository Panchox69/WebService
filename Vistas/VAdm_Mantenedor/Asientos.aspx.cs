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
    public partial class Asientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con todos los asientos registrados de un Evento 
            /// </summary>
            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Session["idRecinto"] = Request.QueryString["id"].ToString();
                }
                else
                {
                    Response.Redirect("Recintos.aspx");
                    return;
                }
                AsientoBLL asBLL = new AsientoBLL();
                grvAsientos.DataSource = asBLL.traerAsientos();
                grvAsientos.DataBind();
            }
        }

        /// <summary>
        /// Modifica o elimina el asiento seleccionado en la grilla
        /// </summary>
        protected void grvAsientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AsientoBLL asBLL = new AsientoBLL();
            if (e.CommandName.Equals("modificar"))
            {
                Response.Redirect(string.Format("AgregarAsiento.aspx?id={0}", e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                asBLL.eliminarAsiento(Int32.Parse(e.CommandArgument.ToString()));
                grvAsientos.DataSource = asBLL.traerAsientos();
                grvAsientos.DataBind();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class CerrarSesion : System.Web.UI.Page
    {

        /// <summary>
        /// Cierra la sesion del usuario activo
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuarioConectado"] = null;
            Session["_menu"] = null;
            Response.Redirect("Inicio.aspx");
        }
    }
}
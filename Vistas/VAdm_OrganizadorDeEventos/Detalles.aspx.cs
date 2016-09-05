using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.VAdm_OrganizadorDeEventos
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grvDetallePerdidas.DataSource = new List<AttributeCollection>();
            grvDetallePerdidas.DataBind();

            grvDetalleVentas.DataSource = new List<AttributeCollection>();
            grvDetalleVentas.DataBind();
        }
    }
}
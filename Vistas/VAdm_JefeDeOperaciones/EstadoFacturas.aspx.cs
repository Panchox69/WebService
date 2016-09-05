using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.VAdm_JefeDeOperaciones
{
    public partial class EstadoFacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grvFacturas.DataSource = new List<AttributeCollection>();
            grvFacturas.DataBind();
        }
    }
}
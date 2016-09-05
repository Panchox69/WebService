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
    public partial class verRecinto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Muestra los datos del recinto Nombre, Direccion e Imagen
            /// </summary>
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    RecintoBLL recintoBLL = new RecintoBLL();
                    RecintoBEL recBEL = recintoBLL.traerRecintoPorId(Int32.Parse(Request.QueryString["id"]));

                    lblNombre.Text = recBEL.NombreRecinto;
                    lblDireccion.Text = recBEL.DireccionRecinto;
                    imgRecinto.ImageUrl = recBEL.ImagenRecinto;
                }
            }
        }
    }
}
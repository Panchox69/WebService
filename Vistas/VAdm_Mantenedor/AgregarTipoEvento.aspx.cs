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
    public partial class AgregarTipoEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /// <summary>
            /// Carga los datos si se requiere actualiar o editar
            /// </summary>
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    lblTitulo.Text = "Modificar Tipo Evento";
                    TipoEventoBLL tipoBLL = new TipoEventoBLL();
                    TipoEventoBEL tipoBEL = tipoBLL.taerEnventoPorId(Int32.Parse(Request.QueryString["id"]));

                    txtNombre.Text = tipoBEL.DescripcionTipoEvento;
                    idTipoEvento.Text = tipoBEL.IdTipoEvento.ToString();
                }
            }

        }


        /// <summary>
        /// Guarda los datos entregados por el usuario 
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoEventoBEL tipoEvento = new TipoEventoBEL();
            tipoEvento.DescripcionTipoEvento = txtNombre.Text;
            
            TipoEventoBLL tipevebll = new TipoEventoBLL();
            if (lblTitulo.Text == "Modificar Tipo Evento")
            {
                tipoEvento.IdTipoEvento = Int32.Parse(idTipoEvento.Text);
                tipevebll.editarTipoEvento(tipoEvento);
                Response.Write("<script>alert('Datos modificados correctamente'); window.location='TiposEventos.aspx';</script>");
            }
            else
            {
                tipevebll.agregarTipoEvento(tipoEvento);
                Response.Write("<script>alert('Se agregó correctamente');window.location='TiposEventos.aspx';</script>");
                txtNombre.Text = String.Empty;
            }
        }
    }
}
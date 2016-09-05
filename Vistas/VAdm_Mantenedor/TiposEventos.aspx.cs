using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;

namespace Vistas.VAdm_Mantenedor
{
    public partial class TiposEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con todos los tipos de eventos registrados
            /// </summary>
            if (!IsPostBack)
            {
                TipoEventoBLL tipoEventosBLL = new TipoEventoBLL();

                grvTipos.DataSource = tipoEventosBLL.listaDeTiposEventos();
                grvTipos.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Modifica o Elimina el tipo de evento seleccionado
        /// </summary>
        protected void grvTipos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TipoEventoBLL eventoBLL = new TipoEventoBLL();

            if (e.CommandName.Equals("modificar"))
            {
                Response.Redirect(string.Format("AgregarTipoEvento.aspx?id={0}", e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                eventoBLL.eliminarTipoEvento(Int32.Parse(e.CommandArgument.ToString()));

                /// <summary>
                /// Carga la grilla con todos los tipos de eventos registrados
                /// </summary>
                TipoEventoBLL tipoEventosBLL = new TipoEventoBLL();
                grvTipos.DataSource = tipoEventosBLL.listaDeTiposEventos();
                grvTipos.DataBind();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCambioDePagina(object sender, GridViewPageEventArgs e)
        {
            grvTipos.PageIndex = e.NewPageIndex;
            TipoEventoBLL tipoEventosBLL = new TipoEventoBLL();
            grvTipos.DataSource = tipoEventosBLL.listaDeTiposEventos();
            grvTipos.DataBind();
        }
    }
}
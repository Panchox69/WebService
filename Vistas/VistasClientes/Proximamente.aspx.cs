using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;

namespace Vistas.VistasClientes
{
    public partial class Proximamente : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con todos los eventos que esten en estado p (proximo)
            /// </summary>
            if (!IsPostBack)
            {
                cargarDDL();
                cargaEventos();
                grvEventos.Visible = true;
                EventoBLL evento = new EventoBLL();
                grvEventos.DataSource = evento.traerEventosProximos();
                grvEventos.DataBind();

            }
        }

        /// <summary>
        /// Carga la grilla con los eventos del select seleccionado (tipo de evento)
        /// </summary>
        private void cargaEventos()
        {
            EventoBLL events = new EventoBLL();
            List<EventoBEL> eventos = new List<EventoBEL>();
            int id = Int32.Parse(ddlFiltro.SelectedValue);
            if (id == -5)
            {
                id = 6;
            }
            eventos = events.traerEventoPorTipoEvento(id);
            grvEventos.DataSource = eventos;
            grvEventos.DataBind();
        }


        /// <summary>
        /// Carga el select con los tipos de eventos registrados
        /// </summary>
        private void cargarDDL()
        {
            TipoEventoBLL tipo = new TipoEventoBLL();
            List<TipoEventoBEL> tipos = new List<TipoEventoBEL>();
            tipos = tipo.listaDeTiposEventos();

            ddlFiltro.DataTextField = "DescripcionTipoEvento";
            ddlFiltro.DataValueField = "IdTipoEvento";
            ddlFiltro.DataSource = tipos;
            ddlFiltro.DataBind();

            ddlFiltro.Items.Insert(0, new ListItem("¿Qué quieres ver?", "-5"));
        }


        /// <summary>
        /// Pagina la grilla trayendo los datos de 5 en 5
        /// </summary>
        protected void grvEventos_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEventos.PageIndex = e.NewPageIndex;
            cargaEventos();
        }

        protected void ddlFiltro_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            cargaEventos();
        }
    }
}
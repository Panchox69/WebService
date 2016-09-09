using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;
using System.Data;

namespace Vistas.VistasClientes
{
    public partial class EventosSemana : System.Web.UI.Page
    {
        /// <summary>
        /// Deshabilita la venta seleccionada en la grilla
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDDL();
                cargaEventos();
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string Label1 = Calendar1.SelectedDate.ToShortDateString();

            String s = "";
            foreach (DateTime d in Calendar1.SelectedDates)
            {
                s += d.ToShortDateString();
            }
            Label1 = s.Replace("-", "/");
            DateTime dt = Convert.ToDateTime(Label1);
            grvEventos.Visible = true;
            EventoBLL evento = new EventoBLL();
            grvEventos.DataSource = evento.buscarEventos(dt);
            
            grvEventos.DataBind();
        }

        private void cargaEventos()
        {
           /* DataTable table = new DataTable();
            table.Columns.Add("Imagen");
            table.Columns.Add("Nombre");
            table.Columns.Add("Tipo");
            table.Columns.Add("Productor");
            table.Columns.Add("TipoUnidad");
            table.Columns.Add("Precio");
            table.Columns.Add("Stock");

                      

            DataRow row1 = table.NewRow();
            ImagenesBLL imaBLL = new ImagenesBLL();
            List<ImagenesBEL> imagenes = new List<ImagenesBEL>();
            imagenes = imaBLL.Imagenes_Sel_All();
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();*/
            ProductosBLL proBLL = new ProductosBLL();
            List<ProductosBEL> productos = new List<ProductosBEL>();
            productos = proBLL.Productos_Sel_All();
           
            //table.Rows.Add(row1);

            //eventos = events.traerEventoPorTipoEvento(id);
            //grvEventos.DataSource = table;
            grvEventos.DataSource = productos;
            grvEventos.DataBind();
        }

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
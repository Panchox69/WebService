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
    public partial class Recintos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con todos los recintos registrados
            /// </summary>
            if (!IsPostBack)
            {
                //linea con mensaje de cuadro de busqueda
                txtBusqueda.Attributes.Add("placeholder", "Ingrese nombre de recinto");
                RecintoBLL recBLL = new RecintoBLL();
                grvEventos.DataSource = recBLL.traerRecintos();
                grvEventos.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Habilita, Modifica o Elimina el recinto seleccionado
        /// </summary>
        protected void grvEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            RecintoBLL recBLL = new RecintoBLL();

            if (e.CommandName.Equals("modificar"))
            {
                Response.Redirect(string.Format("AgregarRecinto.aspx?id={0}", e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                recBLL.eliminarRecinto(Int32.Parse(e.CommandArgument.ToString()));
                grvEventos.DataSource = recBLL.traerRecintos();
                grvEventos.DataBind();
            }
            else if (e.CommandName.Equals("habilitar"))
            {
                RecintoBEL rec = recBLL.traerRecintoPorId(Int32.Parse(e.CommandArgument.ToString()));
                rec.IdEstado = 1;
                recBLL.editarRecinto(rec);
                grvEventos.DataSource = recBLL.traerRecintos();
                grvEventos.DataBind();
            }
            else if (e.CommandName.Equals("asiento"))
            {
                Response.Redirect(string.Format("Asientos.aspx?id={0}", e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("ver")) 
            {
                Response.Redirect(string.Format("verRecinto.aspx?id={0}", e.CommandArgument.ToString()), false);
            }
        }

        /// <summary>
        /// Busca un recinto por id 
        /// </summary>
        protected void btnBusqueda_Click1(object sender, EventArgs e)
        {
            RecintoBLL recBLL = new RecintoBLL();
            grvEventos.DataSource = recBLL.buscarRecintos(txtBusqueda.Text);
            grvEventos.DataBind();
        }

        /// <summary>
        /// Habilita o Deshabilita el recinto seleccionado
        /// </summary>
        protected void grvEventos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text.CompareTo("Deshabilitado") == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Tomato;
                    ((Button)e.Row.FindControl("btnEliminar")).Text = "Habilitar";
                    ((Button)e.Row.FindControl("btnEliminar")).CommandName = "habilitar";
                }
            }
        }

        /// <summary>
        /// Busca un recinto por habilitado o deshabilitado
        /// </summary>
        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemSel = Int32.Parse(ddlFiltro.SelectedItem.Value);
            if (itemSel == 1 || itemSel == 0)
            {
                RecintoBLL recBLL = new RecintoBLL();
                grvEventos.DataSource = recBLL.filtrarRecintos(itemSel);
                grvEventos.DataBind();
            }
            else
            {
                RecintoBLL recBLL = new RecintoBLL();
                grvEventos.DataSource = recBLL.traerRecintos();
                grvEventos.DataBind();
            }
            
        }

    }
}
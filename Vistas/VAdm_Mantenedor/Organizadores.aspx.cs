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
    public partial class Organizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con todos los organizadores registrados
            /// </summary>
            if (!IsPostBack)
            {
                //linea con mensaje de cuadro de busqueda
                txtBusqueda.Attributes.Add("placeholder", "Ingrese run de organizador");
                OrganizadorBLL organizador = new OrganizadorBLL();
                grvOrganizadores.DataSource = organizador.listaOrganizador();
                grvOrganizadores.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Habilita, Modifica o Elimina al organizador seleccionado
        /// </summary>
        protected void grvOrganizadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            OrganizadorBLL organizadorBLL = new OrganizadorBLL();

            if (e.CommandName.Equals("modificarOrganizador"))
            {
                Response.Redirect(string.Format("AgregarOrganizador.aspx?Rut={0}", e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("EliminarOrganizador"))
            {
                organizadorBLL.eliminarOrganizador(Int32.Parse(e.CommandArgument.ToString()));
                grvOrganizadores.DataSource = organizadorBLL.listaOrganizador();
                grvOrganizadores.DataBind();
            }
            else if (e.CommandName.Equals("habilitar"))
            {
                OrganizadorBEL org = organizadorBLL.MostrarOrganizador(Int32.Parse(e.CommandArgument.ToString()));
                org.IdEstado = 1;
                organizadorBLL.editarOrganizador(org);
                grvOrganizadores.DataSource = organizadorBLL.listaOrganizador();
                grvOrganizadores.DataBind();

            }
        }

        /// <summary>
        /// Busca a un organizador por run 
        /// </summary>
        protected void btnBusqueda_Click1(object sender, EventArgs e)
        {
            try
            {
                OrganizadorBLL orgBLL = new OrganizadorBLL();
                grvOrganizadores.DataSource = orgBLL.buscarOrganizadores(Int32.Parse(txtBusqueda.Text));
                grvOrganizadores.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Rut solo números'); </script>");
            }
        }




        /// <summary>
        /// Habilita o Deshabilita al cliente seleccionado
        /// </summary>
        protected void grvOrganizadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text.CompareTo("Deshabilitado") == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Tomato;
                    ((Button)e.Row.FindControl("btnEliminar")).Text = "Habilitar";
                    ((Button)e.Row.FindControl("btnEliminar")).CommandName = "habilitar";
                }
            }
        }

        /// <summary>
        /// Busca a un organizador por habilitado o deshabilitado
        /// </summary>
        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemSel = Int32.Parse(ddlFiltro.SelectedItem.Value);
            if (itemSel == 1 || itemSel == 0)
            {
                OrganizadorBLL orgBLL = new OrganizadorBLL();
                grvOrganizadores.DataSource = orgBLL.FiltarOrganizadores(itemSel);
                grvOrganizadores.DataBind();
            }
            else
            {
                OrganizadorBLL organizador = new OrganizadorBLL();
                grvOrganizadores.DataSource = organizador.listaOrganizador();
                grvOrganizadores.DataBind();
            }

        }
    }
}
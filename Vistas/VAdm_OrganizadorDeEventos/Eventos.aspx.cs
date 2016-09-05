using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;

namespace Vistas.VAdm_OrganizadorDeEventos
{
    public partial class Eventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la grilla con todos los eventos registrados
            /// </summary>
            if(!IsPostBack)
            {
                EventoBLL evBLL = new EventoBLL();
                PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
                String[] separadorRut = usuario.Usuario.Split('-');
                grvEventos.DataSource = evBLL.traerEventos(Int32.Parse(separadorRut[0]));
                grvEventos.DataBind();

                RecintoBLL recBLL = new RecintoBLL();
                ddlRecintos.DataSource = recBLL.traerRecintos();
                ddlRecintos.DataValueField = "IdRecinto";
                ddlRecintos.DataTextField = "NombreRecinto";
                ddlRecintos.DataBind();
                ddlRecintos.Items.Insert(0, new ListItem("..Seleccione Recinto..", "-1"));

                TipoEventoBLL tipBLL = new TipoEventoBLL();
                ddlTipoEventos.DataSource = tipBLL.listaDeTiposEventos();
                ddlTipoEventos.DataValueField = "IdTipoEvento";
                ddlTipoEventos.DataTextField = "DescripcionTipoEvento";
                ddlTipoEventos.DataBind();
                ddlTipoEventos.Items.Insert(0, new ListItem("..Seleccione Tipo Evento..", "-1"));
            }
        }


        /// <summary>
        /// Filtra los eventos por estado, se debe filtrar ademas por run del organizador
        /// </summary>
        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            String estado = ddlFiltro.SelectedItem.Value;
            EventoBLL evBLL = new EventoBLL();
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            String[] separadorRut = usuario.Usuario.Split('-');
            if (estado.Equals(""))
            {
                grvEventos.DataSource = evBLL.traerEventos(Int32.Parse(separadorRut[0]));
                grvEventos.DataBind();
            }
            else
            {
                grvEventos.DataSource = evBLL.traerEventoPorEstado(estado, Int32.Parse(separadorRut[0]));
                grvEventos.DataBind();
            }
        }

        /// <summary>
        /// Filtra los eventos por id o nombre segun el checkbox seleccionado
        /// </summary>
        protected void btnBusqueda_Click1(object sender, EventArgs e)
        {
            EventoBLL evBLL = new EventoBLL();
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            String[] separadorRut = usuario.Usuario.Split('-');
            if (txtBusqueda.Text == "")
            {
                return;
            }
            if(Id_evento.Checked)
            {
                try
                {
                    grvEventos.DataSource = evBLL.traerEventosPorBusqueda(Int32.Parse(txtBusqueda.Text), Int32.Parse(separadorRut[0]));
                    grvEventos.DataBind();
                }
                catch 
                {
                    Response.Write("<script>alert('Código solo números'); </script>");
                }
                
            }
            if(Nombre.Checked)
            {
                grvEventos.DataSource = evBLL.traerEventosPorBusqueda(txtBusqueda.Text, Int32.Parse(separadorRut[0]));
                grvEventos.DataBind();
            }
        }


        /// <summary>
        /// Modifica redireccionando a la pagina AgregarEvento.aspx o Elimina el evento seleccionado, ademas modifica el tipo de ticket redireccionando a la pagina TiposTicket.aspx
        /// </summary>
        protected void grvEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EventoBLL evBLL = new EventoBLL();
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            String[] separadorRut = usuario.Usuario.Split('-');
            if (e.CommandName.Equals("modificar"))
            {
                Response.Redirect(string.Format("AgregarEvento.aspx?id={0}", e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                evBLL.eliminarEvento(Int32.Parse(e.CommandArgument.ToString()));
                grvEventos.DataSource = evBLL.traerEventos(Int32.Parse(separadorRut[0]));
                grvEventos.DataBind();
            }
            else if (e.CommandName.Equals("tipos"))
            {
                Response.Redirect(string.Format("TiposTicket.aspx?idEvento={0}", e.CommandArgument.ToString()), false);
            }
        }


        /// <summary>
        /// Los elementos eliminados son deshabilitados y se pintan de color rojo
        /// </summary>
        protected void grvEventos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text.CompareTo("Eliminado") == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Tomato;
                    ((Button)e.Row.FindControl("btnEliminar")).Text = "Habilitar";
                    ((Button)e.Row.FindControl("btnEliminar")).CommandName = "habilitar";
                }
            }
        }

        /// <summary>
        /// Carga la grilla con los tipos de eventos registrados
        /// </summary>
        protected void ddlTipoEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTipoEvento = Int32.Parse(ddlTipoEventos.SelectedItem.Value);
            EventoBLL evBLL = new EventoBLL();
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            String[] separadorRut = usuario.Usuario.Split('-');
            grvEventos.DataSource = evBLL.traerEventoPorTipoEvento(idTipoEvento, Int32.Parse(separadorRut[0]));
            grvEventos.DataBind();
        }



        /// <summary>
        /// Carga la grilla con los recintos registrados
        /// </summary>
        protected void ddlRecintos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idRecinto = Int32.Parse(ddlRecintos.SelectedItem.Value);
            EventoBLL evBLL = new EventoBLL();
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            String[] separadorRut = usuario.Usuario.Split('-');
            grvEventos.DataSource = evBLL.traerEventoPorRecintos(idRecinto, Int32.Parse(separadorRut[0]));
            grvEventos.DataBind();
        }
    }
}
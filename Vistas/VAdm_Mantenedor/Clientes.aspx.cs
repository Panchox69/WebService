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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /// <summary>
            /// Carga la grilla con todos los clientes registrados
            /// </summary>
            if (!IsPostBack)
            {
                //linea con mensaje de cuadro de busqueda
                txtBusqueda.Attributes.Add("placeholder", "Ingrese rut de cliente");
                ClienteBLL cliBLL = new ClienteBLL();
                grvEventos.DataSource = cliBLL.traerClientes();
                grvEventos.DataBind();
            }

        }


        /// <summary>
        /// Habilita, Modifica o Elimina al cliente seleccionado
        /// </summary>
        protected void grvEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClienteBLL cliBLL = new ClienteBLL();

            if (e.CommandName.Equals("modificar"))
            {
                Response.Redirect(string.Format("ModificarCliente.aspx?rut={0}", e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                cliBLL.eliminarClientePorRut(Int32.Parse(e.CommandArgument.ToString()));
                grvEventos.DataSource = cliBLL.traerClientes();
                grvEventos.DataBind();
            }
            else if (e.CommandName.Equals("habilitar"))
            {
                ClienteBEL cli = cliBLL.traerClientePorRut(Int32.Parse(e.CommandArgument.ToString()));
                //cli.IdEstado = 1;
                cliBLL.actualizarCliente(cli);
                grvEventos.DataSource = cliBLL.traerClientes();
                grvEventos.DataBind();
            }
        }


        /// <summary>
        /// Busca a un cliente por nombre, rut o apellido segun el checbox seleccionado 
        /// </summary>
        protected void btnBusqueda_Click1(object sender, EventArgs e)
        {
            ClienteBLL cliBLL = new ClienteBLL();
            if (string.IsNullOrEmpty(txtBusqueda.Text))
            {
                grvEventos.DataSource = cliBLL.traerClientes();
                grvEventos.DataBind();
            }
            else
            {

                if (Rut.Checked == true)
                {
                    try
                    {
                        grvEventos.DataSource = cliBLL.buscarClientes(Int32.Parse(txtBusqueda.Text));
                        grvEventos.DataBind();
                    }
                    catch
                    {
                        Response.Write("<script>alert('Rut solo números'); </script>");
                    }




                }
                if (Nombre.Checked == true)
                {
                    grvEventos.DataSource = cliBLL.buscarClientes(txtBusqueda.Text);
                    grvEventos.DataBind();
                }
                if (Apellido.Checked == true)
                {
                    grvEventos.DataSource = cliBLL.buscarCliente(txtBusqueda.Text);
                    grvEventos.DataBind();
                }
            }

        }


        /// <summary>
        /// Habilita o Deshabilita al cliente seleccionado
        /// </summary>
        protected void grvEventos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[6].Text.CompareTo("Deshabilitado") == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Tomato;
                    ((Button)e.Row.FindControl("btnEliminar")).Text = "Habilitar";
                    ((Button)e.Row.FindControl("btnEliminar")).CommandName = "habilitar";
                }
            }
        }


        /// <summary>
        /// Busca a un cliente por habilitado o deshabilitado
        /// </summary>
        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemSel = Int32.Parse(ddlFiltro.SelectedItem.Value);
            if (itemSel == 1 || itemSel == 0)
            {
                ClienteBLL cliBLL = new ClienteBLL();
                grvEventos.DataSource = cliBLL.FiltrarClientes(itemSel);
                grvEventos.DataBind();
            }
            else
            {
                ClienteBLL cliBLL = new ClienteBLL();
                grvEventos.DataSource = cliBLL.traerClientes();
                grvEventos.DataBind();
            }
        }

    }
}
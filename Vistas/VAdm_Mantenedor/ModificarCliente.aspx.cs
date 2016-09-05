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
    public partial class ModificarCliente : System.Web.UI.Page
    {

        ComunaBEL clicomuna = new ComunaBEL();
        RegionBEL cliregion = new RegionBEL();
        int comuna = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga los datos del cliente a Modificar
            /// </summary>
            if (!IsPostBack)
            {
                if (Request.QueryString["Rut"] != null)
                {
                    int rut = Int32.Parse(Request.QueryString["Rut"]);
                    ClienteBLL cliBLL = new ClienteBLL();
                    ClienteBEL cliBEL = cliBLL.traerClientePorRut(rut);
                    txtRut.Text = cliBEL.Rut.ToString() + "-" + cliBEL.Dv;
                    txtRut.Enabled = false;
                    txtNombre.Text = cliBEL.Nombre;
                    txtApellidos.Text = cliBEL.Apellido;
                    //txtDireccion.Text = cliBEL.Direccion;
                    txtCorreo.Text = cliBEL.Correo;
                    txtCelular.Text = cliBEL.Celular.ToString();
                    //lblEstado.Text = cliBEL.IdEstado.ToString();
                    //comuna = cliBEL.IdComuna;
                    clicomuna = cliBLL.traerComuna(comuna);
                    cliregion = cliBLL.traerRegion(clicomuna.IdRegion);
                }

                RegionBLL regionBLL = new RegionBLL();

                List<RegionBEL> regBEL = regionBLL.traerRegiones();

                ddlRegion.DataSource = regBEL;
                ddlRegion.DataValueField = "IdRegion";
                ddlRegion.DataTextField = "Nombre";
                ddlRegion.DataBind();
                //ddlRegion.Items.Insert(0, new ListItem("..Seleccione..", "-1"));
                ddlRegion.Items.Insert(0, new ListItem(cliregion.Nombre, clicomuna.IdRegion.ToString()));
                ddlComuna.Items.Insert(0, new ListItem(clicomuna.Nombre, clicomuna.IdComuna.ToString()));



            }
        }

        /// <summary>
        /// Entrega la comuna segun la region seleccionada
        /// </summary>
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idregion = Int32.Parse(ddlRegion.SelectedItem.Value);
            ComunaBLL comBLL = new ComunaBLL();

            ddlComuna.DataSource = comBLL.traerComunasPorRegion(idregion);
            ddlComuna.DataValueField = "IdComuna";
            ddlComuna.DataTextField = "Nombre";
            ddlComuna.DataBind();
            //ddlComuna.Items.Insert(0, new ListItem("..Seleccione..", "-1"));
        }

        /// <summary>
        /// Guarda los datos entregados por el usuario
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String[] separadorRut = txtRut.Text.Split('-');
            ClienteBEL cliBEL = new ClienteBEL();
            cliBEL.Rut = Int32.Parse(separadorRut[0]);
            cliBEL.Dv = Char.Parse(separadorRut[1]);
            cliBEL.Nombre = txtNombre.Text;
            cliBEL.Apellido = txtApellidos.Text;
            //cliBEL.Direccion = txtDireccion.Text;
            cliBEL.Correo = txtCorreo.Text;
            cliBEL.Celular = Int32.Parse(txtCelular.Text);
            //cliBEL.IdComuna = Int32.Parse(ddlComuna.SelectedItem.Value);
            ClienteBLL cliBLL = new ClienteBLL();
            if (lblTitulo.Text.CompareTo("Modificar Cliente") == 0)
            {
                //cliBEL.IdEstado = Int32.Parse(lblEstado.Text);
                cliBLL.actualizarCliente(cliBEL);
                Response.Write("<script>alert('Datos modificados correctamente');window.location='Clientes.aspx';</script></script>");
            }
            else
            {
                cliBLL.registroCliente(cliBEL);
                Response.Write("<script>alert('Se agregó correctamente');window.location='Clientes.aspx';</script></script>");
                txtRut.Text = String.Empty;
                txtNombre.Text = String.Empty;
                txtApellidos.Text = String.Empty;
                txtDireccion.Text = String.Empty;
                txtCorreo.Text = String.Empty;
                txtCelular.Text = String.Empty;
            }
        }
    }
}
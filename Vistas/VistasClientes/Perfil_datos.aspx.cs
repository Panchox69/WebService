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
    public partial class Perfil_datos : System.Web.UI.Page
    {
        int verificar = 0;
        int estado = 0;
        int comuna = 0;
        ComunaBEL clicomuna = new ComunaBEL();
        RegionBEL cliregion = new RegionBEL();
        

        protected void Page_Load(object sender, EventArgs e)
        {

            UsuarioBEL usuario = (UsuarioBEL)Session["usuarioConectado"];

            /// <summary>
            /// Carga los datos del cliente u organizador a modificar
            /// </summary>
            if (!IsPostBack)
            {                
                int rut = (usuario.Rut);
                //ru = ru.Substring(0, ru.Length - 2);
                //int rut = Int32.Parse(ru);
                ClienteBLL cliBLL = new ClienteBLL();
                ClienteBEL cliBEL = new ClienteBEL();
                cliBEL = cliBLL.traerClientePorRut(rut);
                if (cliBEL != null)
                {
                    txtGiro.Visible = false;
                    txtApellidos.Visible = true;
                    lblCambiante.Text = "Apellidos";
                    lblCambian.Text = "Nombre";
                    reqApellido.Enabled = true;
                    regApellido.Enabled = true;
                    reqGiro.Enabled = false;
                    regGiro.Enabled = false;
                    txtRut.Text = cliBEL.Rut.ToString() + "-" + cliBEL.Dv;
                    txtRut.Enabled = false;
                    txtNombre.Text = cliBEL.Nombre;
                    txtApellidos.Text = cliBEL.Apellido;
                    //txtDireccion.Text = cliBEL.Direccion;
                    txtCorreo.Text = cliBEL.Correo;
                    txtCelular.Text = cliBEL.Celular.ToString();
                    //comuna = cliBEL.IdComuna;
                    
                    clicomuna = cliBLL.traerComuna(comuna);
                    cliregion = cliBLL.traerRegion(clicomuna.IdRegion);
                    //estado = cliBEL.IdEstado;
                }
                else
                {
                    txtGiro.Visible = true;
                    txtApellidos.Visible = false;
                    txtCelular.Visible = false;
                    lblCelular.Visible = false;
                    lblCambiante.Text = "Giro";
                    lblCambian.Text = "Nombre o Razón Social";
                    reqGiro.Enabled = true;
                    regGiro.Enabled = true;
                    reqApellido.Enabled = false;
                    regApellido.Enabled = false;

                    OrganizadorBLL orgBLL = new OrganizadorBLL();
                    OrganizadorBEL orgBEL = new OrganizadorBEL();
                    orgBEL = orgBLL.MostrarOrganizador(rut);
                    txtRut.Text = orgBEL.Rut.ToString() + "-" + orgBEL.Dv;
                    txtRut.Enabled = false;
                    txtNombre.Text = orgBEL.NombreRazonSocial;
                    txtGiro.Text = orgBEL.Giro;
                    txtDireccion.Text = orgBEL.Direccion;
                    txtCorreo.Text = orgBEL.Correo;
                    comuna = orgBEL.IdComuna;
                    clicomuna = cliBLL.traerComuna(comuna);
                    cliregion = cliBLL.traerRegion(clicomuna.IdRegion);
                    estado = orgBEL.IdEstado;
                }
                /// <summary>
                /// Carga los select de region y comuna con sus datos correspondientes
                /// </summary>
                RegionBLL regionBLL = new RegionBLL();

                List<RegionBEL> regBEL = regionBLL.traerRegiones();

                ddlRegion.DataSource = regBEL;
                ddlRegion.DataValueField = "IdRegion";
                ddlRegion.DataTextField = "Nombre";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem(cliregion.Nombre, clicomuna.IdRegion.ToString()));
                ddlComuna.Items.Insert(0, new ListItem(clicomuna.Nombre, clicomuna.IdComuna.ToString()));
            }
        }


        /// <summary>
        /// Carga las comunas en el select segun la region seleccionada
        /// </summary>
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idregion = Int32.Parse(ddlRegion.SelectedItem.Value);
            ComunaBLL comBLL = new ComunaBLL();

            ddlComuna.DataSource = comBLL.traerComunasPorRegion(idregion);
            ddlComuna.DataValueField = "IdComuna";
            ddlComuna.DataTextField = "Nombre";
            ddlComuna.DataBind();
        }
        
        /// <summary>
        /// Guarda los nuevo datos de Cliente u Organizador conectado
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String[] separadorRut = txtRut.Text.Split('-');
            PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
            int perfil = (usuario.IdTipoPerfil);
            if (perfil == 4)
            {
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
                //cliBEL.IdEstado = estado;
                cliBLL.actualizarCliente(cliBEL);
            }
            else
            {
                OrganizadorBEL orgBEL = new OrganizadorBEL();
                orgBEL.Rut = Int32.Parse(separadorRut[0]);
                orgBEL.Dv = Char.Parse(separadorRut[1]);
                orgBEL.NombreRazonSocial = txtNombre.Text;
                orgBEL.Giro = txtApellidos.Text;
                orgBEL.Direccion = txtDireccion.Text;
                orgBEL.Correo = txtCorreo.Text;
                //orgBEL.Celular = Int32.Parse(txtCelular.Text);
                orgBEL.IdComuna = Int32.Parse(ddlComuna.SelectedItem.Value);
                OrganizadorBLL orgBLL = new OrganizadorBLL();
                orgBEL.IdEstado = estado;
                orgBLL.editarOrganizador(orgBEL);
            }
            Response.Write("<script>alert('Datos modificados correctamente');window.location='Perfil_datos.aspx';</script></script>");

        }
    }
}

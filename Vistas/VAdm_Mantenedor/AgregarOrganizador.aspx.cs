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
    public partial class AgregarOrganizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComunaBEL clicomuna = new ComunaBEL();
            RegionBEL cliregion = new RegionBEL();
            int comuna = 0;
            /// <summary>
            /// Carga los datos si se requiere actualiar o editar
            /// </summary>
            if (!IsPostBack)
            {
                if(Request.QueryString["Rut"] != null)
                {
                    int rut = Int32.Parse(Request.QueryString["Rut"]);
                    lblTitulo.Text = "Editar Organizador";
                    ClienteBLL cliBLL = new ClienteBLL();
                    OrganizadorBLL orgBLL = new OrganizadorBLL();
                    OrganizadorBEL orgBEL = orgBLL.MostrarOrganizador(rut);
                    txtRut.Text = orgBEL.Rut.ToString() + "-"+orgBEL.Dv;
                    txtRut.Enabled = false;
                    txtNombre.Text = orgBEL.NombreRazonSocial;
                    txtGiro.Text = orgBEL.Giro;
                    txtDireccion.Text = orgBEL.Direccion;
                    txtCorreo.Text = orgBEL.Correo;
                    lblEstado.Text = orgBEL.IdEstado.ToString();
                    comuna = orgBEL.IdComuna;
                    clicomuna = cliBLL.traerComuna(comuna);
                    cliregion = cliBLL.traerRegion(clicomuna.IdRegion);
                }
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
        }


        /// <summary>
        /// Guarda los datos entregados por el usuario
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String[] separadorRut = txtRut.Text.Split('-');
            OrganizadorBEL orgBEL = new OrganizadorBEL();
            orgBEL.Rut = Int32.Parse(separadorRut[0]);
            orgBEL.Dv = Char.Parse(separadorRut[1]);
            orgBEL.NombreRazonSocial = txtNombre.Text;
            orgBEL.Giro = txtGiro.Text;
            orgBEL.Direccion = txtDireccion.Text;
            orgBEL.Correo = txtCorreo.Text;
            orgBEL.IdComuna = Int32.Parse(ddlComuna.SelectedItem.Value);
            orgBEL.Valido = "v";
            OrganizadorBLL orgBLL = new OrganizadorBLL();
            if (lblTitulo.Text.CompareTo("Editar Organizador") == 0)
            {
                orgBEL.IdEstado = Int32.Parse(lblEstado.Text);
                orgBLL.editarOrganizador(orgBEL);
                Response.Write("<script>alert('Datos modificados correctamente');window.location='Organizadores.aspx';</script>");
            }
            else {
                orgBLL.registroOrganizador(orgBEL);
                Response.Write("<script>alert('Se agregó correctamente');window.location='Organizadores.aspx';</script>");
                txtRut.Text = String.Empty;
                txtNombre.Text = String.Empty;
                txtGiro.Text = String.Empty;
                txtDireccion.Text = String.Empty;
                txtCorreo.Text = String.Empty;
            }
        }

        /// <summary>
        /// Llama a la funcion validar rut si el rut es mayor a 2
        /// </summary>
        protected void txtRut_OnTextChanged(object sender, EventArgs e)
        {
            if (txtRut.Text.Trim().Length > 2)
            {
                if (validarRut(txtRut.Text))
                {
                    lblValRut.Visible = false;
                }
                else
                {
                    lblValRut.Visible = true;
                }
            }
        }

        /// <summary>
        /// Valida el rut si es correcto
        /// </summary>
        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
}
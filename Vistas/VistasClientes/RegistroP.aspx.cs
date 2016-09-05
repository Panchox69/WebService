using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;
using System.Collections;
using System.Data;

namespace Vistas
{
    public partial class RegistroP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// 
            /// </summary>
            if (!IsPostBack)
            {
                Session["Captcha"] = null;

                txtDireccionNegocio.Visible = false;
                lblDireccionNegocio.Visible = false;
                lblNumeroNegocio.Visible = false;
                txtNumeroNegocio.Visible = false;
                lblComunaNegocio.Visible = false;
                ddlComunaNegocio.Visible = false;
                lblRegionNegocio.Visible = false;
                ddlRegionNegocio.Visible = false;
                
                
                fru.WebServicePruebaSoapClient service = new fru.WebServicePruebaSoapClient();
                // ArrayList regBEL = new ArrayList();
                // string regBEL = service.Regiones().ToString();
                RegionBLL regionBLL = new RegionBLL();
                //string asd = regionBLL.traerRegiones1();
                List<RegionBEL> regBEL = regionBLL.traerRegiones1();
                /*DataSet ds = service.Regiones();
                var myData = ds.Tables[0].AsEnumerable().Select(r => new
                {
                    column1 = r.Field<int>("ID_REGION"),
                    column2 = r.Field<string>("NOMBRE")
                });
                var list = myData.ToList();*/

                ddlRegion.DataSource = regBEL;
                ddlRegion.DataValueField = "IdRegion";
                ddlRegion.DataTextField = "Nombre";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("..Seleccione..", "-1"));

                ddlRegionNegocio.DataSource = regBEL;
                ddlRegionNegocio.DataValueField = "IdRegion";
                ddlRegionNegocio.DataTextField = "Nombre";
                ddlRegionNegocio.DataBind();
                ddlRegionNegocio.Items.Insert(0, new ListItem("..Seleccione..", "-1"));


                //InteresBLL inteBLL = new InteresBLL();
                //List<InteresBEL> interesesBEL = inteBLL.traerIntereses();

                //chkIntereses.DataSource = interesesBEL;
                //chkIntereses.DataValueField = "IdInteres";
                //chkIntereses.DataTextField = "Descripcion";
                //chkIntereses.DataBind();
            }
        }

        /// <summary>
        /// Jose Onate:: separé el método en registrar() para tener mayor orden visual en las validaciones.
        /// Reparé la implementación en la Validación del Rut.
        /// Agregué la validación de selección de intereses.
        /// Agregué la validación de Acepto condiciones.
        /// Agregué la validación de contraseñas iguales.
        /// Agregué redirección a página de inicio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (validarRut(txtRut.Text))
            {
                //if (selInteres())
                //{
                if (chkAcepto.Checked)
                {
                    if (comparaCaptcha())
                    {
                        if (comparaContrasena())
                        {
                            registrar();
                            Response.Write("<script>alert('El registro se completó correctamente');</script>");
                            Response.Redirect("../Inicio.aspx", false);
                        }
                        else lblCon.Visible = true;
                    }
                    else
                    {
                        lblCon.Visible = true;
                        TextBox1.Text = string.Empty;
                    }
                }
                else
                {
                    lblAce.Visible = true;
                    TextBox1.Text = string.Empty;
                }
                // }
                //else
                //{
                //  lblSel.Visible = true;
                // TextBox1.Text = string.Empty;
                //}
            }
            else
            {
                lblValRut.Visible = true;
                TextBox1.Text = string.Empty;
            }
        }

        /// <summary>
        /// José Oñate::
        /// Método para validar selección de al menos 1 interés.
        /// </summary>
        /// <returns></returns>
        /*private bool selInteres()
        {
            bool selecciona = false;
            int contador = 0;

            foreach (ListItem item in chkIntereses.Items)
            {
                if (item.Selected) contador++;
            }

            if (contador != 0) selecciona = true;

            return selecciona;
        }*/

        /// <summary>
        /// José Oñate::
        /// Separación del método registrar para generar mayor orden visual
        /// </summary>
        private void registrar()
        {
            String[] separadorRut = txtRut.Text.Split('-');

            /*ProductorHabilitadoBLL prohabBLL = new ProductorHabilitadoBLL();
            ProductorHabilitadoBEL prohab = prohabBLL.Productor_Habilitados_Sel(Int32.Parse(separadorRut[0]));

            if (prohab.Rut != -1)
            {
                txtApellidos.Text = prohab.Apellido;
                txtNombre.Text = prohab.Nombre;
            
            }

            
            ProductorHabilitadoBEL prohabBEL = new ProductorHabilitadoBEL();*/



            UsuarioBEL usuBEL = new UsuarioBEL();
            usuBEL.Rut = Int32.Parse(separadorRut[0]);
            usuBEL.Contrasena = txtContrasena.Text;
            usuBEL.IdTipoPerfil = 2;

            PerfilBLL perBLL = new PerfilBLL();
            perBLL.agregarUsuario(usuBEL);

            DireccionBEL direccionBEL = new DireccionBEL();
            direccionBEL.Nombre = txtDireccion.Text;
            direccionBEL.Numero = Int32.Parse(txtnumero.Text);
            direccionBEL.Id_comuna = Int32.Parse(ddlComuna.SelectedItem.Value);

            DireccionBLL direccionBLL = new DireccionBLL();
            int id_direccion = direccionBLL.agregarDireccion(direccionBEL);

            if (chkNegocio.Checked)
                {
                    DireccionBEL direccionNegBEL = new DireccionBEL();
                    
                    direccionNegBEL.Nombre = txtDireccionNegocio.Text;
                    direccionNegBEL.Numero = Int32.Parse(txtNumeroNegocio.Text);
                    direccionNegBEL.Id_comuna = Int32.Parse(ddlComunaNegocio.SelectedItem.Value);
                    
                    DireccionBLL direccionNegBLL = new DireccionBLL();
                    int id_direccionNeg = direccionNegBLL.agregarDireccion(direccionNegBEL);

                    ProductorBEL productorBEL = new ProductorBEL();

                    productorBEL.Rut = Int32.Parse(separadorRut[0]);
                    productorBEL.Dv = Char.Parse(separadorRut[1]);
                    productorBEL.Nombre = txtNombre.Text;
                    productorBEL.Apellido = txtApellidos.Text;
                    productorBEL.Sexo = Char.Parse(txtSexo.Text);
                    productorBEL.Id_direccionparticular = id_direccion;
                    if (chbCell.Checked)
                        productorBEL.Celular = Int32.Parse(txtCell.Text);
                    else
                        productorBEL.Celular = Int32.Parse(txtTelefono.Text);
                    productorBEL.Correo = txtCorreo.Text;
                    productorBEL.Id_direccionnegocio = id_direccionNeg;
                    productorBEL.Mismadireccion = 0;


                    ProductorBLL productorBLL = new ProductorBLL();
                    productorBLL.registroProductor(productorBEL);
                }
                else
                {
                               

            ProductorBEL productorBEL = new ProductorBEL();

            productorBEL.Rut = Int32.Parse(separadorRut[0]);
            productorBEL.Dv = Char.Parse(separadorRut[1]);
            productorBEL.Nombre = txtNombre.Text;
            productorBEL.Apellido = txtApellidos.Text;
            productorBEL.Sexo = Char.Parse(txtSexo.Text);
            productorBEL.Id_direccionparticular = id_direccion;            
            if (chbCell.Checked)
                productorBEL.Celular = Int32.Parse(txtCell.Text);
            else
                productorBEL.Celular = Int32.Parse(txtTelefono.Text);
            productorBEL.Correo = txtCorreo.Text;
            productorBEL.Id_direccionnegocio = id_direccion;
            productorBEL.Mismadireccion = 1;

            ProductorBLL productorBLL = new ProductorBLL();
            productorBLL.registroProductor(productorBEL);
            }
            
            UsuarioPerfilesBEL usuperBEL = new UsuarioPerfilesBEL();
            usuperBEL.Rut = Int32.Parse(separadorRut[0]);
            usuperBEL.Id_tipo_perfil = 1;

            UsuarioPerfilesBLL usuperBLL = new UsuarioPerfilesBLL();
            usuperBLL.agregarUsuarioPerfiles(usuperBEL);
          }


        

        /// <summary>
        /// José Oñate::
        /// Agregué el item -1 ..Seleccione.. para mejor operación y validación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idregion = Int32.Parse(ddlRegion.SelectedItem.Value);
            ComunaBLL comBLL = new ComunaBLL();

            ddlComuna.DataSource = comBLL.traerComunasPorRegion1(idregion);
            ddlComuna.DataValueField = "IdComuna";
            ddlComuna.DataTextField = "Nombre";
            ddlComuna.DataBind();
            ddlComuna.Items.Insert(0, new ListItem("..Seleccione..", "-1"));
        }

        protected void ddlRegionNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idregion = Int32.Parse(ddlRegionNegocio.SelectedItem.Value);
            ComunaBLL comBLL = new ComunaBLL();

            ddlComunaNegocio.DataSource = comBLL.traerComunasPorRegion1(idregion);
            ddlComunaNegocio.DataValueField = "IdComuna";
            ddlComunaNegocio.DataTextField = "Nombre";
            ddlComunaNegocio.DataBind();
            ddlComunaNegocio.Items.Insert(0, new ListItem("..Seleccione..", "-1"));

        }

        

        /// <summary>
        /// José Oñate::
        /// método para validar RUT o RUN
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        private bool validarRut(string rut)
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

        /// <summary>
        /// José Oñate::
        /// Mostrar etiquetas (label) trabajo conjunto con la validación.
        /// Autoformato de N° Identificación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtRut_TextChanged(object sender, EventArgs e)
        {
            rfRUT.Enabled = false;

            ProductorHabilitadoBEL prohabBEL = new ProductorHabilitadoBEL();

            if (txtRut.Text.Trim().Length > 1)
            {
                string rut = txtRut.Text;
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                string formatRut = rut.Substring(0, rut.Length - 1) + "-" + rut.Substring(rut.Length - 1);

                txtRut.Text = formatRut;

                if (validarRut(txtRut.Text))
                {
                    String[] separadorRut = txtRut.Text.Split('-');

                    ProductorHabilitadoBLL prohabBLL = new ProductorHabilitadoBLL();
                    ProductorHabilitadoBEL prohab = prohabBLL.Productor_Habilitados_Sel(Int32.Parse(separadorRut[0]));

                    if (prohab.Equals(null))
                    {

                        lblValRut.Visible = true;
                    }
                    else
                    {
                        txtApellidos.Text = prohab.Apellido;
                        txtNombre.Text = prohab.Nombre;
                        txtFecha.Text = Convert.ToString(prohab.Fecha);
                    }
                    lblValRut.Visible = false;
                }
                else lblValRut.Visible = true;
            }
            else lblValRut.Visible = true;
        }

        /// <summary>
        /// José Oñate::
        /// Mostrar u ocultar etiqueta de Acepto contrato, trabajo conjunto con validación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkAcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAcepto.Checked) lblAce.Visible = false;

            else lblAce.Visible = true;
        }

        /// <summary>
        /// José Oñate::
        /// Mostrar u ocultar etiqueta de Interés seleccionado, trabajo conjunto con validación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /* protected void chkIntereses_CheckedChanged(object sender, EventArgs e)
         {
             if (selInteres()) lblSel.Visible = false;

             else lblSel.Visible = true;
         }*/

        /// <summary>
        /// José Oñate::
        /// Método para comparar contraseñas.
        /// </summary>
        /// <returns></returns>
        private bool comparaContrasena()
        {
            bool contrasena = false;
            if (txtContrasena.Text == txtContrasena2.Text) contrasena = true;

            return contrasena;
        }

        /// <summary>
        /// José Oñate::
        /// Se agrega check box para especificar formato de teléfono.
        /// Se automatizan cambios para validaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chbCell_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbCell.Checked)
            {
                reTele.Enabled = true;
                rfTele.Enabled = true;
                txtTelefono.Visible = true;

                reCell.Enabled = false;
                rfCell.Enabled = false;
                txtCell.Visible = false;
            }
            else
            {
                reCell.Enabled = true;
                rfCell.Enabled = true;
                txtCell.Visible = true;

                reTele.Enabled = false;
                rfTele.Enabled = false;
                txtTelefono.Visible = false;
            }
        }

        private bool comparaCaptcha()
        {
            if (Session["Captcha"] != null && ((TextBox1.Text).Equals(Session["Captcha"].ToString(), StringComparison.CurrentCultureIgnoreCase)))
            {
                lblcap.ForeColor = System.Drawing.Color.Green;
                lblcap.Font.Size = FontUnit.Larger;
                lblcap.Visible = false;
                return true;

            }
            else
            {
                lblcap.ForeColor = System.Drawing.Color.Red;
                lblcap.Font.Size = FontUnit.Larger;
                lblcap.Visible = true;
                return false;
            }

        }

        protected void txtCell_TextChanged(object sender, EventArgs e)
        {
            if (txtCell.Text.Length == 8)
            {
                txtCell.Text = "9" + txtCell.Text;
            }
        }

        protected void chkNegocio_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNegocio.Checked)
            {
                txtDireccionNegocio.Visible = false;
                lblDireccionNegocio.Visible = false;
                lblNumeroNegocio.Visible = false;
                txtNumeroNegocio.Visible = false;
                lblComunaNegocio.Visible = false;
                ddlComunaNegocio.Visible = false;
                lblRegionNegocio.Visible = false;
                ddlRegionNegocio.Visible = false;
            }
            else
            {
                txtDireccionNegocio.Visible = true;
                lblDireccionNegocio.Visible = true;
                lblNumeroNegocio.Visible = true;
                txtNumeroNegocio.Visible = true;
                lblComunaNegocio.Visible = true;
                ddlComunaNegocio.Visible = true;
                lblRegionNegocio.Visible = true;
                ddlRegionNegocio.Visible = true;
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;

namespace Vistas.MasterPage
{
    public partial class Cliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// José Oñate:
        /// Validación de RUT o RUN
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        private bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper().Trim();
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

        protected void Login1_Authenticate(object sender, EventArgs e)
        {
            PerfilBLL perfiles = new PerfilBLL();
            
            String pass = txtPass.Text;
            String[] separadorRut = txtRut.Text.Split('-');
            String user = txtRut.Text;
            int rut = Int32.Parse(separadorRut[0]);

            if (validarRut(user))
            {
                if (pass != "")
                {
                    UsuarioBEL usuario = perfiles.buscarUsuarios(rut, pass);
                    if (usuario != null)
                    {
                        Session["usuarioConectado"] = usuario;

                        switch (usuario.IdTipoPerfil)
                        {
                            case 1:
                                Response.Redirect("/VistasClientes/EventosSemana.aspx");
                                break;
                            case 2:
                                Response.Redirect("/VAdm_OrganizadorDeEventos/AgregarEvento.aspx");
                                break;
                            case 3:
                                Response.Redirect("/VAdm_JefeDeOperaciones/InicioOper.aspx");
                                break;
                            case 4:
                                Response.Redirect("/Inicio.aspx");
                                break;
                            default:
                                Response.Redirect("/Inicio.aspx");
                                break;
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

        }

        protected void rutChange(object sender, EventArgs e)
        {
            if (txtRut.Text.Trim().Length > 1)
            {
                string rut = txtRut.Text.Trim();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                string formatRut = rut.Substring(0, rut.Length - 1) + "-" + rut.Substring(rut.Length - 1);

                txtRut.Text = formatRut;

                if (validarRut(txtRut.Text)) lblM.Visible = false;
                else lblM.Visible = true;
            }
            else lblM.Visible = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using System.Net;
using BEL;
using BLL;

namespace Vistas.VistasClientes
{
    public partial class Detalle_compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Crea la boleta y manda el correo electronico para el comprador y para la persona adicional si es que regalo las entradas
            /// </summary>
            if (!IsPostBack)
            {
                PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
                string ru = (usuario.Usuario);
                ru = ru.Substring(0, ru.Length - 2);
                int rut = Int32.Parse(ru);
                ClienteBLL cliBLL = new ClienteBLL();
                ClienteBEL cliBEL = new ClienteBEL();
                EventoBLL evBLL = new EventoBLL();
                cliBEL = cliBLL.traerClientePorRut(rut);
                lblNombre.Text = cliBEL.Nombre + " " + cliBEL.Apellido;
                lblNombr.Text = cliBEL.Nombre + " " + cliBEL.Apellido;
                lblRut.Text = cliBEL.Rut + "-" + cliBEL.Dv;
                lblTelefono.Text = cliBEL.Celular.ToString();
                lblCorreo.Text = cliBEL.Correo;
               // lblDireccion.Text = cliBEL.Direccion;

                String[] arrayString = (String[])Session["detalle_compra"];
                lblCant.Text = arrayString[0];
                lblTipoEntrada.Text = arrayString[2];
                lblPrecio.Text = arrayString[1];
                lblTotal.Text = arrayString[3];
                lblEvento.Text = arrayString[4];

                int IdEvento = Int32.Parse(arrayString[6]);
                EventoBEL even = evBLL.traerEventoRecintoNombre(IdEvento);
                lblRecinto.Text = even.NombreRecinto;
                lblTran.Text = arrayString[7];
                even = evBLL.traerEventoId(IdEvento);
                lblFecha.Text = even.Fecha.ToString();

                String correoParaMandar = String.Empty;

                if (arrayString[5] != "")
                {
                    correoParaMandar = arrayString[5];
                    /// <summary>
                    /// Crea un servidor de correo gmail para enviar el correo a la persona de regalo
                    /// </summary>
                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(correoParaMandar));
                    email.From = new MailAddress(correoParaMandar);
                    email.Subject = "E-Ticket : Entrada/s de Regalo ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                    email.Body = "El cliente " + cliBEL.Nombre + " " + cliBEL.Apellido + " le regalo entrada/s para el evento " + arrayString[4] + " retira tus entradas en cualquiera de nuestras sucursales.\n\n Presenta el numero de transaccion para hacer valida la compra y retira tus entradas para el evento.\n\n El numero de transaccion es:  " + arrayString[7];
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.Normal;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("gperez@habilis.cl", "panchox77");


                    try
                    {
                        smtp.Send(email);
                        email.Dispose();

                    }
                    catch
                    {

                    }

                }
                correoParaMandar = cliBEL.Correo;

                /// <summary>
                /// Crea un servidor de correo gmail para enviar el correo al Cliente
                /// </summary>
                MailMessage email1 = new MailMessage();
                email1.To.Add(new MailAddress(correoParaMandar));
                email1.From = new MailAddress(correoParaMandar);
                email1.Subject = "E-Ticket : Detalle de Compra ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email1.Body = "Estimado/a " + cliBEL.Nombre + " " + cliBEL.Apellido + " su compra se realizo con exito. Evento " + arrayString[4] + " retira tus entradas en cualquiera de nuestras sucursales.\n\n Presenta el numero de transaccion para hacer valida la compra y retira tus entradas para el evento.\n\n El numero de transaccion es:  " + arrayString[7];
                email1.IsBodyHtml = true;
                email1.Priority = MailPriority.Normal;

                SmtpClient smtp1 = new SmtpClient();
                smtp1.Host = "smtp.gmail.com";
                smtp1.Port = 587;
                smtp1.EnableSsl = true;
                smtp1.UseDefaultCredentials = false;
                smtp1.Credentials = new NetworkCredential("gperez@habilis.cl", "panchox77");


                try
                {
                    smtp1.Send(email1);
                    email1.Dispose();

                }
                catch
                {

                }

            }
        }
    }
}
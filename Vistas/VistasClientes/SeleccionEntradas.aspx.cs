using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace Vistas.VistasClientes
{
    public partial class SeleccionEntradas : System.Web.UI.Page
    {
        public ArrayList listaAsientos,listaGrilla;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga la pagina con los datos del evento a comprar
            /// </summary>
            if (!IsPostBack)
            {
                TiposTicketBLL bllTipos = new TiposTicketBLL();
                EventoBLL bllEvento = new EventoBLL();
                RecintoBLL bllRecinto = new RecintoBLL();
                AsientoBLL bllAsiento = new AsientoBLL();
                /// <summary>
                /// El usuario debe estar registrado para comprar entradas
                /// </summary>
                if (Request.QueryString["evento"] != null)
                {
                    if (Session["usuarioConectado"] == null)
                    {
                        Response.Write("<script>alert('Necesitas iniciar sesión para comprar');window.location='Registro.aspx';</script>");
                        return;
                    }
                    int idEvento = Int32.Parse(Request.QueryString["evento"].ToString());

                    EventoBEL evento = bllEvento.traerEventoId(idEvento);
                    RecintoBEL recinto = bllRecinto.traerRecintoPorId(evento.IdRecinto);
                    this.listaAsientos = new ArrayList();
                    this.listaGrilla = new ArrayList();
                    Session["listaAsientos"] = this.listaAsientos;
                    Session["listaGrilla"] = this.listaGrilla;

                    ddlTipoEntrada.DataSource = bllTipos.traerTiposTicket(idEvento);
                    ddlTipoEntrada.DataValueField = "IdTipoTicket";
                    ddlTipoEntrada.DataTextField = "Descripcion";
                    ddlTipoEntrada.DataBind();
                    ddlTipoEntrada.Items.Insert(0, new ListItem("..Seleccione..", "-1"));

                    lblTitulo.Text = evento.Nombre;
                    imgEvento.ImageUrl = evento.Imagen;
                    lblContenido.Text = evento.Descripcion;
                    imgRecinto.ImageUrl = recinto.ImagenRecinto;
                    lblIdEvento.Text = idEvento.ToString();
                    lblIdRecinto.Text = evento.IdRecinto.ToString();
                    btnAgregarAsiento.Enabled = false;
                    btnPagar.Enabled = false;
                    lblErrCant.Visible = false;
                    lblselect.Visible = false;
                }
                else
                {
                    Response.Redirect("EventosSemana.aspx");
                }
            }
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (Session["event_controle"] != null)
                {
                    TextBox controle = (TextBox)Session["event_controle"];

                    controle.Focus();
                }
            }
            catch
            {

            }
        }

        protected void txtCantEntradas_TextChanged(object sender, EventArgs e)
        {
            AsientoBLL bllAsiento = new AsientoBLL();
            int precio = Int32.Parse(txtPrecio.Text);
            int cant = Int32.Parse(txtCantEntradas.Text);

            int IdTipoTicket = Int32.Parse(ddlTipoEntrada.SelectedItem.Value);
            if (IdTipoTicket == -1)
            {
                lblselect.Text = "Seleccione Tipo";
                lblselect.Visible = true;
                return;
            }
            else
            {
                lblselect.Visible = false;
                int IdEvento = Int32.Parse(lblIdEvento.Text);
                TiposTicketBLL bllTipos = new TiposTicketBLL();

                TiposTicketBEL tipo = bllTipos.traerTiposTicketPorId(IdTipoTicket);
                int cantMax = bllAsiento.traerAsientos(IdEvento, tipo.IdTipoAsiento).Count();
                if (cant > cantMax)
                {
                    txtCantEntradas.Text = "1";
                    lblErrCant.Text = "La cantidad ingresada no es valida";
                    lblErrCant.Visible = true;
                    return;
                }
                else
                {
                    lblErrCant.Visible = false;
                }
                if (Session["listaAsientos"] != null)
                {
                    this.listaAsientos = (ArrayList)Session["listaAsientos"];
                    this.listaGrilla = (ArrayList)Session["listaGrilla"];
                }
                else
                {
                    this.listaAsientos = new ArrayList();
                    this.listaGrilla = new ArrayList();
                }
                int indice = this.listaAsientos.Count;
                if (indice == 0 || indice <= cant)
                {
                    txtTotal.Text = (precio * cant).ToString();
                    ddlAsientos.Visible = true;
                    btnAgregarAsiento.Visible = true;
                }
                else
                {
                    txtCantEntradas.Text = (cant - 1).ToString();
                }
            }
        }

        protected void ddlTipoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["event_controle"] = ((DropDownList)sender);
            lblselect.Visible = false;
            if (ddlTipoEntrada.SelectedItem.Value.Equals("-1"))
            {
                txtPrecio.Text = "0";
                txtTotal.Text = "0";
                return;
            }
            int idTipoTicket = Int32.Parse(ddlTipoEntrada.SelectedItem.Value);
            int idEvento = Int32.Parse(lblIdEvento.Text);
            TiposTicketBLL bllTipos = new TiposTicketBLL();

            TiposTicketBEL tipo = bllTipos.traerTiposTicketPorId(idTipoTicket);

            txtPrecio.Text = tipo.Precio.ToString();
            int cant = Int32.Parse(txtCantEntradas.Text);
            txtTotal.Text = (tipo.Precio * cant).ToString();

            AsientoBLL bllAsiento = new AsientoBLL();
            ddlAsientos.DataSource = bllAsiento.traerAsientos(idEvento, tipo.IdTipoAsiento);
            ddlAsientos.DataValueField = "IdAsiento";
            ddlAsientos.DataTextField = "Numero";
            ddlAsientos.DataBind();
            ddlAsientos.Items.Insert(0, new ListItem("..Seleccione..", "-1"));
            btnAgregarAsiento.Enabled = true;
        }

        protected void btnAgregarAsiento_Click(object sender, EventArgs e)
        {
            Session["event_controle"] = ((Button)sender);
            lblErrCant.Visible = false;
            if (Session["listaAsientos"] != null)
            {
                this.listaAsientos = (ArrayList)Session["listaAsientos"];
                this.listaGrilla = (ArrayList)Session["listaGrilla"];
            }
            else
            {
                this.listaAsientos = new ArrayList();
                this.listaGrilla = new ArrayList();
            }
            int indice = this.listaAsientos.Count;
            if (ddlAsientos.SelectedItem == null || ddlAsientos.SelectedItem.Value.Equals("-1"))
            {
                ddlTipoEntrada.Focus();
                return;
            }
            int idAsiento = Int32.Parse(ddlAsientos.SelectedItem.Value);
            int numero = Int32.Parse(ddlAsientos.SelectedItem.Text);
            int cant = Int32.Parse(txtCantEntradas.Text);
            lblquedan.Visible = true;
            lblquedan.Text = "Siga Seleccionando Asiento";
            if (indice < cant)
            {
                this.listaAsientos.Add(new ListItem((indice + 1).ToString(), idAsiento.ToString()));
                this.listaGrilla.Add(new ListItem((indice + 1).ToString(),numero.ToString()));
                Session["listaAsientos"] = this.listaAsientos;
                Session["listaGrilla"] = this.listaGrilla;
                grvAsientos.DataSource = this.listaGrilla;
                grvAsientos.DataBind();
                ddlAsientos.Items.Remove(ddlAsientos.Items.FindByText(ddlAsientos.SelectedItem.Text));

            }
            else
            {
                lblquedan.Visible = false;             
                ddlAsientos.Visible = false;
                btnAgregarAsiento.Visible = false;
                btnPagar.Enabled = true;
            }

            if (indice + 1 == cant)
            {
                lblquedan.Visible = false;                
                ddlAsientos.Visible = false;
                btnAgregarAsiento.Visible = false;
                btnPagar.Enabled = true;
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            TicketBLL bllTicket = new TicketBLL();
            ClienteTicketBLL bllClienteTicket = new ClienteTicketBLL();
            //String[] detalles;

            if (Session["listaAsientos"] != null)
            {
                this.listaAsientos = (ArrayList)Session["listaAsientos"];
                TicketBEL ticket;
                ClienteTicketBEL cliTicket;
                PerfilBEL usuario = (PerfilBEL)Session["usuarioConectado"];
                if (usuario == null)
                {
                    Response.Write("<script>alert('Necesitas iniciar sesión para comprar');window.location='Registro.aspx';</script>");
                    return;
                }
                int idTicket = 0;
                foreach (ListItem val in this.listaAsientos)
                {
                    ticket = new TicketBEL();
                    ticket.IdAsiento = Int32.Parse(val.Value);
                    ticket.IdTipoTicket = Int32.Parse(ddlTipoEntrada.SelectedItem.Value);
                    ticket.IdEvento = Int32.Parse(lblIdEvento.Text);

                    idTicket = bllTicket.agregarTicket(ticket);
                    if (idTicket > 0)
                    {
                        cliTicket = new ClienteTicketBEL();
                        String[] separadorRut = usuario.Usuario.Split('-');
                        cliTicket.IdTicket = idTicket;
                        cliTicket.ClienteRut = Int32.Parse(separadorRut[0]);
                        cliTicket.Cantidad = Int32.Parse(txtCantEntradas.Text);
                        cliTicket.Total = Int32.Parse(txtTotal.Text);
                        
                        if (chkRegalo.Checked && !txtCorreoRegalo.Text.Equals(""))
                        {
                            cliTicket.Regalo = "S";
                            cliTicket.Correo = txtCorreoRegalo.Text;
                        }
                        else
                        {
                            cliTicket.Regalo = "N";
                            cliTicket.Correo = "";
                        }
                        bllClienteTicket.agregarClienteTicket(cliTicket);
                    }
                    else
                    {
                        break;
                    }
                    //String[] detalles = { txtCantEntradas.Text, txtPrecio.Text, ddlTipoEntrada.SelectedItem.Text, txtTotal.Text, lblTitulo.Text };
                    //Session["detalle_compra"] = detalles;
                }
                String[] detalles = { txtCantEntradas.Text, txtPrecio.Text, ddlTipoEntrada.SelectedItem.Text, txtTotal.Text, lblTitulo.Text,
                                        txtCorreoRegalo.Text,lblIdEvento.Text, idTicket.ToString()};
                Session["detalle_compra"] = detalles;
                //Response.Write("window.location='/VistasClientes/Detalle_compra.aspx';</script>");
                Response.Redirect("/VistasClientes/Detalle_compra.aspx");
                return;
            }
        }

        protected void btnRegalar_Click(object sender, EventArgs e)
        {
            Response.Write("<script type=\"type/javascript\">console.log('probando');$('.modalRegalo').modal('hide');</script>");
        }

       
    }
}
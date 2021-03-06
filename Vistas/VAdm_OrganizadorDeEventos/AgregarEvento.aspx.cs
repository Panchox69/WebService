﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL;
using BLL;

namespace Vistas.VAdm_OrganizadorDeEventos
{
    public partial class AgregarEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Trae los datos del Evento a Modificar
            /// </summary>
            if(!IsPostBack)
            {

                TipoProductoBLL tipoproBLL = new TipoProductoBLL();
                List<TipoProductoBEL> tipoproBEL = tipoproBLL.traerTiposProductos();

                ddlTipo.DataSource = tipoproBEL;
                ddlTipo.DataValueField = "Id_tipo_producto";
                ddlTipo.DataTextField = "Nombre";
                ddlTipo.DataBind();
                ddlTipo.Items.Insert(0, new ListItem("..Seleccione..", "-1"));


                TipoMedidasBLL tipomedBLL = new TipoMedidasBLL();
                List<TipoMedidasBEL> tipomedBEL = tipomedBLL.traerTiposMedidas();

                ddlMedida.DataSource = tipomedBEL;
                ddlMedida.DataValueField = "Id_medida";
                ddlMedida.DataTextField = "Nombre";
                ddlMedida.DataBind();
                ddlMedida.Items.Insert(0, new ListItem("..Seleccione..", "-1"));


                TipoCultivoBLL tipoculBLL = new TipoCultivoBLL();
                List<TipoCultivoBEL> tipoculBEL = tipoculBLL.traerTiposCultivo();

                ddlCultivo.DataSource = tipoculBEL;
                ddlCultivo.DataValueField = "Id_tipo_cultivo";
                ddlCultivo.DataTextField = "Nombre";
                ddlCultivo.DataBind();
                ddlCultivo.Items.Insert(0, new ListItem("..Seleccione..", "-1"));

                if(Request.QueryString["id"] != null)
                {
                    UsuarioBEL usuario = (UsuarioBEL)Session["usuarioConectado"];
                    int rut = usuario.Rut;
                    
                    /*
                    EventoBLL evBLL = new EventoBLL();
                    EventoBEL evenBEL = evBLL.traerEventoId(Int32.Parse(Request.QueryString["id"]), Int32.Parse(separadorRut[0]));
                    lblTitulo.Text = "Editar evento";
                    idEvento.Text = evenBEL.IdEvento.ToString();
                    txtNombre.Text = evenBEL.Nombre;
                    txtDescripcion.Text = evenBEL.Descripcion;
                    string a = evenBEL.Fecha.ToShortTimeString();
                    string b = evenBEL.Fecha.ToShortDateString();
                    string c = b + " " + a;
                    //txtFecha.Text = c;
                    //ddlRecinto.SelectedItem.Value = evenBEL.IdRecinto.ToString();
                    //ddlTipoEvento.SelectedItem.Value = evenBEL.IdTipoEvento.ToString();*/
                }
            }
        }


        /// <summary>
        /// Valida la imagen sea con extencion de la variable img
        /// </summary>
        private bool validaImagen(string ruta)
        {
            bool veraz = false;
            string[] cortar = ruta.Split('.');
            string ext = cortar[cortar.Length - 1];
            string[] img = { "bmp", "gif", "png", "jpg", "jpeg" };
            foreach (var item in img)
            {
                if (item == ext.ToLower())
                {
                    veraz = true;
                }
            }
            return veraz;
        }


        /// <summary>
        /// Guarda o Modifica el Evento con los datos ingresados por el usuario
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            String strFileName, strFileSave;
            UsuarioBEL usuario = (UsuarioBEL)Session["usuarioConectado"];
            int rut = usuario.Rut;

            ProductorBEL proBEL = new ProductorBEL();
            ProductorBLL proBLL = new ProductorBLL();
            proBEL = proBLL.Productor_Sel(rut);

            ProductosBEL proBel = new ProductosBEL();

            proBel.Rut_productor = proBEL.Rut;
            proBel.Id_tipo_producto = Int32.Parse(ddlTipo.SelectedItem.Value);
            if (chkOferta.Checked)
                proBel.Oferta = 1;
            else
                proBel.Oferta = 0;
            proBel.Descripcion_elaboracion = txtDescripcion.Text;
            proBel.Id_direccion = proBEL.Id_direccionnegocio;
            proBel.Zona_cultivo = txtZona.Text;
            proBel.Stock = Convert.ToInt32(txtStock.Text);
            proBel.Precio_unitario = Convert.ToInt32(txtPrecio.Text);
            proBel.Id_medida = Int32.Parse(ddlMedida.SelectedItem.Value);
            proBel.Id_tipo_cultivo = Int32.Parse(ddlCultivo.SelectedItem.Value);
            proBel.Activo = 1;

            ProductosBLL proBll = new ProductosBLL();
            int id = proBll.agregarProductos(proBel);

            if (validaImagen(subirImagen.PostedFile.FileName))
            {
                strFileName = System.IO.Path.GetFileName(subirImagen.PostedFile.FileName);
                String strFolderSave = Server.MapPath("../img/Productos/");
                strFileSave = "/img/Productos/" + strFileName;

                ImagenesBEL imaBEL = new ImagenesBEL();
                imaBEL.Id_producto = id;
                imaBEL.Nombre = txtNombre.Text;
                imaBEL.Descripcion = txtDescripcionI.Text;
                imaBEL.Orden = Convert.ToInt32(txtOrden.Text);
                imaBEL.Fecha = DateTime.Today;
                imaBEL.Ubicacion = strFileSave;                
                subirImagen.PostedFile.SaveAs(strFolderSave + strFileName);

                ImagenesBLL imaBLL = new ImagenesBLL();
                imaBLL.agregarImagenes(imaBEL);
            } 

            /// <summary>
            /// Agrega el evento
            /// </summary>
            EventoBLL evBLL = new EventoBLL();
            if (lblTitulo.Text.Equals("Agregar evento"))
            {
                
               // int idEvento = evBLL.agregarEvento(evBEL);
                //if (idEvento == -1) return;

                /*** se Agregan Los Asientos ***/
               // this.guardarAsiento(idEvento);
                /***** Fin Agrega Asientos ******/

                /*** se Agregan Los Precios ***/
               // this.guardarPrecio(idEvento);
                /***** Fin Agrega Precios ******/
                Response.Write("<script>alert('Se agregó correctamente');window.location='Eventos.aspx';</script></script>");
            }
            /// <summary>
            /// Modifica el evento
            /// </summary>
            else
            {
               // evBEL.IdEvento = Int32.Parse(idEvento.Text);
                //evBLL.actualizarEvento(evBEL);
                Response.Write("<script>alert('Se Editó correctamente');window.location='Eventos.aspx';</script></script>");
            } 
            
        }


        /// <summary>
        /// Agraga los tipos de asientos al Evento
        /// </summary>
        private void guardarAsiento(int idEvento)
        {
            int i = 0;
            /*AsientoBLL asientoBLL = new AsientoBLL();
            if (!txtCantCancha.Text.Equals("") && Int32.Parse(txtCantCancha.Text) > 0)
            {
                for (i = 0; i <= Int32.Parse(txtCantCancha.Text); i++) //FOR PARA AGREGAR CANCHAS
                {
                    AsientoBEL asBEL = new AsientoBEL();
                    asBEL.IdEvento = idEvento;
                    asBEL.IdTipoAsiento = 1;
                    asBEL.Numero = i;
                    asientoBLL.agregarAsientos(asBEL);
                }
            }
            if (!txtCantPlatea.Text.Equals("") && Int32.Parse(txtCantPlatea.Text) > 0)
            {
                for (i = 0; i <= Int32.Parse(txtCantPlatea.Text); i++) //FOR PARA AGREGAR PLATEAS
                {
                    AsientoBEL asBEL = new AsientoBEL();
                    asBEL.IdEvento = idEvento;
                    asBEL.IdTipoAsiento = 2;
                    asBEL.Numero = i;
                    asientoBLL.agregarAsientos(asBEL);
                }
            }
            if (!txtCantGaleria.Text.Equals("") && Int32.Parse(txtCantGaleria.Text) > 0)
            {
                for (i = 0; i <= Int32.Parse(txtCantGaleria.Text); i++) //FOR PARA AGREGAR GALERIAS
                {
                    AsientoBEL asBEL = new AsientoBEL();
                    asBEL.IdEvento = idEvento;
                    asBEL.IdTipoAsiento = 4;
                    asBEL.Numero = i;
                    asientoBLL.agregarAsientos(asBEL);
                }
            }
            if (!txtCantVIP.Text.Equals("") && Int32.Parse(txtCantVIP.Text) > 0)
            {
                for (i = 0; i <= Int32.Parse(txtCantVIP.Text); i++) //FOR PARA AGREGAR VIP
                {
                    AsientoBEL asBEL = new AsientoBEL();
                    asBEL.IdEvento = idEvento;
                    asBEL.IdTipoAsiento = 3;
                    asBEL.Numero = i;
                    asientoBLL.agregarAsientos(asBEL);
                }*/
            
        }


        /// <summary>
        /// Guarda los precios de los tipos de asientos registrados
        /// </summary>
        private void guardarPrecio(int idEvento)
        {
            TiposTicketBLL tipoBLL = new TiposTicketBLL();
            TiposTicketBEL tipoBEL = new TiposTicketBEL();

           
        }

    }
}
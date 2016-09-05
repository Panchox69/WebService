using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BEL;
using BLL;

namespace Vistas.VAdm_Mantenedor
{
    public partial class AgregarRecinto : System.Web.UI.Page
    {
        ComunaBEL clicomuna = new ComunaBEL();
        RegionBEL cliregion = new RegionBEL();
        int comuna = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga los datos si se requiere actualiar o editar
            /// </summary>
            if (!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    lblTitulo.Text = "Modificar Recinto";
                    RecintoBLL recintoBLL = new RecintoBLL();
                    RecintoBEL recBEL = recintoBLL.traerRecintoPorId(Int32.Parse(Request.QueryString["id"]));
                    ClienteBLL cliBLL = new ClienteBLL();
                    txtNombre.Text = recBEL.NombreRecinto;
                    txtDireccion.Text = recBEL.DireccionRecinto;
                    idRecinto.Text = recBEL.IdRecinto.ToString();
                    lblEstado.Text = recBEL.IdEstado.ToString();
                    comuna = recBEL.IdComuna;
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
        /// Guarda los datos entregados por el usuario 
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validaImagen(subirImagen.PostedFile.FileName))
            {
                String strFileName, strFilePath, strFolderSave, strFileSave;
                strFolderSave = Server.MapPath("../img/Recintos/");
                strFileName = subirImagen.PostedFile.FileName;
                strFilePath = "/img/Recintos/";
                strFileSave = "/img/Recintos/"+strFileName;
                if (strFileName != "")
                {
                    strFileName = Path.GetFileName(strFileName);
                    strFilePath = strFolderSave + strFileName;
                    subirImagen.PostedFile.SaveAs(strFilePath);
                }
                RecintoBEL recinto = new RecintoBEL();
                recinto.DireccionRecinto = txtDireccion.Text;
                recinto.IdComuna = Int32.Parse(ddlComuna.SelectedItem.Value);
                recinto.ImagenRecinto = strFileSave;
                recinto.NombreRecinto = txtNombre.Text;

                RecintoBLL recbll = new RecintoBLL();
                if (lblTitulo.Text.CompareTo("Modificar Recinto") == 0)
                {
                    recinto.IdRecinto = Int32.Parse(idRecinto.Text);
                    recinto.IdEstado = Int32.Parse(lblEstado.Text);
                    recbll.editarRecinto(recinto);
                    Response.Write("<script>alert('Datos modificados correctamente');window.location='Recintos.aspx';</script>");
                }
                else
                {
                    recbll.agregarRecinto(recinto);
                    Response.Write("<script>alert('Se agregó correctamente');window.location='Recintos.aspx';</script>");
                    txtNombre.Text = String.Empty;
                    txtDireccion.Text = String.Empty;
                    idRecinto.Text = String.Empty;
                }
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
        /// Valida la imagen en los formatos de la variable img
        /// 
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

    }
}
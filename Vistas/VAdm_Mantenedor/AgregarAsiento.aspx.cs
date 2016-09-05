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
    public partial class AgregarAsiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Carga los datos si se requiere actualiar o editar
            /// </summary>
            if (!IsPostBack)
            {
                TipoAsientoBLL tipBLL = new TipoAsientoBLL();
                if (Request.QueryString["id"] != null)
                {
                    AsientoBLL asBLL = new AsientoBLL();
                    AsientoBEL asiento = asBLL.traerAsientoPorId(Int32.Parse(Request.QueryString["id"].ToString()));
                    idAsiento.Text = Request.QueryString["id"].ToString();
                    txtNumeroInicio.Text = asiento.Numero.ToString();
                    txtNumeroFin.Visible = false;
                    lblEstado.Text = asiento.Estado;
                    lblTitulo.Text = "Editar Asiento";
                }
                ddlTipoAsiento.DataSource = tipBLL.traerTiposAsientos();
                ddlTipoAsiento.DataValueField = "IdTipoAsiento";
                ddlTipoAsiento.DataTextField = "Nombre";
                ddlTipoAsiento.DataBind();
                ddlTipoAsiento.Items.Insert(0, new ListItem("..Seleccione..", "-1"));
            }
        }

        /// <summary>
        /// Guarda los datos entregados por el usuario 
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AsientoBLL asientoBLL = new AsientoBLL();
            int numeroInicio, numeroFin, i;
            numeroInicio = Int32.Parse(txtNumeroInicio.Text);
            numeroFin = Int32.Parse(txtNumeroFin.Text);
            String idRecinto = Session["idRecinto"].ToString();
            if (lblTitulo.Text.CompareTo("Editar Asiento") == 0)
            {
                AsientoBEL asBEL = new AsientoBEL();
                asBEL.IdAsiento =
                //asBEL.IdRecinto = Int32.Parse(idRecinto);
                asBEL.IdTipoAsiento = Int32.Parse(ddlTipoAsiento.SelectedItem.Value);
                asBEL.Numero = numeroInicio;
                asBEL.Estado = lblEstado.Text;
                asientoBLL.modificarAsiento(asBEL);
            }else
            {
                i = 0;
                for (i = numeroInicio; i <= numeroFin; i++)
                {
                    AsientoBEL asBEL = new AsientoBEL();
                    //asBEL.IdRecinto = Int32.Parse(idRecinto);
                    asBEL.IdTipoAsiento = Int32.Parse(ddlTipoAsiento.SelectedItem.Value);
                    asBEL.Numero = i;
                    asientoBLL.agregarAsientos(asBEL);
                }
                Response.Write(string.Format("<script>alert('Se agregó correctamente');window.location='asientos.aspx?id={0}';</script></script>",idRecinto));
            }
            
        }
    }
}
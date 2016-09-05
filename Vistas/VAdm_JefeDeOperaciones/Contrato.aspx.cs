using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Vistas.VAdm_JefeDeOperaciones
{
    public partial class Contrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// <summary>
                /// Carga la grilla con todos los Organizadores registrados
                /// </summary>
                OrganizadorBLL cliBLL = new OrganizadorBLL();
                grvContrato.DataSource = cliBLL.listaContrato();
                grvContrato.DataBind();
            }

        }


        /// <summary>
        /// Genera un contrato al arganizador seleccionado el la grilla
        /// </summary>
        protected void btnContrato_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Crea la carpeta si no existe para guardar los pdf generados
            /// </summary>
            OrganizadorBLL org = new OrganizadorBLL();
            if (!Directory.Exists(@"C:\PDF\"))
            {
                Directory.CreateDirectory(@"C:\PDF\");
            }


            /// <summary>
            /// Genera los pdf con iTextSharp dll y referencia ya importadas
            /// </summary>
            foreach (GridViewRow row in grvContrato.Rows)
            {
                CheckBox check = row.Cells[2].FindControl("chkGenerar") as CheckBox;
                if (check.Checked)
                {
                    int folio = Int32.Parse(row.Cells[0].Text);
                    string nombre = row.Cells[1].Text;
                    string giro = row.Cells[4].Text;
                    string rut = row.Cells[2].Text;
                    string direccion = row.Cells[3].Text;
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\PDF\" + folio + ".pdf", FileMode.Create));
                    doc.Open();
                    Paragraph paragraph = new Paragraph("Contrato  Numero de Folio: " + folio + "\n\n Sr/a " + nombre + " representante de la Empresa, Promotora o Colectivo " + giro + " RUT " + rut + " con Direccion " + direccion + " \n Los (Artistas/DJ/Productor) declaran que todos los integrantes del grupo son mayores de 16 años. Y reconociéndose ambas partes mutua capacidad legal para obligarse en cuanto en derecho fuera menester acerca del contenido del presente contrato libremente. \n PACTAN, CONVIENEN Y OTORGAN.");
                    doc.Add(paragraph);
                    doc.Close();
                    Response.Write("<script>alert('Contrato ID " + folio + " Generado'); window.location='InicioOper.aspx';</script>");
                }


            }
            //Response.Write("<script>alert('Seleccione para generar contrato')</script>");

        }



    }
}
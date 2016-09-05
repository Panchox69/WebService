using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;
using System.Text;
using System.Drawing;

namespace Vistas.VAdm_JefeDeOperaciones
{
    public partial class AdministrarOrganizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /// <summary>
                /// Carga la grilla con todos los Organizadores registrados
                /// </summary>
                OrganizadorBLL cliBLL = new OrganizadorBLL();
                OrganizadorBEL or = new OrganizadorBEL();
                grvOrganizador.DataSource = cliBLL.listaAdministrador();
                grvOrganizador.DataBind();
            }
        }


        /// <summary>
        /// Actualiza el campo autorizado y aprobado de Organizador
        /// Autorizado
        /// 1 = Habilitado
        /// 0 = Deshabilitado
        /// Aprobado
        /// v = valido
        /// n = no valido
        /// </summary>
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            OrganizadorBLL org = new OrganizadorBLL();

            foreach (GridViewRow row in grvOrganizador.Rows)
            {
                CheckBox check = row.Cells[2].FindControl("chkAprobado") as CheckBox;
                if (check.Checked)
                {
                    int inscripcion = Int32.Parse(row.Cells[1].Text);
                    org.updateAprobado(inscripcion, "v");
                }
                else
                {
                    int inscripcion = Int32.Parse(row.Cells[1].Text);
                    org.updateAprobado(inscripcion, "n");
                }

                CheckBox check1 = row.Cells[3].FindControl("chkAutorizado") as CheckBox;
                if (check1.Checked)
                {
                    int inscripcion = Int32.Parse(row.Cells[1].Text);
                    org.updateAutorizado(inscripcion, 1);
                }
                else
                {
                    int inscripcion = Int32.Parse(row.Cells[1].Text);
                    org.updateAutorizado(inscripcion, 0);
                }
            }
        }
    }
}
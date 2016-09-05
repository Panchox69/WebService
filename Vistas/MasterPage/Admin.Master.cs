using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BEL;

namespace Vistas.MasterPage
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MenuBEL> menuUsuario = (List<MenuBEL>)Session["_menu"];
            if(menuUsuario == null){
                MenuBLL menu = new MenuBLL();
                UsuarioBEL usuario = (UsuarioBEL)Session["usuarioConectado"];
                menuUsuario = menu.traerMenuPorTipoPerfil(usuario.IdTipoPerfil);
                Session["_menu"] = menuUsuario;
            }
        }
    }
}
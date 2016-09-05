using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;

namespace BLL
{
    public class MenuBLL
    {

        /// <summary>
        /// Trae todos los registros de Menu como LIST
        /// </summary>
        /// <param name="rutCli">id del tipo de perfil a filtrar</param>
        /// <returns></returns>
        public List<MenuBEL> traerMenuPorTipoPerfil(int idTipoPerfil)
        {
            List<MenuBEL> menues = (from tempMenu in ConexionBLL.getConexion().MENU
                                    where tempMenu.ID_TIPO_PERFIL == idTipoPerfil
                                    select new MenuBEL()
                                    {
                                        IdMenu = (int)tempMenu.ID_MENU,
                                        Campo = tempMenu.CAMPO,
                                        UrlInterna = tempMenu.URL_INTERNA,
                                        IdTipoPerfil = (int)tempMenu.ID_TIPO_PERFIL
                                    }).ToList();
            return menues;
        }
    }
}

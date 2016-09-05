using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;

namespace BLL
{
    public class UsuarioPerfilesBLL
    {
        public void agregarUsuarioPerfiles(UsuarioPerfilesBEL usuperBel)
        {
            try
            {
                fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
                servicio.Usuarios_Perfiles_Ins(usuperBel.Rut, usuperBel.Id_tipo_perfil);
            }
            catch
            {
                return;
            }
        }
    }
}

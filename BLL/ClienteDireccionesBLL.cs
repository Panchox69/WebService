using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;

namespace BLL
{
    public class ClienteDireccionesBLL
    {
        public void agregarUsuarioDirecciones(ClienteDireccionesBEL clidirBel)
        {
            try
            {
                fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
                servicio.Cliente_Direcciones_Ins(clidirBel.Rut_cliente, clidirBel.Id_direccion, clidirBel.Primaria);
            }
            catch
            {
                return;
            }
        }
    }
}

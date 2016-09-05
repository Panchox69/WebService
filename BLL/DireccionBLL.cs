using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;

namespace BLL
{
    public class DireccionBLL
    {
        public int agregarDireccion(DireccionBEL dirBel)
        {            
                fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
                int id = servicio.Direccion_Ins(dirBel.Nombre, dirBel.Numero, dirBel.Id_comuna,0,0);
                return id;            
        }
    }
}

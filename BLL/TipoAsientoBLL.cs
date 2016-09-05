using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class TipoAsientoBLL
    {

        /// <summary>
        /// Trae todos los registros de Tipos de Asientos como LIST
        /// </summary>
        /// <returns></returns>
        public List<TipoAsientoBEL> traerTiposAsientos()
        {
            try
            {
                List<TipoAsientoBEL> listaTipoAsientos = (from tmpTipoAsiento in ConexionBLL.getConexion().TIPO_ASIENTO
                                                          select new TipoAsientoBEL()
                                                          {
                                                              IdTipoAsiento = (int)tmpTipoAsiento.ID_TIPO_ASIENTO,
                                                              Nombre = tmpTipoAsiento.NOMBRE
                                                          }).ToList();
                return listaTipoAsientos;
            }
            catch
            {
                return null;
            }
        }
    }
}

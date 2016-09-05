using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;
using System.Data;

namespace BLL
{
    public class ComunaBLL
    {


        public List<ComunaBEL> traerComunasPorRegion1(int idReg)
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet ds = servicio.Comunas_Sel(idReg,0);


            List<ComunaBEL> list = new List<ComunaBEL>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ComunaBEL obj = new ComunaBEL();
                //(r.Field<int>("id_region"), r.Field<string>("nombre"));
                obj.IdComuna = Convert.ToInt32(r["id_comuna"]);
                obj.Nombre = r["nombre"].ToString();
                 list.Add(obj);
            }

            return list;

        }



        /// <summary>
        /// Trae todos los registros de Comunas como LIST
        /// </summary>
        /// <param name="idReg">id de la region a filtrar</param>
        /// <returns></returns>
        public List<ComunaBEL> traerComunasPorRegion(int idReg)
        {
            try
            {
                List<ComunaBEL> comunas = (from tempComuna in ConexionBLL.getConexion().COMUNA
                                           where tempComuna.ID_REGION == idReg
                                           select new ComunaBEL()
                                           {
                                               IdComuna = (int)tempComuna.ID_COMUNA,
                                               Nombre = tempComuna.NOMBRE,
                                               IdRegion = (int)tempComuna.ID_REGION
                                           }).ToList();
                return comunas;
            }
            catch
            {
                return null;
            }
        }
    }
}

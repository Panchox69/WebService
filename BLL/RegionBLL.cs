using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;
using System.Data;

namespace BLL
{
    public class RegionBLL
    {
        public List<RegionBEL> traerRegiones1()
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet ds = servicio.Regiones_Sel_All();


            List<RegionBEL> list = new List<RegionBEL>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                RegionBEL obj = new RegionBEL();
                //(r.Field<int>("id_region"), r.Field<string>("nombre"));
                obj.IdRegion = Convert.ToInt32(r["id_region"]);
                obj.Nombre = r["nombre"].ToString();
                 list.Add(obj);
            }

            return list;

        }

        /// <summary>
        /// Trae todos los registros de Regiones como LIST
        /// </summary>
        /// <returns></returns>
        public List<RegionBEL> traerRegiones()
        {
            try
            {
                int count = (from tmpRegion in ConexionBLL.getConexion().REGION
                             select tmpRegion).Count();
                List<RegionBEL> regionesBEL = (from tmpRegion in ConexionBLL.ConexionETicket.REGION
                                               select new RegionBEL()
                                               {
                                                   IdRegion = (int)tmpRegion.ID_REGION,
                                                   Nombre = tmpRegion.NOMBRE
                                               }).ToList();
                return regionesBEL;
            }
            catch
            {
                return null;
            }
        }
    }
}

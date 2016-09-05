using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data;

namespace BLL
{
    public class TipoMedidasBLL
    {

        public List<TipoMedidasBEL> traerTiposMedidas()
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet ds = servicio.Tipo_Medida_Sel_All();

            List<TipoMedidasBEL> list = new List<TipoMedidasBEL>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                TipoMedidasBEL obj = new TipoMedidasBEL();
                obj.Id_medida = Convert.ToInt32(r["id_medida"]);
                obj.Nombre = r["nombre"].ToString();
                list.Add(obj);
            }

            return list;

        }
    }
}

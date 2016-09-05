using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data;

namespace BLL
{
    public class TipoCultivoBLL
    {
        public List<TipoCultivoBEL> traerTiposCultivo()
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet ds = servicio.Tipo_Cultivo_Sel_All();

            List<TipoCultivoBEL> list = new List<TipoCultivoBEL>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                TipoCultivoBEL obj = new TipoCultivoBEL();
                obj.Id_tipo_cultivo = Convert.ToInt32(r["id_tipo_cultivo"]);
                obj.Nombre = r["nombre"].ToString();
                list.Add(obj);
            }

            return list;

        }
    }
}

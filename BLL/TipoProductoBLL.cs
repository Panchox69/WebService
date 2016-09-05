using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data;

namespace BLL
{
    public class TipoProductoBLL
    {

        public List<TipoProductoBEL> traerTiposProductos()
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet ds = servicio.Tipo_Producto_Sel_All();

            List<TipoProductoBEL> list = new List<TipoProductoBEL>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                TipoProductoBEL obj = new TipoProductoBEL();
                obj.Id_tipo_producto = Convert.ToInt32(r["id_tipo_producto"]);
                obj.Nombre = r["nombre"].ToString();
                list.Add(obj);
            }

            return list;

        }


    }
}

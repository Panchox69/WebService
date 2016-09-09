using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data;

namespace BLL
{
    public class ImagenesBLL
    {
        public void agregarImagenes(ImagenesBEL imaBel)
        {
            try
            {
                fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
                servicio.Imagenes_Ins(imaBel.Id_producto, imaBel.Nombre, imaBel.Descripcion, imaBel.Orden, imaBel.Fecha, imaBel.Ubicacion);
            }
            catch
            {
                return;
            }
        }

        public List<ImagenesBEL> Imagenes_Sel_All()
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet ds = servicio.Imagenes_Sel_All();

            List<ImagenesBEL> list = new List<ImagenesBEL>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ImagenesBEL obj = new ImagenesBEL();
                obj.Id_producto = Convert.ToInt32(r["id_producto"]);
                obj.Nombre = r["nombre"].ToString();
                obj.Descripcion = r["descripcion"].ToString();
                obj.Orden = Convert.ToInt32(r["orden"]);
                obj.Fecha = Convert.ToDateTime(r["fecha"]);
                obj.Ubicacion = r["ubicacion"].ToString();
                list.Add(obj);
            }
            return list;
        }

    }
}

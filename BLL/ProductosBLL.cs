using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data;

namespace BLL
{
    public class ProductosBLL
    {
        public int agregarProductos(ProductosBEL proBel)
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            int id = servicio.Productos_Ins(proBel.Rut_productor, proBel.Id_tipo_producto, proBel.Oferta, proBel.Descripcion_elaboracion, proBel.Id_direccion, proBel.Zona_cultivo, proBel.Stock, proBel.Precio_unitario, proBel.Id_medida, proBel.Id_tipo_cultivo, proBel.Activo);
            return id;
        }

        public List<ProductosBEL> Productos_Sel_All()
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet ds = servicio.Productos_Sel_All();
            DataSet sd = servicio.Imagenes_Sel_All();

            DataTable tbl1 = ds.Tables[0];
            DataTable tbl2 = sd.Tables[0];

            //List<ProductosBEL> list = new List<ProductosBEL>();


          /*

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ProductosBEL obj = new ProductosBEL();
                obj.Id_producto = Convert.ToInt32(r["id_producto"]);
                obj.Rut_productor = Convert.ToInt32(r["rut_productor"]);
                obj.Id_tipo_producto = Convert.ToInt32(r["id_tipo_producto"]);
                obj.Oferta = Convert.ToInt32(r["oferta"]);
                obj.Descripcion_elaboracion = r["descripcion_elaboracion"].ToString();
                obj.Id_direccion = Convert.ToInt32(r["id_direccion"]);
                obj.Zona_cultivo = r["zona_cultivo"].ToString();
                obj.Stock = Convert.ToInt32(r["stock"]);
                obj.Precio_unitario = Convert.ToInt32(r["precio_unitario"]);
                obj.Id_medida = Convert.ToInt32(r["id_medida"]);
                obj.Id_tipo_cultivo = Convert.ToInt32(r["id_tipo_cultivo"]);
                obj.Activo = Convert.ToInt32(r["activo"]);

                
                list.Add(obj);
            }*/

            List<ProductosBEL> productos =  (from table1 in tbl1.AsEnumerable()
                                             join table2 in tbl2.AsEnumerable()
                                            //on table1.Field<Int32>("id_producto") equals
                                            on table1.Field<Decimal>("ID_PRODUCTO") equals
                                            table2.Field<Decimal>("ID_PRODUCTO")
                                             select new ProductosBEL()
                                             {
                                                 Id_producto = Convert.ToInt32(table1.Field<Decimal>("id_producto")),
                                                 /*Rut_productor = table1.Field<Decimal>("rut_productor"),
                                                 Id_tipo_producto = table1.Field<Decimal>("id_tipo_producto"),
                                                 Oferta = table1.Field<Decimal>("oferta"),
                                                 Descripcion_elaboracion = table1.Field<String>("descripcion_elaboracion"),
                                                 Id_direccion = table1.Field<Decimal>("id_direccion"),
                                                 Zona_cultivo = table1.Field<String>("zona_cultivo"),
                                                 Stock = table1.Field<Decimal>("stock"),
                                                 Precio_unitario = table1.Field<Decimal>("precio_unitario"),
                                                 Id_medida = table1.Field<Decimal>("id_medida"),
                                                 Id_tipo_cultivo = table1.Field<Decimal>("id_tipo_cultivo"),
                                                 Activo = table1.Field<Decimal>("activo"),*/
                                                 Ubicacion = table2.Field<String>("Ubicacion")
                                             }).ToList();
            return productos;

            //return list;
        }
    }
}

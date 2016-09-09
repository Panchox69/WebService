using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data;

namespace BLL
{
    public class ProductorBLL
    {
        public void registroProductor(ProductorBEL productor)
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            servicio.Productor_Ins(productor.Rut, productor.Dv, productor.Nombre, productor.Apellido, productor.Sexo, productor.Id_direccionparticular, productor.Celular, productor.Correo, productor.Id_direccionnegocio, productor.Mismadireccion);
        }

        public ProductorBEL Productor_Sel(int rut)
        {
            try
            {
                fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
                DataSet custDS = new DataSet();
                custDS = servicio.Productor_Sel(rut);

                if (custDS.Tables["PRODUCTORES"].Rows.Count > 0)
                {
                    ProductorBEL productor_enc = new ProductorBEL();
                    productor_enc.Rut = Convert.ToInt32(custDS.Tables["PRODUCTORES"].Rows[0]["rut"].ToString());
                    productor_enc.Dv = Convert.ToChar(custDS.Tables["PRODUCTORES"].Rows[0]["dv"].ToString());
                    productor_enc.Nombre = custDS.Tables["PRODUCTORES"].Rows[0]["nombre"].ToString();
                    productor_enc.Apellido = custDS.Tables["PRODUCTORES"].Rows[0]["apellido"].ToString();
                    productor_enc.Sexo = Convert.ToChar(custDS.Tables["PRODUCTORES"].Rows[0]["sexo"].ToString());
                    productor_enc.Id_direccionparticular = Convert.ToInt32(custDS.Tables["PRODUCTORES"].Rows[0]["id_direccionparticular"]);
                    productor_enc.Celular = Convert.ToInt32(custDS.Tables["PRODUCTORES"].Rows[0]["telefono"]);
                    productor_enc.Correo = custDS.Tables["PRODUCTORES"].Rows[0]["correo"].ToString();
                    productor_enc.Id_direccionnegocio = Convert.ToInt32(custDS.Tables["PRODUCTORES"].Rows[0]["id_direccionnegocio"]);
                    productor_enc.Mismadireccion = Convert.ToInt32(custDS.Tables["PRODUCTORES"].Rows[0]["mismadireccion"]);
                    return productor_enc;
                }
                return null;
            }
                catch
            {
                return null;
                }
            }
        

    }
}

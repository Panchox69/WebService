using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using System.Data;

namespace BLL
{
    public class ProductorHabilitadoBLL
    {
        public ProductorHabilitadoBEL Productor_Habilitados_Sel(int rut)
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            DataSet custDS = servicio.Productores_Hab_Sel(rut);

            if (custDS.Tables["Productores_Hab"].Rows.Count > 0)
            {
                ProductorHabilitadoBEL prodhabBEL = new ProductorHabilitadoBEL();
                prodhabBEL.Rut = Convert.ToInt32(custDS.Tables["Productores_Hab"].Rows[0]["rut"].ToString());
                prodhabBEL.Dv = Convert.ToChar(custDS.Tables["Productores_Hab"].Rows[0]["dv"].ToString());
                prodhabBEL.Nombre = custDS.Tables["Productores_Hab"].Rows[0]["nombre"].ToString();
                prodhabBEL.Apellido = custDS.Tables["Productores_Hab"].Rows[0]["apellido"].ToString();
                prodhabBEL.Fecha = Convert.ToDateTime(custDS.Tables["Productores_Hab"].Rows[0]["fecha"].ToString());
                return prodhabBEL;
            }
            else
                return null;

        }
    }
}

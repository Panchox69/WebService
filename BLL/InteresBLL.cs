using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;
using System.Web.UI.WebControls;

namespace BLL
{
    public class InteresBLL
    {

        /// <summary>
        /// Trae todos los registros de Intereses como LIST
        /// </summary>
        /// <returns></returns>
        public List<InteresBEL> traerIntereses()
        {
            try
            {
                List<InteresBEL> intereses = (from tempint in ConexionBLL.getConexion().INTERES
                                              select new InteresBEL()
                                              {
                                                  IdInteres = (int)tempint.ID_INTERES,
                                                  Descripcion = tempint.DESCRIPCION
                                              }).ToList();
                return intereses;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Agrega un nuevo registro de los intereses del Cliente u Organizador
        /// </summary>
        /// <param name="rutCli", name="listaInteres">rut del cliente u organizador, lista de intereses seleccionados en el registro</param>
        public void VincularInteresCliente(int rutCli,List<Int32> listaInteres)
        {
            Entidades conexion = ConexionBLL.getConexion();
            CLIENTE_INTERES cliInt = null;
            try
            {
                foreach (int interes in listaInteres)
                {
                    cliInt = new CLIENTE_INTERES();
                    cliInt.CLIENTE_RUT = rutCli;
                    cliInt.INTERES_ID_INTERES = interes;
                    ConexionBLL.ConexionETicket.AddToCLIENTE_INTERES(cliInt);
                }

                conexion.SaveChanges();
                conexion.Dispose();
            }
            catch
            {
                return;
            }
            //falta asignarlo solamente
        }
    }
}

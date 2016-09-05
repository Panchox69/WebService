using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class AsientoBLL
    {

        /// <summary>
        /// Trae todos los registros de Asientos con estado A como LIST
        /// A = Activo
        /// I = Inactivo
        /// </summary>
        /// <returns></returns>
        public List<AsientoBEL> traerAsientos()
        {
            try
            {
                List<AsientoBEL> listaAsientos = (from tmpAsientos in ConexionBLL.getConexion().ASIENTO
                                                  where tmpAsientos.ESTADO.Equals("A")
                                                  select new AsientoBEL()
                                                  {
                                                      IdAsiento = (int)tmpAsientos.ID_ASIENTO,
                                                      Numero = (int)tmpAsientos.NUMERO,
                                                      Estado = tmpAsientos.ESTADO,
                                                      IdEvento = (int)tmpAsientos.ID_EVENTO,
                                                      IdTipoAsiento = (int)tmpAsientos.ID_TIPO_ASIENTO
                                                  }).ToList();
                return listaAsientos;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Asientos con estado A de un evento en particular como LIST
        /// A = Activo
        /// I = Inactivo
        /// </summary>
        /// <param name="idEvento">id del Evento a Filtrar</param>
        /// <returns></returns>
        public List<AsientoBEL> traerAsientos(int idEvento)
        {
            try
            {
                List<AsientoBEL> listaAsientos = (from tmpAsientos in ConexionBLL.getConexion().ASIENTO
                                                  where tmpAsientos.ESTADO.Equals("A") && tmpAsientos.ID_EVENTO == idEvento
                                                  select new AsientoBEL()
                                                  {
                                                      IdAsiento = (int)tmpAsientos.ID_ASIENTO,
                                                      Numero = (int)tmpAsientos.NUMERO,
                                                      Estado = tmpAsientos.ESTADO,
                                                      IdEvento = (int)tmpAsientos.ID_EVENTO,
                                                      IdTipoAsiento = (int)tmpAsientos.ID_TIPO_ASIENTO
                                                  }).ToList();
                return listaAsientos;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae todos los registros de Asientos con estado A de un evento en particular y de un tipo de asiento como LIST
        /// Estado Asiento
        /// A = Activo
        /// I = Inactivo
        /// Tipo de Asiento
        /// 1 = Cancha
        /// 2 = Platea
        /// 3 = Vip
        /// 4 = Galeria
        /// </summary>
        /// <param name="idEvento" , "idTipoAsiento">id del Evento a Filtrar, id del tipo de asiento a filtrar</param>
        /// <returns></returns>

        public List<AsientoBEL> traerAsientos(int idEvento, int idTipoAsiento)
        {
            try
            {
                List<AsientoBEL> listaAsientos = (from tmpAsientos in ConexionBLL.getConexion().ASIENTO
                                                  where tmpAsientos.ESTADO.Equals("A") && tmpAsientos.ID_EVENTO == idEvento && tmpAsientos.ID_TIPO_ASIENTO == idTipoAsiento
                                                  select new AsientoBEL()
                                                  {
                                                      IdAsiento = (int)tmpAsientos.ID_ASIENTO,
                                                      Numero = (int)tmpAsientos.NUMERO,
                                                      Estado = tmpAsientos.ESTADO,
                                                      IdEvento = (int)tmpAsientos.ID_EVENTO,
                                                      IdTipoAsiento = (int)tmpAsientos.ID_TIPO_ASIENTO
                                                  }).ToList();
                return listaAsientos;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Agrega un nuevo registro de Asiento
        /// </summary>
        /// <param name="asiento">Objeto Asiento</param>       
        public void agregarAsientos(AsientoBEL asiento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ASIENTO asientoDALC = new ASIENTO();
                asientoDALC.NUMERO = asiento.Numero;
                asientoDALC.ESTADO = "A";
                asientoDALC.ID_EVENTO = asiento.IdEvento;
                asientoDALC.ID_TIPO_ASIENTO = asiento.IdTipoAsiento;

                conexion.AddToASIENTO(asientoDALC);
                conexion.SaveChanges();
                conexion.Dispose();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Modifica un registro de Asiento
        /// </summary>
        /// <param name="asiento">Objeto Asiento</param>
        public void modificarAsiento(AsientoBEL asiento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ASIENTO asientoDALC = (from tmpAsiento in conexion.ASIENTO
                                       where tmpAsiento.ID_EVENTO == asiento.IdEvento
                                       select tmpAsiento).FirstOrDefault();
                asientoDALC.NUMERO = asiento.Numero;
                asientoDALC.ID_ASIENTO = asiento.IdAsiento;
                asientoDALC.ID_EVENTO = asiento.IdEvento;
                asientoDALC.ID_TIPO_ASIENTO = asiento.IdTipoAsiento;
                asientoDALC.ESTADO = asiento.Estado;

                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Elimina un registro de Asiento
        /// </summary>
        /// <param name="asiento">Objeto Asiento</param>
        public void eliminarAsiento(int idEvento) 
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ASIENTO asientoDALC = (from tmpAsiento in conexion.ASIENTO
                                       where tmpAsiento.ID_EVENTO == idEvento
                                       select tmpAsiento).FirstOrDefault();
                conexion.DeleteObject(asientoDALC);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Trae un Asiento de un evento en particular como objeto Asiento
        /// </summary>
        /// <param name="idEvento">id del Evento a Filtrar</param>
        /// <returns></returns>
        public AsientoBEL traerAsientoPorId(int idEvento)
        {
            try
            {
                ASIENTO asiDalc = (from tmpAsiento in ConexionBLL.getConexion().ASIENTO
                                   where tmpAsiento.ID_EVENTO == idEvento
                                   select tmpAsiento).FirstOrDefault();
                if(asiDalc != null){
                    AsientoBEL asientoBEL = new AsientoBEL();
                    asientoBEL.IdAsiento = (int)asiDalc.ID_ASIENTO;
                    asientoBEL.Numero = (int)asiDalc.NUMERO;
                    asientoBEL.Estado = asiDalc.ESTADO;
                    asientoBEL.IdEvento = (int)asiDalc.ID_EVENTO;
                    asientoBEL.IdTipoAsiento = (int)asiDalc.ID_TIPO_ASIENTO;

                    return asientoBEL;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class TipoEventoBLL
    {

        /// <summary>
        /// Agrega un nuevo registro de Tipo de Evento
        /// </summary>
        /// <param name="tipoEvento">Objeto TipoEvento</param>
        public void agregarTipoEvento(TipoEventoBEL tipoEvento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                TIPO_EVENTO tipoEventoDALC = new TIPO_EVENTO();
                tipoEventoDALC.DESCRIPCION = tipoEvento.DescripcionTipoEvento;
                //tipoEventoDALC.ID_TIPO_EVENTO = tipoEvento.IdTipoEvento;
                conexion.AddToTIPO_EVENTO(tipoEventoDALC);
                conexion.SaveChanges();
                conexion.Dispose();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Elimina un registro de Tipo de Evento
        /// </summary>
        /// <param name="id">id del tipo de evento</param>
        public void eliminarTipoEvento(int id)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                TIPO_EVENTO tipoEventoDALC = (from tmpTipoEvento in conexion.TIPO_EVENTO where tmpTipoEvento.ID_TIPO_EVENTO == id select tmpTipoEvento).FirstOrDefault();
                tipoEventoDALC.ID_TIPO_EVENTO = id;
                conexion.DeleteObject(tipoEventoDALC);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Modifica un registro de Tipo de Evento
        /// </summary>
        /// <param name="tipoEvento">Objeto TipoEvento</param>
        public void editarTipoEvento(TipoEventoBEL tipoEvento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                TIPO_EVENTO tipoEventoDALC = (from tmpTipoEvento in conexion.TIPO_EVENTO where tmpTipoEvento.ID_TIPO_EVENTO == tipoEvento.IdTipoEvento select tmpTipoEvento).FirstOrDefault();
                tipoEventoDALC.ID_TIPO_EVENTO = tipoEvento.IdTipoEvento;
                tipoEventoDALC.DESCRIPCION = tipoEvento.DescripcionTipoEvento;
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Trae todos los registros de Tipos de Eventos como LIST
        /// </summary>        
        /// <returns></returns>
        public List<TipoEventoBEL> listaDeTiposEventos()
        {
            try
            {
                List<TipoEventoBEL> lista = (from tmpTiposEvento in ConexionBLL.getConexion().TIPO_EVENTO
                                             select new TipoEventoBEL()
                                             {
                                                 IdTipoEvento = (int)tmpTiposEvento.ID_TIPO_EVENTO,
                                                 DescripcionTipoEvento = tmpTiposEvento.DESCRIPCION
                                             }).ToList();
                return lista;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae el registro de Tipos de Eventos como LIST
        /// </summary>
        /// <param name="id">id del tipo de evento a Filtrar</param>
        /// <returns></returns>
        public TipoEventoBEL taerEnventoPorId(int id)
        {
            try
            {
                TIPO_EVENTO evenDalc = (from tmpevento in ConexionBLL.getConexion().TIPO_EVENTO
                                        where tmpevento.ID_TIPO_EVENTO == id
                                        select tmpevento).FirstOrDefault();
                if (evenDalc != null)
                {
                    TipoEventoBEL tipo = new TipoEventoBEL();
                    tipo.IdTipoEvento = (int)evenDalc.ID_TIPO_EVENTO;
                    tipo.DescripcionTipoEvento = evenDalc.DESCRIPCION;
                    return tipo;
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

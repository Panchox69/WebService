using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class RecintoBLL
    {

        /// <summary>
        /// Agrega un nuevo registro de Recinto
        /// </summary>
        /// <param name="recinto">Objeto Recinto</param>
        public void agregarRecinto(RecintoBEL recinto)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                RECINTO recintoDALC = new RECINTO();
                recintoDALC.ID_COMUNA = recinto.IdComuna;
                //recintoDALC.ID_RECINTO = recinto.IdRecinto;
                recintoDALC.IMAGEN_RECINTO = recinto.ImagenRecinto;
                recintoDALC.NOMBRE_RECINTO = recinto.NombreRecinto;
                recintoDALC.DIRECCION_RECINTO = recinto.DireccionRecinto;

                conexion.AddToRECINTO(recintoDALC);
                conexion.SaveChanges();
                conexion.Dispose();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Modifica un registro de Recinto
        /// </summary>
        /// <param name="recinto">Objeto Recinto</param>
        public void editarRecinto(RecintoBEL recinto)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                RECINTO recintoDALC = (from tmpRec in conexion.RECINTO where tmpRec.ID_RECINTO == recinto.IdRecinto select tmpRec).FirstOrDefault();
                recintoDALC.ID_COMUNA = recinto.IdComuna;
                recintoDALC.ID_RECINTO = recinto.IdRecinto;
                recintoDALC.IMAGEN_RECINTO = recinto.ImagenRecinto;
                recintoDALC.NOMBRE_RECINTO = recinto.NombreRecinto;
                recintoDALC.DIRECCION_RECINTO = recinto.DireccionRecinto;
                recintoDALC.ESTADO= recinto.IdEstado;

                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Elimina un registro de Recinto
        /// </summary>
        /// <param name="recinto">Objeto Recinto</param>
        public void eliminarRecinto(int idRecinto)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                RECINTO recintoDALC = (from tmpRec in conexion.RECINTO where tmpRec.ID_RECINTO == idRecinto select tmpRec).FirstOrDefault();
                recintoDALC.ID_RECINTO = idRecinto;
                conexion.DeleteObject(recintoDALC);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Trae el registro de Recinto como objeto Recinto
        /// </summary>
        /// <param name="id">id del recinto a Filtrar</param>
        /// <returns></returns>
        public RecintoBEL traerRecintoPorId(int id)
        {
            try
            {
                RECINTO recintoDalc = ConexionBLL.getConexion().RECINTO.FirstOrDefault(tmpRecinto => (tmpRecinto.ID_RECINTO.Equals(id)));

                if(recintoDalc != null){
                    RecintoBEL recintoBEL = new RecintoBEL();
                    recintoBEL.IdRecinto = (int)recintoDalc.ID_RECINTO;
                    recintoBEL.NombreRecinto = recintoDalc.NOMBRE_RECINTO;
                    recintoBEL.DireccionRecinto = recintoDalc.DIRECCION_RECINTO;
                    recintoBEL.ImagenRecinto = recintoDalc.IMAGEN_RECINTO;
                    recintoBEL.IdComuna = (int)recintoDalc.ID_COMUNA;
                    recintoBEL.IdEstado = (int)recintoDalc.ESTADO;

                    return recintoBEL;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae todos los registros de Recintos como LIST
        /// </summary>
        /// <returns></returns>
        public List<RecintoBEL> traerRecintos()
        {
            try
            {
                List<RecintoBEL> recintos = (from tmpRec in ConexionBLL.getConexion().RECINTO
                                             select new RecintoBEL()
                                             {
                                                 IdRecinto = (int)tmpRec.ID_RECINTO,
                                                 IdComuna = (int)tmpRec.ID_COMUNA,
                                                 NombreRecinto = tmpRec.NOMBRE_RECINTO,
                                                 DireccionRecinto = tmpRec.DIRECCION_RECINTO,
                                                 ImagenRecinto = tmpRec.IMAGEN_RECINTO,
                                                 IdEstado = (int)tmpRec.ESTADO
                                             }).ToList();
                return recintos;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae todos los registros de Recintos como LIST
        /// </summary>
        /// <param name="recinto">nombre del recinto a Filtrar</param>
        /// <returns></returns>
        public List<RecintoBEL> buscarRecintos(String recinto)
        {
            try
            {
                List<RecintoBEL> recintos = (from tmpRec in ConexionBLL.getConexion().RECINTO
                                             where tmpRec.NOMBRE_RECINTO == recinto
                                             select new RecintoBEL()
                                             {
                                                 IdRecinto = (int)tmpRec.ID_RECINTO,
                                                 IdComuna = (int)tmpRec.ID_COMUNA,
                                                 NombreRecinto = tmpRec.NOMBRE_RECINTO,
                                                 DireccionRecinto = tmpRec.DIRECCION_RECINTO,
                                                 ImagenRecinto = tmpRec.IMAGEN_RECINTO,
                                                 IdEstado = (int)tmpRec.ESTADO
                                             }).ToList();
                return recintos;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Recintos como LIST
        /// 1 = Habilitado
        /// 0 = No Habilitado
        /// </summary>
        /// <param name="estado">estado del recinto a Filtrar</param>
        /// <returns></returns>
        public List<RecintoBEL> filtrarRecintos(int estado)
        {
            try
            {
                List<RecintoBEL> recintos = (from tmpRec in ConexionBLL.getConexion().RECINTO
                                             where tmpRec.ESTADO == estado
                                             select new RecintoBEL()
                                             {
                                                 IdRecinto = (int)tmpRec.ID_RECINTO,
                                                 IdComuna = (int)tmpRec.ID_COMUNA,
                                                 NombreRecinto = tmpRec.NOMBRE_RECINTO,
                                                 DireccionRecinto = tmpRec.DIRECCION_RECINTO,
                                                 IdEstado = (int)tmpRec.ESTADO,
                                                 ImagenRecinto = tmpRec.IMAGEN_RECINTO
                                             }).ToList();
                return recintos;
            }
            catch
            {
                return null;
            }
        }

    }
}

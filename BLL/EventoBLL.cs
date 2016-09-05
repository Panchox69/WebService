using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class EventoBLL
    {
        /// <summary>
        /// Trae todos los registros de Eventos como LIST
        /// </summary>
        /// <param name="Fecha">fecha del evento a Filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> buscarEventos(DateTime Fecha)
        {
            try
            {
                List<EventoBEL> even = (from tmpEvento in ConexionBLL.getConexion().EVENTO
                                        where tmpEvento.FECHA.Value.Year == Fecha.Year && tmpEvento.FECHA.Value.Month == Fecha.Month && tmpEvento.FECHA.Value.Day == Fecha.Day
                                        select new EventoBEL()
                                        {
                                            IdEvento = (int)(tmpEvento.ID_EVENTO),
                                            Nombre = tmpEvento.NOMBRE,
                                            Descripcion = tmpEvento.DESCRIPCION,
                                            Imagen = tmpEvento.IMAGEN

                                        }).ToList();
                return even;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Eventos como LIST
        /// </summary>
        /// <param name="rut">run del organizador a Filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> traerEventos(int rut)
        {
            try
            {
                List<EventoBEL> Eventos = (from tempEvento in ConexionBLL.getConexion().EVENTO
                                           where tempEvento.RUT == rut
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tempEvento.ID_EVENTO,
                                               AsientosDisponibles = (int)tempEvento.ASIENTOS_DISPONIBLES,
                                               Descripcion = tempEvento.DESCRIPCION,
                                               IdTipoEvento = (int)tempEvento.ID_TIPO_EVENTO,
                                               IdRecinto = (int)tempEvento.ID_RECINTO,
                                               Rut = (int)tempEvento.RUT,
                                               Estado = tempEvento.ESTADO,
                                               Nombre = tempEvento.NOMBRE,
                                               Fecha = tempEvento.FECHA.Value,
                                               Imagen = tempEvento.IMAGEN

                                           }).ToList();
                return Eventos;

            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae todos los registros de Eventos con estado valido V y que su fecha sea mayo o igual al dia de hoy como LIST 
        /// </summary>
        /// <returns></returns>
        public List<EventoBEL> traerEventosCercanos()
        {
            try
            {
                List<EventoBEL> Eventos = (from tempEvento in ConexionBLL.getConexion().EVENTO
                                           where tempEvento.ESTADO.Equals("V") && tempEvento.FECHA.Value >= DateTime.Today
                                           orderby tempEvento.FECHA ascending
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tempEvento.ID_EVENTO,
                                               AsientosDisponibles = (int)tempEvento.ASIENTOS_DISPONIBLES,
                                               Descripcion = tempEvento.DESCRIPCION,
                                               IdTipoEvento = (int)tempEvento.ID_TIPO_EVENTO,
                                               IdRecinto = (int)tempEvento.ID_RECINTO,
                                               Rut = (int)tempEvento.RUT,
                                               Estado = tempEvento.ESTADO,
                                               Nombre = tempEvento.NOMBRE,
                                               Fecha = tempEvento.FECHA.Value,
                                               Imagen = tempEvento.IMAGEN

                                           }).Take(10).ToList();
                return Eventos;

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Eventos con estado proximo P y que su fecha sea mayo o igual al dia de hoy como LIST 
        /// </summary>
        /// <returns></returns>
        public List<EventoBEL> traerEventosProximos()
        {
            try
            {
                List<EventoBEL> Eventos = (from tempEvento in ConexionBLL.getConexion().EVENTO
                                           where tempEvento.ESTADO.Equals("P") && tempEvento.FECHA.Value >= DateTime.Today
                                           orderby tempEvento.FECHA ascending
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tempEvento.ID_EVENTO,
                                               AsientosDisponibles = (int)tempEvento.ASIENTOS_DISPONIBLES,
                                               Descripcion = tempEvento.DESCRIPCION,
                                               IdTipoEvento = (int)tempEvento.ID_TIPO_EVENTO,
                                               IdRecinto = (int)tempEvento.ID_RECINTO,
                                               Rut = (int)tempEvento.RUT,
                                               Estado = tempEvento.ESTADO,
                                               Nombre = tempEvento.NOMBRE,
                                               Fecha = tempEvento.FECHA.Value,
                                               Imagen = tempEvento.IMAGEN

                                           }).Take(10).ToList();
                return Eventos;

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Evento como LIST 
        /// </summary>
        /// <returns></returns>
        public List<EventoBEL> traerEventos()
        {
            try
            {
                List<EventoBEL> Eventos = (from tempEvento in ConexionBLL.getConexion().EVENTO
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tempEvento.ID_EVENTO,
                                               AsientosDisponibles = (int)tempEvento.ASIENTOS_DISPONIBLES,
                                               Descripcion = tempEvento.DESCRIPCION,
                                               IdTipoEvento = (int)tempEvento.ID_TIPO_EVENTO,
                                               IdRecinto = (int)tempEvento.ID_RECINTO,
                                               Rut = (int)tempEvento.RUT,
                                               Estado = tempEvento.ESTADO,
                                               Nombre = tempEvento.NOMBRE,
                                               Fecha = tempEvento.FECHA.Value,
                                               Imagen = tempEvento.IMAGEN

                                           }).ToList();
                return Eventos;

            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Agrega un evento en la base de datos
        /// </summary>
        /// <param name="Evento">objeto Evento</param>
        /// <returns></returns>
        public int agregarEvento(EventoBEL Evento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                EVENTO eventoDALC = new EVENTO();
                eventoDALC.ASIENTOS_DISPONIBLES = Evento.AsientosDisponibles;
                eventoDALC.DESCRIPCION = Evento.Descripcion;
                eventoDALC.ID_TIPO_EVENTO = Evento.IdTipoEvento;
                eventoDALC.ID_RECINTO = Evento.IdRecinto;
                eventoDALC.RUT = Evento.Rut;
                eventoDALC.ESTADO = Evento.Estado;
                eventoDALC.NOMBRE = Evento.Nombre;
                eventoDALC.IMAGEN = Evento.Imagen;
                eventoDALC.FECHA = Evento.Fecha;
                conexion.AddToEVENTO(eventoDALC);
                conexion.SaveChanges();
                conexion.Dispose();

                EventoBEL guardado = traerEventoPorNombreRut(Evento.Nombre, Evento.Rut);
                return guardado.IdEvento;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Actualiza un evento en la base de datos
        /// </summary>
        /// <param name="Evento">objeto Evento</param>
        /// <returns></returns>
        public void actualizarEvento(EventoBEL Evento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                EVENTO eventoDALC = (from tmpEvento in conexion.EVENTO
                                     where tmpEvento.ID_EVENTO == Evento.IdEvento
                                     select tmpEvento).FirstOrDefault();

                eventoDALC.ID_EVENTO = Evento.IdEvento;
                eventoDALC.ASIENTOS_DISPONIBLES = Evento.AsientosDisponibles;
                eventoDALC.DESCRIPCION = Evento.Descripcion;
                eventoDALC.ID_TIPO_EVENTO = Evento.IdTipoEvento;
                eventoDALC.ID_RECINTO = Evento.IdRecinto;
                eventoDALC.RUT = Evento.Rut;
                eventoDALC.ESTADO = Evento.Estado;
                eventoDALC.NOMBRE = Evento.Nombre;
                eventoDALC.IMAGEN = Evento.Imagen;
                eventoDALC.FECHA = Evento.Fecha;
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Elimina un evento en la base de datos
        /// </summary>
        /// <param name="Evento">objeto Evento</param>
        /// <returns></returns>
        public void eliminarEvento(int idEvento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                EVENTO eventoDALC = (from tmpEvento in conexion.EVENTO where tmpEvento.ID_EVENTO == idEvento select tmpEvento).FirstOrDefault();

                conexion.DeleteObject(eventoDALC);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Trae un evento como objeto Evento
        /// </summary>
        /// <param name="idEvento", name="rut">id del evento y run del organizador a filtrar</param>
        /// <returns></returns>
        public EventoBEL traerEventoId(int idEvento, int rut)
        {
            try
            {
                EVENTO EvenDalc = (from tmpEvento in ConexionBLL.getConexion().EVENTO
                                   where tmpEvento.ID_EVENTO == idEvento && tmpEvento.RUT == rut
                                   select tmpEvento).FirstOrDefault();
                if (EvenDalc != null)
                {
                    EventoBEL evBEL = new EventoBEL();
                    evBEL.IdEvento = (int)EvenDalc.ID_EVENTO;
                    evBEL.IdRecinto = (int)EvenDalc.ID_RECINTO;
                    evBEL.IdTipoEvento = (int)EvenDalc.ID_TIPO_EVENTO;
                    evBEL.Nombre = EvenDalc.NOMBRE;
                    evBEL.Rut = (int)evBEL.Rut;
                    evBEL.Estado = EvenDalc.ESTADO;
                    evBEL.AsientosDisponibles = (int)EvenDalc.ASIENTOS_DISPONIBLES;
                    evBEL.Imagen = EvenDalc.IMAGEN;
                    evBEL.Fecha = EvenDalc.FECHA.Value;
                    evBEL.Descripcion = EvenDalc.DESCRIPCION;
                    return evBEL;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae un evento como objeto Evento
        /// </summary>
        /// <param name="nombre", name="rut">nombre del evento y run del organizador a filtrar</param>
        /// <returns></returns>
        public EventoBEL traerEventoPorNombreRut(String nombre,int rut)
        {
            try
            {
                EVENTO EvenDalc = (from tmpEvento in ConexionBLL.getConexion().EVENTO
                                   where tmpEvento.NOMBRE.Equals(nombre) && tmpEvento.RUT == rut
                                   select tmpEvento).FirstOrDefault();
                if (EvenDalc != null)
                {
                    EventoBEL evBEL = new EventoBEL();
                    evBEL.IdEvento = (int)EvenDalc.ID_EVENTO;
                    evBEL.IdRecinto = (int)EvenDalc.ID_RECINTO;
                    evBEL.IdTipoEvento = (int)EvenDalc.ID_TIPO_EVENTO;
                    evBEL.Nombre = EvenDalc.NOMBRE;
                    evBEL.Rut = (int)evBEL.Rut;
                    evBEL.Estado = EvenDalc.ESTADO;
                    evBEL.AsientosDisponibles = (int)EvenDalc.ASIENTOS_DISPONIBLES;
                    evBEL.Imagen = EvenDalc.IMAGEN;
                    evBEL.Fecha = EvenDalc.FECHA.Value;
                    evBEL.Descripcion = EvenDalc.DESCRIPCION;
                    return evBEL;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae un evento como objeto Evento
        /// </summary>
        /// <param name="idEvento">id del evento a filtrar</param>
        /// <returns></returns>
        public EventoBEL traerEventoRecintoNombre(int idEvento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                RECINTO EvenDalc = (from tmpEvento in conexion.EVENTO
                                   join tmpRec in conexion.RECINTO on tmpEvento.ID_RECINTO equals tmpRec.ID_RECINTO
                                   where tmpEvento.ID_EVENTO == idEvento
                                   select tmpRec).FirstOrDefault();
                if (EvenDalc != null)
                {
                    EventoBEL evBEL = new EventoBEL();
                    
                    evBEL.NombreRecinto = EvenDalc.NOMBRE_RECINTO;
                    return evBEL;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae un evento como objeto Evento
        /// </summary>
        /// <param name="idEvento">id del evento a filtrar</param>
        /// <returns></returns>
        public EventoBEL traerEventoId(int idEvento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                EVENTO EvenDalc = (from tmpEvento in conexion.EVENTO
                                   where tmpEvento.ID_EVENTO == idEvento
                                   select tmpEvento).FirstOrDefault();
                if (EvenDalc != null)
                {
                    EventoBEL evBEL = new EventoBEL();
                    evBEL.IdEvento = (int)EvenDalc.ID_EVENTO;
                    evBEL.IdRecinto = (int)EvenDalc.ID_RECINTO;
                    evBEL.IdTipoEvento = (int)EvenDalc.ID_TIPO_EVENTO;
                    evBEL.Nombre = EvenDalc.NOMBRE;
                    evBEL.Rut = (int)evBEL.Rut;
                    evBEL.Estado = EvenDalc.ESTADO;
                    evBEL.AsientosDisponibles = (int)EvenDalc.ASIENTOS_DISPONIBLES;
                    evBEL.Imagen = EvenDalc.IMAGEN;
                    evBEL.Fecha = EvenDalc.FECHA.Value;
                    evBEL.Descripcion = EvenDalc.DESCRIPCION;
                    return evBEL;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae un evento como LIST 
        /// </summary>
        /// <param name="estado", name="rut">estado del evento y run del organizador a filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> traerEventoPorEstado(String estado, int rut)
        {
            try
            {
                List<EventoBEL> eventos = (from tmpEventos in ConexionBLL.getConexion().EVENTO
                                           where tmpEventos.ESTADO.Equals(estado) && tmpEventos.RUT == rut
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tmpEventos.ID_EVENTO,
                                               IdRecinto = (int)tmpEventos.ID_RECINTO,
                                               IdTipoEvento = (int)tmpEventos.ID_TIPO_EVENTO,
                                               Nombre = tmpEventos.NOMBRE,
                                               Descripcion = tmpEventos.DESCRIPCION,
                                               AsientosDisponibles = (int)tmpEventos.ASIENTOS_DISPONIBLES,
                                               Rut = (int)tmpEventos.RUT,
                                               Estado = tmpEventos.ESTADO,
                                               Fecha = tmpEventos.FECHA.Value,
                                               Imagen = tmpEventos.IMAGEN
                                           }).ToList();
                return eventos;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae un evento como LIST 
        /// </summary>
        /// <param name="id", name="rut">id del evento y run del organizador a filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> traerEventosPorBusqueda(int id, int rut)
        {
            try
            {
                List<EventoBEL> eventos = (from tmpEventos in ConexionBLL.getConexion().EVENTO
                                           where tmpEventos.ID_EVENTO.Equals(id) && tmpEventos.RUT == rut
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tmpEventos.ID_EVENTO,
                                               IdRecinto = (int)tmpEventos.ID_RECINTO,
                                               IdTipoEvento = (int)tmpEventos.ID_TIPO_EVENTO,
                                               Nombre = tmpEventos.NOMBRE,
                                               Descripcion = tmpEventos.DESCRIPCION,
                                               AsientosDisponibles = (int)tmpEventos.ASIENTOS_DISPONIBLES,
                                               Rut = (int)tmpEventos.RUT,
                                               Estado = tmpEventos.ESTADO,
                                               Fecha = tmpEventos.FECHA.Value,
                                               Imagen = tmpEventos.IMAGEN
                                           }).ToList();
                return eventos;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae un evento como LIST 
        /// </summary>
        /// <param name="nombre", name="rut">nombre del evento y run del organizador a filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> traerEventosPorBusqueda(String nombre, int rut)
        {
            try
            {
                List<EventoBEL> eventos = (from tmpEventos in ConexionBLL.getConexion().EVENTO
                                           where tmpEventos.NOMBRE.Equals(nombre) && tmpEventos.RUT == rut
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tmpEventos.ID_EVENTO,
                                               IdRecinto = (int)tmpEventos.ID_RECINTO,
                                               IdTipoEvento = (int)tmpEventos.ID_TIPO_EVENTO,
                                               Nombre = tmpEventos.NOMBRE,
                                               Descripcion = tmpEventos.DESCRIPCION,
                                               AsientosDisponibles = (int)tmpEventos.ASIENTOS_DISPONIBLES,
                                               Rut = (int)tmpEventos.RUT,
                                               Estado = tmpEventos.ESTADO,
                                               Fecha = tmpEventos.FECHA.Value,
                                               Imagen = tmpEventos.IMAGEN
                                           }).ToList();
                return eventos;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae un evento como LIST 
        /// </summary>
        /// <param name="idTipoEvento", name="rut">id del tipo de evento y run del organizador a filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> traerEventoPorTipoEvento(int idTipoEvento, int rut)
        {
            try
            {
                List<EventoBEL> eventos = (from tmpEventos in ConexionBLL.getConexion().EVENTO
                                           where tmpEventos.ID_TIPO_EVENTO == idTipoEvento && tmpEventos.RUT == rut
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tmpEventos.ID_EVENTO,
                                               IdRecinto = (int)tmpEventos.ID_RECINTO,
                                               IdTipoEvento = (int)tmpEventos.ID_TIPO_EVENTO,
                                               Nombre = tmpEventos.NOMBRE,
                                               Descripcion = tmpEventos.DESCRIPCION,
                                               AsientosDisponibles = (int)tmpEventos.ASIENTOS_DISPONIBLES,
                                               Rut = (int)tmpEventos.RUT,
                                               Estado = tmpEventos.ESTADO,
                                               Fecha = tmpEventos.FECHA.Value,
                                               Imagen = tmpEventos.IMAGEN
                                           }).ToList();
                return eventos;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae un evento como LIST 
        /// </summary>
        /// <param name="idTipoEvento">id del tipo de evento a filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> traerEventoPorTipoEvento(int idTipoEvento)
        {
            try
            {
                List<EventoBEL> eventos = (from tmpEventos in ConexionBLL.getConexion().EVENTO
                                           where tmpEventos.ID_TIPO_EVENTO == idTipoEvento
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tmpEventos.ID_EVENTO,
                                               IdRecinto = (int)tmpEventos.ID_RECINTO,
                                               IdTipoEvento = (int)tmpEventos.ID_TIPO_EVENTO,
                                               Nombre = tmpEventos.NOMBRE,
                                               Descripcion = tmpEventos.DESCRIPCION,
                                               AsientosDisponibles = (int)tmpEventos.ASIENTOS_DISPONIBLES,
                                               Rut = (int)tmpEventos.RUT,
                                               Estado = tmpEventos.ESTADO,
                                               Fecha = tmpEventos.FECHA.Value,
                                               Imagen = tmpEventos.IMAGEN
                                           }).ToList();
                return eventos;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae un evento como LIST 
        /// </summary>
        /// <param name="idrecinto", name="rut">id del recinto del evento y run del organizador a filtrar</param>
        /// <returns></returns>
        public List<EventoBEL> traerEventoPorRecintos(int idrecinto, int rut)
        {
            try
            {
                List<EventoBEL> eventos = (from tmpEventos in ConexionBLL.getConexion().EVENTO
                                           where tmpEventos.ID_RECINTO == idrecinto && tmpEventos.RUT == rut
                                           select new EventoBEL()
                                           {
                                               IdEvento = (int)tmpEventos.ID_EVENTO,
                                               IdRecinto = (int)tmpEventos.ID_RECINTO,
                                               IdTipoEvento = (int)tmpEventos.ID_TIPO_EVENTO,
                                               Nombre = tmpEventos.NOMBRE,
                                               Descripcion = tmpEventos.DESCRIPCION,
                                               AsientosDisponibles = (int)tmpEventos.ASIENTOS_DISPONIBLES,
                                               Rut = (int)tmpEventos.RUT,
                                               Estado = tmpEventos.ESTADO,
                                               Fecha = tmpEventos.FECHA.Value,
                                               Imagen = tmpEventos.IMAGEN
                                           }).ToList();
                return eventos;
            }
            catch
            {
                return null;
            }
        }

        public List<EventoBEL> traerEventoPorTipoEvento()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene la cantidad total de entradas por eventos
        /// </summary>
        /// <param name="idevento", name="idevento">id del evento para la consulta</param>
        /// <returns></returns>
        public int totalEntradasPorEventos( int idevento)
        {
            try
            {
                int total = (from tmpAsientos in ConexionBLL.getConexion().ASIENTO
                             where tmpAsientos.ID_EVENTO == idevento
                             select tmpAsientos).Count();
                return total;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtiene la cantidad total de entradas vendidas por eventos
        /// </summary>
        /// <param name="idevento", name="idevento">id del evento para la consulta</param>
        /// <returns></returns>
        public int totalEntradasVendidasPorEventos(int idevento)
        {
            try
            {
                int total = (from tmpvendidas in ConexionBLL.getConexion().TICKET
                             where tmpvendidas.ID_EVENTO == idevento
                             select tmpvendidas).Count();
                return total;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Trae todos los registros de Eventos Segun un parametro de fecha
        /// </summary>
        /// <param name="FechaInicio">fecha inicio del Rango</param>
        /// <param name="FechaFin">fecha Fin del rango</param>
        /// <returns></returns>
        public List<EventoBEL> buscarEventosRango(DateTime FechaInicio,DateTime FechaFin)
        {
            try
            {
                List<EventoBEL> even = (from tmpEvento in ConexionBLL.getConexion().EVENTO
                                        where tmpEvento.FECHA.Value >= FechaInicio && tmpEvento.FECHA.Value < FechaFin
                                        select new EventoBEL()
                                        {
                                            IdEvento = (int)(tmpEvento.ID_EVENTO),
                                            Nombre = tmpEvento.NOMBRE,
                                            Descripcion = tmpEvento.DESCRIPCION,
                                            Imagen = tmpEvento.IMAGEN

                                        }).ToList();
                return even;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene la cantidad total de entradas por tipo de entrada
        /// </summary>
        /// <param name="idevento", name="idevento">id del tipo de entrada para la consulta</param>
        /// <returns></returns>
        public int totalEntradasPorTipoEntrada(int idTipoEntrada)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                int total = (from tmpAsientos in conexion.ASIENTO
                             where tmpAsientos.ID_TIPO_ASIENTO == idTipoEntrada
                             select tmpAsientos).Count();
                return total;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtiene la cantidad total de entradas vendidas por tipo de Entrada
        /// </summary>
        /// <param name="idevento", name="idevento">id del tipo de entrada para la consulta</param>
        /// <returns></returns>
        public int totalEntradasVendidasPorTipoEntrada(int idTipoEntrada)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                int total = (from tmpticket in conexion.TICKET
                                join tmpasientos in conexion.ASIENTO on tmpticket.ID_ASIENTO equals tmpasientos.ID_ASIENTO
                             where tmpasientos.ID_TIPO_ASIENTO == idTipoEntrada
                             select tmpasientos).Count();
                return total;
            }
            catch
            {
                return 0;
            }
        }
    }
}

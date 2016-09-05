using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class TiposTicketBLL
    {

        /// <summary>
        /// Trae el registro de Tipos de Ticket como LIST
        /// </summary>
        /// <param name="idEvento">id del evento a Filtrar</param>
        /// <returns></returns>
        public List<TiposTicketBEL> traerTiposTicket(int idEvento)
        {
            try
            {
                List<TiposTicketBEL> tiposTicket = (from tmpTiposTicket in ConexionBLL.getConexion().TIPO_TICKET
                                                    where tmpTiposTicket.ID_EVENTO == idEvento
                                                    select new TiposTicketBEL()
                                                    {
                                                        IdTipoTicket = (int)tmpTiposTicket.ID_TIPO_TICKET,
                                                        IdTipoAsiento = (int)tmpTiposTicket.ID_TIPO_ASIENTO,
                                                        Precio = (int)tmpTiposTicket.PRECIO,
                                                        IdEvento = (int)tmpTiposTicket.ID_EVENTO
                                                    }).ToList();
                return tiposTicket;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Agrega un nuevo registro de Tipo de Ticket
        /// </summary>
        /// <param name="tipo">Objeto TipoTicket</param>
        public void agregarTiposTicket(TiposTicketBEL tipo)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                TIPO_TICKET dalcTipo = new TIPO_TICKET();
                dalcTipo.ID_TIPO_ASIENTO = tipo.IdTipoAsiento;
                dalcTipo.PRECIO = tipo.Precio;
                dalcTipo.ID_EVENTO = tipo.IdEvento;
                conexion.AddToTIPO_TICKET(dalcTipo);
                conexion.SaveChanges();
                conexion.Dispose();
            }
            catch
            {
                return ;
            }
        }


        /// <summary>
        /// Modifica un registro de Tipo de Ticket
        /// </summary>
        /// <param name="tipo">Objeto TipoTicket</param>
        public void actualizarTiposTicket(TiposTicketBEL tipo)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                TIPO_TICKET dalcTipo = (from tmpTiposTicket in conexion.TIPO_TICKET
                                            where tmpTiposTicket.ID_TIPO_TICKET == tipo.IdTipoTicket select tmpTiposTicket).FirstOrDefault();
                dalcTipo.ID_TIPO_TICKET = tipo.IdTipoTicket;
                dalcTipo.ID_TIPO_ASIENTO = tipo.IdTipoAsiento;
                dalcTipo.PRECIO = tipo.Precio;
                dalcTipo.ID_EVENTO = tipo.IdEvento;
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Elimina un registro de Tipo de Ticket
        /// </summary>
        /// <param name="tipo">Objeto TipoTicket</param>
        public void eliminarTiposTicket(int idTipoTicket)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                TIPO_TICKET dalcTipo = (from tmpTiposTicket in conexion.TIPO_TICKET
                                        where tmpTiposTicket.ID_TIPO_TICKET == idTipoTicket
                                        select tmpTiposTicket).FirstOrDefault();
                conexion.DeleteObject(dalcTipo);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Trae el registro de Tipos de Eventos como objeto TiposTicket
        /// </summary>
        /// <param name="idTipoTicket">id del tipo de ticket a Filtrar</param>
        public TiposTicketBEL traerTiposTicketPorId(int idTipoTicket)
        {
            try
            {
                TIPO_TICKET dalcTipo = (from tmpTipo in ConexionBLL.getConexion().TIPO_TICKET
                                        where tmpTipo.ID_TIPO_TICKET == idTipoTicket
                                        select tmpTipo).FirstOrDefault();
                if(dalcTipo != null){
                    TiposTicketBEL tipo = new TiposTicketBEL();
                    tipo.IdTipoTicket = (int)dalcTipo.ID_TIPO_TICKET;
                    tipo.IdTipoAsiento = (int)dalcTipo.ID_TIPO_ASIENTO;
                    tipo.Precio = (int)dalcTipo.PRECIO;
                    tipo.IdEvento = (int)dalcTipo.ID_EVENTO;
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

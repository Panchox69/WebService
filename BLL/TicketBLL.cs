using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class TicketBLL
    {

        /// <summary>
        /// Agrega un nuevo registro de Ticket
        /// </summary>
        /// <param name="ticket">Objeto Ticket</param>
        public int agregarTicket(TicketBEL ticket)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                TICKET dalcTicket = new TICKET();
                dalcTicket.ID_ASIENTO = ticket.IdAsiento;
                dalcTicket.ID_EVENTO = ticket.IdEvento;
                dalcTicket.ID_TIPO_TICKET = ticket.IdTipoTicket;

                conexion.AddToTICKET(dalcTicket);
                conexion.SaveChanges();
                conexion.Dispose();

                return buscarTicket(ticket.IdAsiento, ticket.IdEvento);
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// Trae el registro de Ticket como int Ticket
        /// </summary>
        /// <param name="idAsiento", name="idEvento">id del Asiento a Filtrar, id del Evento a Filtrar</param>
        /// <returns></returns>
        public int buscarTicket(int idAsiento,int idEvento)
        {
            try
            {
                TICKET dalcTick = (from tmpTicket in ConexionBLL.getConexion().TICKET
                                   where tmpTicket.ID_ASIENTO == idAsiento && tmpTicket.ID_EVENTO == idEvento
                                   select tmpTicket).FirstOrDefault();
                if (dalcTick != null)
                {
                    return (int)dalcTick.ID_TICKET;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }
    }
}

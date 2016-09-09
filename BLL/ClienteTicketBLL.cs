using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class ClienteTicketBLL
    {
        /// <summary>
        /// Agrega un nuevo registro de Cliente_Ticket
        /// </summary>
        /// <param name="cliente">Objeto Cliente_Ticket</param>
        public void agregarClienteTicket(ClienteTicketBEL cliente)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                CLIENTE_TICKET dalcCli = new CLIENTE_TICKET();
                dalcCli.CLIENTE_RUT = cliente.ClienteRut;
                dalcCli.TICKET_ID_TICKET = cliente.IdTicket;
                dalcCli.CANTIDAD = cliente.Cantidad;
                dalcCli.TOTAL = cliente.Total;
                dalcCli.REGALO = cliente.Regalo;
                dalcCli.CORREO = cliente.Correo;
                dalcCli.HABILITADO = cliente.Habilitado;
                conexion.AddToCLIENTE_TICKET(dalcCli);
                conexion.SaveChanges();
                conexion.Dispose();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Buscador de registros de Cliente_Ticket por rut
        /// </summary>
        /// <param name="rut">rut de usuario para buscar registros asociados</param>
        /// <returns></returns>
        public ClienteTicketBEL traerTicketPorRut(int rut)
        {
            try
            {
                CLIENTE_TICKET clienteTicketDalc = ConexionBLL.getConexion().CLIENTE_TICKET.FirstOrDefault(tmpClienteTicket => (tmpClienteTicket.CLIENTE_RUT.Equals(rut)));

                if (clienteTicketDalc != null)
                {
                    ClienteTicketBEL ClienteTicketBEL = new ClienteTicketBEL();
                    ClienteTicketBEL.ClienteRut = (int)clienteTicketDalc.CLIENTE_RUT;
                    ClienteTicketBEL.IdTicket = (int)clienteTicketDalc.TICKET_ID_TICKET;
                    ClienteTicketBEL.Cantidad = (int)clienteTicketDalc.CANTIDAD;
                    ClienteTicketBEL.Total = (int)clienteTicketDalc.TOTAL;
                    ClienteTicketBEL.Regalo = clienteTicketDalc.REGALO;
                    ClienteTicketBEL.Correo = clienteTicketDalc.CORREO;
                    ClienteTicketBEL.Habilitado = (int)clienteTicketDalc.HABILITADO;
                    return ClienteTicketBEL;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Cliente_Ticket como LIST por rut
        /// </summary>
        /// <param name="rut">rut de usuario logeado</param>
        /// <returns></returns>
        public List<ClienteTicketBEL> traerClienteTicket(int rut)
        {
            try
            {
                List<ClienteTicketBEL> cliente_ticket = (from tmpCliTick in ConexionBLL.getConexion().CLIENTE_TICKET
                                                         where tmpCliTick.CLIENTE_RUT == rut
                                             select new ClienteTicketBEL()
                                             {
                                                 IdTicket = (int)tmpCliTick.TICKET_ID_TICKET,
                                                 ClienteRut = (int)tmpCliTick.CLIENTE_RUT,
                                                 Cantidad = (int)tmpCliTick.CANTIDAD,
                                                 Total = (int)tmpCliTick.TOTAL,
                                                 Regalo = tmpCliTick.REGALO,
                                                 Correo = tmpCliTick.CORREO,
                                                 Habilitado = (int)tmpCliTick.HABILITADO
                                             }).ToList();
                return cliente_ticket;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Filtra Cliente_Ticket por estado
        /// 1 = Habilitado
        /// 0 = Deshabilitado
        /// </summary>
        /// <param name="estado">valor numerico 1 ó 0</param>
        /// <returns></returns>
        public List<ClienteTicketBEL> filtrarClienteTicket(int estado)
        {
            try
            {
                List<ClienteTicketBEL> cliente_ticket = (from tmpCliTick in ConexionBLL.getConexion().CLIENTE_TICKET
                                                         where tmpCliTick.HABILITADO == estado
                                                         select new ClienteTicketBEL()
                                                         {
                                                             IdTicket = (int)tmpCliTick.TICKET_ID_TICKET,
                                                             ClienteRut = (int)tmpCliTick.CLIENTE_RUT,
                                                             Cantidad = (int)tmpCliTick.CANTIDAD,
                                                             Total = (int)tmpCliTick.TOTAL,
                                                             Regalo = tmpCliTick.REGALO,
                                                             Correo = tmpCliTick.CORREO,
                                                             Habilitado = (int)tmpCliTick.HABILITADO
                                                         }).ToList();
                return cliente_ticket;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Funcion eliminar Cliente_Ticket
        /// Deshabilita cambiando estado de habilitado en BD 
        /// 1 = Habilitado
        /// 0 = Deshabilitado
        /// </summary>
        /// <param name="id">id de Cliente_ticket</param>
        public void eliminarClienteTicket(int id)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                CLIENTE_TICKET CliTickDALC = (from tmpCliTick in conexion.CLIENTE_TICKET where tmpCliTick.TICKET_ID_TICKET == id select tmpCliTick).FirstOrDefault();
                CliTickDALC.TICKET_ID_TICKET = id;
                conexion.DeleteObject(CliTickDALC);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Trae todos los registros de Cliente_Ticket como LIST por rut del Organizador
        /// </summary>
        /// <param name="rut">rut de usuario logeado</param>
        /// <returns></returns>
        public List<ClienteTicketBEL> traerClienteTicketOrg(int rut)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                List<ClienteTicketBEL> cliente_ticket = (from tmpCliTick in conexion.CLIENTE_TICKET
                                                         join tmpTick in conexion.TICKET on tmpCliTick.TICKET_ID_TICKET equals tmpTick.ID_TICKET
                                                         join tmpEv in conexion.EVENTO on tmpTick.ID_EVENTO equals tmpEv.ID_EVENTO
                                                         where tmpEv.RUT == rut
                                                         select new ClienteTicketBEL()
                                                         {
                                                             IdTicket = (int)tmpCliTick.TICKET_ID_TICKET,
                                                             ClienteRut = (int)tmpCliTick.CLIENTE_RUT,
                                                             Cantidad = (int)tmpCliTick.CANTIDAD,
                                                             Total = (int)tmpCliTick.TOTAL,
                                                             Regalo = tmpCliTick.REGALO,
                                                             Correo = tmpCliTick.CORREO,
                                                             Habilitado = (int)tmpCliTick.HABILITADO,
                                                             NombreEvento = tmpEv.NOMBRE
                                                             
                                                         }).ToList();
                return cliente_ticket;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Cliente_Ticket como LIST por rut del Organizador y IdEvento
        /// </summary>
        /// <param name="rut">rut de usuario logeado</param>
        /// <returns></returns>
        public List<ClienteTicketBEL> traerClienteTicketOrg(int rut, int idEvento)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                List<ClienteTicketBEL> cliente_ticket = (from tmpCliTick in conexion.CLIENTE_TICKET
                                                         
                                                         join tmpTick in conexion.TICKET on tmpCliTick.TICKET_ID_TICKET equals tmpTick.ID_TICKET
                                                         join tmpEv in conexion.EVENTO on tmpTick.ID_EVENTO equals tmpEv.ID_EVENTO
                                                         where tmpEv.RUT == rut && tmpEv.ID_EVENTO == idEvento
                                                         select new ClienteTicketBEL()
                                                         {
                                                             IdTicket = (int)tmpCliTick.TICKET_ID_TICKET,
                                                             ClienteRut = (int)tmpCliTick.CLIENTE_RUT,
                                                             Cantidad = (int)tmpCliTick.CANTIDAD,
                                                             Total = (int)tmpCliTick.TOTAL,
                                                             Regalo = tmpCliTick.REGALO,
                                                             Correo = tmpCliTick.CORREO,
                                                             Habilitado = (int)tmpCliTick.HABILITADO,
                                                             NombreEvento = tmpEv.NOMBRE
                                                         }).ToList();
                return cliente_ticket;
            }
            catch
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class ClienteBLL
    {
        /// <summary>
        /// Agrega un nuevo registro de Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        /// 

        public void registroCliente(ClienteBEL cliente)
        {
                fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
                servicio.Clientes_Ins(cliente.Rut, cliente.Dv, cliente.Nombre, cliente.Apellido, cliente.Sexo, cliente.Correo, cliente.Celular, cliente.Bloqueado);
            //falta web service
            
            //servicio.registrarCliente(cliente.Rut, cliente.Dv, cliente.Nombre, cliente.Apellido, cliente.Sexo, cliente.Correo, cliente.Celular, cliente.Id_direccionparticular,cliente.Id_comuna);
            
            
            //servicio.registrarUsuario(perBel.Usuario, perBel.Contrasena, perBel.IdTipoPerfil);
                //UsuarioBEL usuario = buscarUsuarios(perBel.Usuario, perBel.Contrasena);

        }
        /*public void registroCliente(ClienteBEL cliente)
        {
            
                Entidades conexion = ConexionBLL.getConexion();
                CLIENTE clienteDALC = new CLIENTE();
                clienteDALC.RUT = cliente.Rut;
                clienteDALC.DV = cliente.Dv.ToString();
                clienteDALC.NOMBRE = cliente.Nombre;
                clienteDALC.APELLIDO = cliente.Apellido;
                //clienteDALC.DIRECCION = cliente.Direccion;
                clienteDALC.CORREO = cliente.Correo;
                clienteDALC.CELULAR = cliente.Celular;
                //clienteDALC.ID_COMUNA = cliente.IdComuna;
                //clienteDALC.ID_PERFIL = cliente.IdPerfil;
                conexion.AddToCLIENTE(clienteDALC);
                conexion.SaveChanges();
                conexion.Dispose();
            
        }*/

        /// <summary>
        /// Trae todos los registros de Clientes como LIST
        /// </summary>        
        /// <returns></returns>
        public List<ClienteBEL> traerClientes()
        {
            try
            {
                List<ClienteBEL> clientes = (from tmpCliente in ConexionBLL.getConexion().CLIENTE
                                             select new ClienteBEL()
                                             {
                                                 Rut = (int)tmpCliente.RUT,
                                                 Nombre = tmpCliente.NOMBRE,
                                                 Apellido = tmpCliente.APELLIDO,
                                                 //Direccion = tmpCliente.DIRECCION,
                                                 Celular = (int)tmpCliente.CELULAR,
                                                 Correo = tmpCliente.CORREO,
                                                 //IdComuna = (int)tmpCliente.ID_COMUNA,
                                                 //IdEstado = (int)tmpCliente.ESTADO
                                             }).ToList();
                return clientes;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae el registro de Region como objeto Region
        /// </summary>
        /// <param name="region">id de la region a filtrar</param>
        /// <returns></returns>
        public RegionBEL traerRegion(int region)
        {
            try
            {
                REGION cliDalc = (from tmpCliente in ConexionBLL.getConexion().REGION
                                  where tmpCliente.ID_REGION == region
                                  select tmpCliente).FirstOrDefault();
                if (cliDalc != null)
                {
                    RegionBEL cliente = new RegionBEL();
                    cliente.IdRegion = (int)cliDalc.ID_REGION;
                    cliente.Nombre = cliDalc.NOMBRE;
                    return cliente;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae el registro de Comuna como objeto Comuna
        /// </summary>
        /// <param name="comuna">id de la comuna a filtrar</param>
        /// <returns></returns>
        public ComunaBEL traerComuna(int comuna)
        {
            try
            {
                COMUNA cliDalc = (from tmpCliente in ConexionBLL.getConexion().COMUNA
                                   where tmpCliente.ID_COMUNA == comuna
                                   select tmpCliente).FirstOrDefault();
                if (cliDalc != null)
                {
                    ComunaBEL cliente = new ComunaBEL();
                    cliente.IdComuna = (int)cliDalc.ID_COMUNA;
                    cliente.IdRegion = (int)cliDalc.ID_REGION;
                    cliente.Nombre = cliDalc.NOMBRE;
                    return cliente;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae el registro de Cliente como objeto Cliente
        /// </summary>
        /// <param name="rut">rut del Cliente a Filtrar</param>
        /// <returns></returns>
        public ClienteBEL traerClientePorRut(int rut)
        {
            try
            {
                CLIENTE cliDalc = (from tmpCliente in ConexionBLL.getConexion().CLIENTE
                                   where tmpCliente.RUT == rut
                                   select tmpCliente).FirstOrDefault();
                if(cliDalc != null){
                    ClienteBEL cliente = new ClienteBEL();
                    cliente.Rut = (int)cliDalc.RUT;
                    cliente.Nombre = cliDalc.NOMBRE;
                    cliente.Apellido = cliDalc.APELLIDO;
                    //cliente.Direccion = cliDalc.DIRECCION;
                    cliente.Celular = (int)cliDalc.CELULAR;
                    //cliente.IdComuna = (int)cliDalc.ID_COMUNA;
                    cliente.Correo = cliDalc.CORREO;
                    cliente.Dv = Convert.ToChar(cliDalc.DV);
                    //cliente.IdEstado = (int)cliDalc.ESTADO;

                    return cliente;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Modifica un registro de Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        public void actualizarCliente(ClienteBEL cliente)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                CLIENTE clienteDalc = (from tmpCliente in conexion.CLIENTE
                                       where tmpCliente.RUT == cliente.Rut
                                       select tmpCliente).FirstOrDefault();
                clienteDalc.NOMBRE = cliente.Nombre;
                clienteDalc.APELLIDO = cliente.Apellido;
                clienteDalc.CELULAR = cliente.Celular;
                clienteDalc.CORREO = cliente.Correo;
                //clienteDalc.DIRECCION = cliente.Direccion;
                //clienteDalc.ID_COMUNA = cliente.IdComuna;
                //clienteDalc.ESTADO = cliente.IdEstado;

                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Elimina un registro de Cliente
        /// </summary>
        /// <param name="rut">rut del cliente a eliminar</param>
        public void eliminarClientePorRut(int rut)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                CLIENTE clienteDalc = (from tmpCliente in conexion.CLIENTE where tmpCliente.RUT == rut select tmpCliente).FirstOrDefault();

                conexion.DeleteObject(clienteDalc);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Trae todos los registros de Clientes como LIST
        /// </summary>
        /// <param name="rut">rut del cliente a Filtrar</param>
        /// <returns></returns>
        public List<ClienteBEL> buscarClientes(int rut)
        {
            try
            {
                List<ClienteBEL> clientes = (from tmpCliente in ConexionBLL.getConexion().CLIENTE
                                             where tmpCliente.RUT == rut
                                             select new ClienteBEL()
                                                         {
                                                             Rut = (int)tmpCliente.RUT,
                                                             Nombre = tmpCliente.NOMBRE,
                                                             Apellido = tmpCliente.APELLIDO,
                                                             //Direccion = tmpCliente.DIRECCION,
                                                             Celular = (int)tmpCliente.CELULAR,
                                                             Correo = tmpCliente.CORREO,
                                                             //IdComuna = (int)tmpCliente.ID_COMUNA
                                                         }).ToList();
                return clientes;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trae todos los registros de Clientes como LIST
        /// </summary>
        /// <param name="nombre">nombre del cliente a Filtrar</param>
        /// <returns></returns>
        public List<ClienteBEL> buscarClientes(String nombre)
        {
            try
            {
                List<ClienteBEL> clientes = (from tmpCliente in ConexionBLL.getConexion().CLIENTE
                                             where tmpCliente.NOMBRE == nombre
                                             select new ClienteBEL()
                                                {
                                                    Rut = (int)tmpCliente.RUT,
                                                    Nombre = tmpCliente.NOMBRE,
                                                    Apellido = tmpCliente.APELLIDO,
                                                    //Direccion = tmpCliente.DIRECCION,
                                                    Celular = (int)tmpCliente.CELULAR,
                                                    Correo = tmpCliente.CORREO,
                                                    //IdComuna = (int)tmpCliente.ID_COMUNA
                                                }).ToList();
                return clientes;
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// Trae todos los registros de Clientes como LIST
        /// </summary>
        /// <param name="apellido">apellido del cliente a Filtrar</param>
        /// <returns></returns>
        public List<ClienteBEL> buscarCliente(String apellido)
        {
            try
            {
                List<ClienteBEL> clientes = (from tmpCliente in ConexionBLL.getConexion().CLIENTE
                                             where tmpCliente.APELLIDO == apellido
                                             select new ClienteBEL()
                                                {
                                                    Rut = (int)tmpCliente.RUT,
                                                    Nombre = tmpCliente.NOMBRE,
                                                    Apellido = tmpCliente.APELLIDO,
                                                    //Direccion = tmpCliente.DIRECCION,
                                                    Celular = (int)tmpCliente.CELULAR,
                                                    Correo = tmpCliente.CORREO,
                                                    //IdComuna = (int)tmpCliente.ID_COMUNA
                                                }).ToList();
                return clientes;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Filtra Clientes por estado
        /// 1 = Habilitado
        /// 0 = Deshabilitado
        /// </summary>
        /// <param name="estado">valor numerico 1 ó 0</param>
        /// <returns></returns>
        public List<ClienteBEL> FiltrarClientes(int estado)
        {
            try
            {
                List<ClienteBEL> clientes = (from tmpCliente in ConexionBLL.getConexion().CLIENTE
                                             where tmpCliente.ESTADO == estado
                                             select new ClienteBEL()
                                             {
                                                 Rut = (int)tmpCliente.RUT,
                                                 Nombre = tmpCliente.NOMBRE,
                                                 Apellido = tmpCliente.APELLIDO,
                                                 //Direccion = tmpCliente.DIRECCION,
                                                 Celular = (int)tmpCliente.CELULAR,
                                                 Correo = tmpCliente.CORREO,
                                                 //IdEstado = (int)tmpCliente.ESTADO,
                                                 //IdComuna = (int)tmpCliente.ID_COMUNA
                                             }).ToList();
                return clientes;
            }
            catch
            {
                return null;
            }
        }
    }
}

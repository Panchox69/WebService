using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;

namespace BLL
{
    public class OrganizadorBLL
    {

        /// <summary>
        /// Agrega un nuevo registro de Organizador
        /// </summary>
        /// <param name="org">Objeto Organizador</param>
        public void registroOrganizador(OrganizadorBEL org)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ORGANIZADOR orgDALC = new ORGANIZADOR();
                orgDALC.RUT = org.Rut;
                orgDALC.DV = org.Dv.ToString();
                orgDALC.NOMBRE_RAZON_SOCIAL = org.NombreRazonSocial;
                orgDALC.GIRO = org.Giro;
                orgDALC.DIRECCION = org.Direccion;
                orgDALC.CORREO = org.Correo;
                orgDALC.ID_COMUNA = org.IdComuna;
                orgDALC.ID_PERFIL = org.IdPerfil;
                orgDALC.VALIDO = org.Valido;
                conexion.AddToORGANIZADOR(orgDALC);
                conexion.SaveChanges();
                conexion.Dispose();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Trae todos los registros de Organizador como LIST
        /// </summary>        
        /// <returns></returns>
        public List<OrganizadorBEL> listaOrganizador()
        {
            try
            {
                List<OrganizadorBEL> lista = (from tmpOrganizador in ConexionBLL.getConexion().ORGANIZADOR
                                              select new OrganizadorBEL()
                                              {
                                                  Rut = (int)tmpOrganizador.RUT,
                                                  NombreRazonSocial = tmpOrganizador.NOMBRE_RAZON_SOCIAL,
                                                  Giro = tmpOrganizador.GIRO,
                                                  Direccion = tmpOrganizador.DIRECCION,
                                                  Correo = tmpOrganizador.CORREO,
                                                  IdEstado = (int)tmpOrganizador.ESTADO
                                              }).ToList();
                return lista;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Elimina un registro de Organizador
        /// </summary>
        /// <param name="rut">rut del Organizador a eliminar</param>
        public void eliminarOrganizador(int rut)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ORGANIZADOR OrganizadorDALC = (from tmpOrganizador in conexion.ORGANIZADOR where tmpOrganizador.RUT == rut select tmpOrganizador).FirstOrDefault();
                OrganizadorDALC.RUT = rut;
                conexion.DeleteObject(OrganizadorDALC);
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Modifica un registro de Organizador
        /// </summary>
        /// <param name="cliente">Objeto Organizador</param>
        public void editarOrganizador(OrganizadorBEL organizador)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ORGANIZADOR OrganizadorDALC = (from tmpOrganizador in conexion.ORGANIZADOR where tmpOrganizador.RUT == organizador.Rut select tmpOrganizador).FirstOrDefault();
                OrganizadorDALC.NOMBRE_RAZON_SOCIAL = organizador.NombreRazonSocial;
                OrganizadorDALC.GIRO = organizador.Giro;
                OrganizadorDALC.DIRECCION = organizador.Direccion;
                OrganizadorDALC.CORREO = organizador.Correo;
                OrganizadorDALC.ESTADO = organizador.IdEstado;
                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Trae el registro de Organizador como objeto Organizador
        /// </summary>
        /// <param name="rut">rut del Organizador a Filtrar</param>
        /// <returns></returns>
        public OrganizadorBEL MostrarOrganizador(int rut)
        {
            try
            {
                ORGANIZADOR org_encontrado = (from tmporg in ConexionBLL.getConexion().ORGANIZADOR
                                              where tmporg.RUT == rut
                                              select tmporg).FirstOrDefault();
                if (org_encontrado != null)
                {
                    OrganizadorBEL orgBEL = new OrganizadorBEL();
                    orgBEL.Rut = (int)org_encontrado.RUT;
                    orgBEL.Dv = Convert.ToChar(org_encontrado.DV);
                    orgBEL.NombreRazonSocial = org_encontrado.NOMBRE_RAZON_SOCIAL;
                    orgBEL.Direccion = org_encontrado.DIRECCION;
                    orgBEL.Giro = org_encontrado.GIRO;
                    orgBEL.Correo = org_encontrado.CORREO;
                    orgBEL.IdEstado = (int)org_encontrado.ESTADO;
                    orgBEL.IdComuna = (int)org_encontrado.ID_COMUNA;
                    return orgBEL;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae todos los registros de Organizador como LIST
        /// </summary>        
        /// <param name="rut">rut del Organizador a Filtrar</param>
        /// <returns></returns>
        public List<OrganizadorBEL> buscarOrganizadores(int rut)
        {
            try
            {
                List<OrganizadorBEL> org = (from tmpOrganizador in ConexionBLL.getConexion().ORGANIZADOR
                                            where tmpOrganizador.RUT == rut
                                            select new OrganizadorBEL()
                                            {
                                                Rut = (int)tmpOrganizador.RUT,
                                                NombreRazonSocial = tmpOrganizador.NOMBRE_RAZON_SOCIAL,
                                                Giro = tmpOrganizador.GIRO,
                                                Direccion = tmpOrganizador.DIRECCION,
                                                Correo = tmpOrganizador.CORREO,
                                                IdEstado = (int)tmpOrganizador.ESTADO
                                            }).ToList();
                return org;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae el registro de Organizador como objeto Organizador
        /// 1 = Habilitado
        /// 0 = Deshabilitado
        /// </summary>
        /// <param name="estado">estado del Organizador a Filtrar</param>
        /// <returns></returns>
        public List<OrganizadorBEL> FiltarOrganizadores(int estado)
        {
            try
            {
                List<OrganizadorBEL> org = (from tmpOrganizador in ConexionBLL.getConexion().ORGANIZADOR
                                            where tmpOrganizador.ESTADO == estado
                                            select new OrganizadorBEL()
                                            {
                                                Rut = (int)tmpOrganizador.RUT,
                                                NombreRazonSocial = tmpOrganizador.NOMBRE_RAZON_SOCIAL,
                                                Giro = tmpOrganizador.GIRO,
                                                Direccion = tmpOrganizador.DIRECCION,
                                                IdEstado = (int)tmpOrganizador.ESTADO,
                                                Correo = tmpOrganizador.CORREO
                                            }).ToList();
                return org;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Trae todos los registros de Organizador como LIST
        /// </summary> 
        /// <returns></returns>
        public List<OrganizadorBEL> listaContrato()
        {
            try
            {
                List<OrganizadorBEL> lista = (from tmpOrganizador in ConexionBLL.getConexion().ORGANIZADOR
                                              select new OrganizadorBEL()
                                              {
                                                  IdFolio = (int)tmpOrganizador.ID_FOLIO,
                                                  Rut = (int)tmpOrganizador.RUT,
                                                  NombreRazonSocial = tmpOrganizador.NOMBRE_RAZON_SOCIAL,
                                                  Giro = tmpOrganizador.GIRO,
                                                  Direccion = tmpOrganizador.DIRECCION,
                                                  Correo = tmpOrganizador.CORREO,

                                              }).ToList();
                return lista;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Actualiza un registro de Organizador
        /// v = valido
        /// n = no valido
        /// </summary>
        /// <param name="folio", name="apro">id del folio, string si esta aprobado </param>
        public void updateAprobado(int folio, String apro)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ORGANIZADOR organizadorDalc = (from tmpOrg in conexion.ORGANIZADOR
                                               where tmpOrg.ID_FOLIO == folio
                                               select tmpOrg).FirstOrDefault();
                organizadorDalc.VALIDO = apro;


                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Actualiza un registro de Organizador
        /// 0 = valido
        /// 1 = no valido
        /// </summary>
        /// <param name="folio", name="apro">id del folio, string si esta aprobado </param>
        public void updateAutorizado(int folio, int apro)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                ORGANIZADOR organizadorDalc = (from tmpOrg in conexion.ORGANIZADOR
                                               where tmpOrg.ID_FOLIO == folio
                                               select tmpOrg).FirstOrDefault();
                organizadorDalc.ESTADO = apro;


                conexion.SaveChanges();
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// Trae todos los registros de Organizador como LIST
        /// </summary> 
        /// <returns></returns>
        public List<OrganizadorBEL> listaAdministrador()
        {
            try
            {
                List<OrganizadorBEL> lista = (from tmpOrganizador in ConexionBLL.getConexion().ORGANIZADOR
                                              select new OrganizadorBEL()
                                              {
                                                  IdFolio = (int)tmpOrganizador.ID_FOLIO,
                                                  NombreRazonSocial = tmpOrganizador.NOMBRE_RAZON_SOCIAL,
                                                  Valido = tmpOrganizador.VALIDO,
                                                  IdEstado = (int)tmpOrganizador.ESTADO

                                              }).ToList();
                return lista;
            }
            catch
            {
                return null;
            }
        }
    }
}

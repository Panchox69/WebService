using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;
using DALC;
using System.Security.Cryptography;
using System.Data;

namespace BLL
{
    public class PerfilBLL
    {
        private String _encriptar(String pass)
        {
            String contrasenaEncrip = String.Empty;
            using (MD5 md5Hash = MD5.Create())
            {
                contrasenaEncrip = Utilidades.GetMd5Hash(md5Hash, pass);
            }
            return contrasenaEncrip;
        }

        private String encriptarHash(string pass)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public UsuarioBEL buscarUsuarios(int usuario_login, string pass_login)
        {
            //try
            //{
            //serviceexterno.WebServicePruebaSoapClient servicio = new serviceexterno.WebServicePruebaSoapClient();
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            //fru.ServicioWebFrutosSoapClient servicio = new fru.ServicioWebFrutosSoapClient();
            //fru.ServicioWebFrutosSoap
            // fru.ServicioWebFrutosSoapClient servicio = new fru.ServicioWebFrutosSoapClient();
            
            
            string pass_encri = encriptarHash(pass_login);
            
            
            DataSet custDS = new DataSet();
            custDS = servicio.Usuario_Sel(usuario_login, pass_encri);

            if (custDS.Tables["Usuarios"].Rows.Count > 0)
            {
                UsuarioBEL usuario_enc = new UsuarioBEL();
                usuario_enc.Rut = Convert.ToInt32(custDS.Tables["Usuarios"].Rows[0]["rut"].ToString());
                usuario_enc.Contrasena = custDS.Tables["Usuarios"].Rows[0]["contrasena"].ToString();
                usuario_enc.IdTipoPerfil = Convert.ToInt32(custDS.Tables["Usuarios"].Rows[0]["id_tipo_perfil"]);

                return usuario_enc;
            }
            return null;
        }
        /*catch
        {
            return null;
        }*/



        //}



        /*WebService.WebServicePruebaSoapClient servicio = new WebService.WebServicePruebaSoapClient();
    DataSet custDS = new DataSet();
    custDS = servicio.getEncontrar(codigo);
   if (custDS.Tables["DATOS"].Rows.Count > 0)
    {
        //foreach (DataSet registro in custDS.Tables)
        iRecinto recinto = new iRecinto();
        recinto.Codigo = custDS.Tables["DATOS"].Rows[0]["idRecinto"].ToString();
        //recinto.FotoRecinto = custDS.Tables["DATOS"].Rows[0]["fotoMapa"].ToString();
        recinto.FotoMapa = custDS.Tables["DATOS"].Rows[0]["fotoRecinto"].ToString();

        return recinto;
    }
    else
        return null;*/


        public PerfilBEL buscarUsuario(String usuario_login, String pass_login)
        {
            
                String pass_encryp = _encriptar(pass_login);
                PERFIL perfil_encontrado = ConexionBLL.getConexion().PERFIL.FirstOrDefault(tempPerfil => (tempPerfil.USUARIO.Equals(usuario_login) && tempPerfil.CONTRASENA.Equals(pass_encryp)));

                if (perfil_encontrado != null)
                {
                    PerfilBEL usuario_enc = new PerfilBEL();
                    usuario_enc.IdPerfil = Convert.ToInt32(perfil_encontrado.ID_PERFIL);
                    usuario_enc.Usuario = perfil_encontrado.USUARIO;
                    usuario_enc.Contrasena = perfil_encontrado.CONTRASENA;
                    usuario_enc.IdTipoPerfil = Convert.ToInt32(perfil_encontrado.ID_TIPO_PERFIL);

                    return usuario_enc;
                }
                return null;
            

        }

        public int agregarPerfil(PerfilBEL perBel)
        {
            try
            {
                Entidades conexion = ConexionBLL.getConexion();
                PERFIL perDALC = new PERFIL();
                perDALC.USUARIO = perBel.Usuario;
                perDALC.CONTRASENA = _encriptar(perBel.Contrasena);
                perDALC.ID_TIPO_PERFIL = perBel.IdTipoPerfil;

                conexion.AddToPERFIL(perDALC);
                conexion.SaveChanges();
                conexion.Dispose();

                PerfilBEL perfilEnc = buscarUsuario(perBel.Usuario, perBel.Contrasena);
                return perfilEnc.IdPerfil;
            }
            catch
            {
                return 0;
            }
        }

        public void agregarUsuario(UsuarioBEL perBel)
        {
            try
            {
                fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
                string pass_encri = encriptarHash(perBel.Contrasena);
                servicio.Usuario_Ins(perBel.Rut, pass_encri, perBel.IdTipoPerfil);
            }
            catch
            {
                return;
            }
        }
    }
}

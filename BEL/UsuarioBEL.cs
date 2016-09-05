using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class UsuarioBEL
    {
        #region Atributos
        private int _rut;
        private String _contrasena;
        private int _id_tipo_perfil;
        #endregion

        #region Propiedades
        public int Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        public String Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }
        public int IdTipoPerfil
        {
            get { return _id_tipo_perfil; }
            set { _id_tipo_perfil = value; }
        }
        #endregion

        #region Contrusctores
        private void Init()
        {
            _rut = 0;
            _contrasena = String.Empty;
            _id_tipo_perfil = 0;
        }

        public UsuarioBEL()
        {
            this.Init();
        }

        public UsuarioBEL(int rut, String contrasena, int id_tipo_perfil)
        {
            this._rut = rut;
            this._contrasena = contrasena;
            this._id_tipo_perfil = id_tipo_perfil;
        }
        #endregion

    }
}

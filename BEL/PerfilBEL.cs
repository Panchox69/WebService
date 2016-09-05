using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class PerfilBEL
    {
        #region Atributos
        private int _idPerfil;
        private String _usuario;
        private String _contrasena;
        private int _idTipoPerfil;
        #endregion

        #region Propiedades
        public int IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }
        public String Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public String Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }
        public int IdTipoPerfil
        {
            get { return _idTipoPerfil; }
            set { _idTipoPerfil = value; }
        }
        #endregion

        #region Contrusctores
        private void Init(){
            _idTipoPerfil = 0;
            _idPerfil = 0;
            _usuario = String.Empty;
            _contrasena = String.Empty;
        }

        public PerfilBEL()
        {
            this.Init();
        }

        public PerfilBEL(int idperfil, String usuario,String contrasena,int idtipoperfil)
        {
            this._idPerfil = idperfil;
            this._usuario = usuario;
            this._contrasena = contrasena;
            this._idTipoPerfil = idtipoperfil;
        }
        #endregion

    }
}

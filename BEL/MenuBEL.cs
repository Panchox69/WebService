using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class MenuBEL
    {
        #region Atributos
        private int _idMenu;
        private String _campo;
        private String _urlInterna;
        private int _idTipoPerfil;
        #endregion

        #region Propiedades
        public int IdMenu
        {
            get { return _idMenu; }
            set { _idMenu = value; }
        }
        public String Campo
        {
            get { return _campo; }
            set { _campo = value; }
        }
        public String UrlInterna
        {
            get { return _urlInterna; }
            set { _urlInterna = value; }
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
            _idMenu = 0;
            _campo = String.Empty;
            _urlInterna = String.Empty;
        }

        public MenuBEL()
        {
            this.Init();
        }

        public MenuBEL(int idMenu, String campo, String urlInterna, int idtipoperfil)
        {
            this._idMenu = idMenu;
            this._campo = campo;
            this._urlInterna = urlInterna;
            this._idTipoPerfil = idtipoperfil;
        }
        #endregion
    }
}

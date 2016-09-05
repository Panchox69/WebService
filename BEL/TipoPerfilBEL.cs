using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TipoPerfilBEL
    {
        #region Atributos
        private int _idTipoPerfil;
        private String _descripcion;
        #endregion

        #region Propiedades
        public int IdTipoPerfil
        {
            get { return _idTipoPerfil; }
            set { _idTipoPerfil = value; }
        }
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        #endregion

        #region Constructores
        private void Init(){
            _idTipoPerfil = 0;
            _descripcion = String.Empty;
        }

        public TipoPerfilBEL()
        {
            this.Init();
        }

        public TipoPerfilBEL(int idtipoperfil, String descripcion)
        {
            this._descripcion = descripcion;
            this._idTipoPerfil = idtipoperfil;
        }
        #endregion

    }
}

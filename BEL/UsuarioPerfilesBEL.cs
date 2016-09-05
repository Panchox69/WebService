using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class UsuarioPerfilesBEL
    {
         #region Atributos
        private int _rut;
        private int _id_tipo_perfil;
        #endregion

        #region Propiedades
        public int Rut
        {
          get { return _rut; }
          set { _rut = value; }
        }
        public int Id_tipo_perfil
        {
            get { return _id_tipo_perfil; }
            set { _id_tipo_perfil = value; }
        }
        #endregion

        #region Contrusctores
        private void Init()
        {
            _rut = 0;
            _id_tipo_perfil = 0;
        }

        public UsuarioPerfilesBEL()
        {
            this.Init();
        }

        public UsuarioPerfilesBEL(int rut, int id_tipo_perfil)
        {
            this._rut = rut;
            this._id_tipo_perfil = id_tipo_perfil;
        }
        #endregion

    }
}

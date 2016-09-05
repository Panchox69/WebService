using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TipoAsientoBEL
    {
        #region Atributos

        private String _nombre;
        private int _idTipoAsientoId;

        #endregion

        #region Propiedades

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int IdTipoAsiento
        {
            get { return _idTipoAsientoId; }
            set { _idTipoAsientoId = value; }
        }

        #endregion

        #region Constructores

        public TipoAsientoBEL()
        {
            this.Init();
        }

        public TipoAsientoBEL(String nombre, int idTipoAsiento)
        {
            this._nombre = nombre;
            this._idTipoAsientoId = idTipoAsiento;
        }

        private void Init()
        {
            _nombre = String.Empty;
            _idTipoAsientoId = 0;
        }

        #endregion
    }
}

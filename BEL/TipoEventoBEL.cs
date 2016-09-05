using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TipoEventoBEL
    {
        #region Atributos

        private String _descripcionTipoEvento;
        private int _idTipoEvento;

        #endregion

        #region Propiedades

        public String DescripcionTipoEvento
        {
            get { return _descripcionTipoEvento; }
            set { _descripcionTipoEvento = value; }
        }
        public int IdTipoEvento
        {
            get { return _idTipoEvento; }
            set { _idTipoEvento = value; }
        }

        #endregion

        #region Constructores

        public TipoEventoBEL()
        {
            this.Init();
        }

        public TipoEventoBEL(String descripcionTipoEvento)
        {
            this._descripcionTipoEvento = descripcionTipoEvento;
        }

        private void Init()
        {
            _descripcionTipoEvento = String.Empty;
        }

        #endregion

    }
}

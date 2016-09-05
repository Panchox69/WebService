using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class InteresBEL
    {
        #region Atributos
        private int _idInteres;
        private String _descricion;
        #endregion

        #region Propiedades
        public int IdInteres
        {
            get { return _idInteres; }
            set { _idInteres = value; }
        }
        public String Descripcion
        {
            get { return _descricion; }
            set { _descricion = value; }
        }
        #endregion

        #region Constructores
        private void Init(){
            _idInteres = 0;
            _descricion = String.Empty;
        }

        public InteresBEL()
        {
            this.Init();
        }

        public InteresBEL(int idInteres, String descrp)
        {
            this._idInteres = idInteres;
            this._descricion = descrp;
        }
        #endregion
    }
}

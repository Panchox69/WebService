using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class RegionBEL
    {
        #region Atributos
        private int _idRegion;
        private String _nombre;
        #endregion

        #region Propiedades
        public int IdRegion
        {
            get { return _idRegion; }
            set { _idRegion = value; }
        }
        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region Constructores
        private void Init(){
            _idRegion = 0;
            _nombre = String.Empty;
        }

        public RegionBEL()
        {
            this.Init();
        }

        public RegionBEL(int idregion, String nombre)
        {
            this._idRegion = idregion;
            this._nombre = nombre;
        }
        #endregion
    }
}

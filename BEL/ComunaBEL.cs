using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ComunaBEL
    {
        #region Atributos
        private int _idComuna;
        private int _idRegion;
        private String _nombre;
        #endregion

        #region Propiedades
        public int IdComuna
        {
            get { return _idComuna; }
            set { _idComuna = value; }
        }
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
            _idComuna = 0;
            _idRegion = 0;
            _nombre = String.Empty;
        }

        public ComunaBEL()
        {
            this.Init();
        }

        public ComunaBEL(int idcomuna, String nombre,int idregion)
        {
            this._idComuna = idcomuna;
            this._idRegion = idregion;
            this._nombre = nombre;
        }
        #endregion
    }
}

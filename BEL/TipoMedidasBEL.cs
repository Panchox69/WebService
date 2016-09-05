using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TipoMedidasBEL
    {
        #region Atributos
        private int _id_medida;
        private String _nombre;
        #endregion

        #region Propiedades
        public int Id_medida
        {
            get { return _id_medida; }
            set { _id_medida = value; }
        }
        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region Contrusctores
        private void Init()
        {
            _id_medida = 0;
            _nombre = String.Empty;
        }

        public TipoMedidasBEL()
        {
            this.Init();
        }

        public TipoMedidasBEL(int id_medida, String nombre)
        {
            this._id_medida =id_medida;
            this._nombre = nombre;
        }
        #endregion

    }
}

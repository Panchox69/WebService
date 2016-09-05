using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TipoProductoBEL
    {
        #region Atributos
        private int _id_tipo_producto;        
        private String _nombre;
        #endregion

        #region Propiedades
        public int Id_tipo_producto
        {
            get { return _id_tipo_producto; }
            set { _id_tipo_producto = value; }
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
            _id_tipo_producto = 0;
            _nombre = String.Empty;
        }

        public TipoProductoBEL()
        {
            this.Init();
        }

        public TipoProductoBEL(int id_tipo_producto, String nombre)
        {
            this._id_tipo_producto = id_tipo_producto;
            this._nombre = nombre;
        }
        #endregion

    }
}

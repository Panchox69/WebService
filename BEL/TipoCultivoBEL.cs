using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TipoCultivoBEL
    {
        #region Atributos
        private int _id_tipo_cultivo;
        private String _nombre;
        #endregion

        #region Propiedades
        public int Id_tipo_cultivo
        {
            get { return _id_tipo_cultivo; }
            set { _id_tipo_cultivo = value; }
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
            _id_tipo_cultivo = 0;
            _nombre = String.Empty;
        }

        public TipoCultivoBEL()
        {
            this.Init();
        }

        public TipoCultivoBEL(int id_tipo_cultivo, String nombre)
        {
            this._id_tipo_cultivo = id_tipo_cultivo;
            this._nombre = nombre;
        }
        #endregion

    }
}


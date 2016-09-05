using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class RecintoBEL
    {
        #region Atributos

        private int _idComuna;
        private int _idRecinto;
        private String _nombreRecinto;
        private String _imagenRecinto;
        private String _direccionRecinto;
        private int _idEstado;

        #endregion

        #region Propiedades

        public int IdComuna
        {
            get { return _idComuna; }
            set { _idComuna = value; }
        }

        public int IdRecinto
        {
            get { return _idRecinto; }
            set { _idRecinto = value; }
        }

        public String NombreRecinto
        {
            get { return _nombreRecinto; }
            set { _nombreRecinto = value; }
        }
        public String ImagenRecinto
        {
            get { return _imagenRecinto; }
            set { _imagenRecinto = value; }
        }
        public String DireccionRecinto
        {
            get { return _direccionRecinto; }
            set { _direccionRecinto = value; }
        }

        public int IdEstado
        {
            get{return _idEstado;}
            set { _idEstado = value; }
        }

        public String NombreEstado
        {
            get
            {
                if (IdEstado == 0)
                {
                    return "Deshabilitado";
                }
                else
                {
                    return "Habilitado";
                }
            }
        }

        #endregion

        #region Constructores

        private void Init()
        {
            _idComuna = 0;
            _idRecinto = 0;
            _nombreRecinto = String.Empty;
            _imagenRecinto = String.Empty;
            _direccionRecinto = String.Empty;
        }

        public RecintoBEL()
        {
            this.Init();
        }


        public RecintoBEL(int idComuna, int idRecinto, String nombreRecinto, String imagenRecinto, String direccionRecinto)
        {
            this._idComuna = idComuna;
            this._idRecinto = idRecinto;
            this._nombreRecinto = nombreRecinto;
            this._imagenRecinto = imagenRecinto;
            this._direccionRecinto = direccionRecinto;
        }

        #endregion
    }
}

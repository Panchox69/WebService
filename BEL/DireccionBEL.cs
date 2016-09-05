using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class DireccionBEL
    {
        #region Atributos
        private String _nombre;
        private int _numero;
        private int _id_comuna;
        private int _coordenada_x;
        private int _coordenada_y;
        #endregion

        #region Propiedades
        public String Nombre
        {
          get { return _nombre; }
          set { _nombre = value; }
        }
        public int Numero
        {
          get { return _numero; }
          set { _numero = value; }
        }
        public int Id_comuna
        {
          get { return _id_comuna; }
          set { _id_comuna = value; }
        }
        public int Coordenada_x
        {
          get { return _coordenada_x; }
          set { _coordenada_x = value; }
        }
        public int Coordenada_y
        {
          get { return _coordenada_y; }
          set { _coordenada_y = value; }
        }
        #endregion

        #region Contrusctores
        private void Init()
        {
            _nombre = String.Empty;
            _numero = 0;
            _id_comuna = 0;
            _coordenada_x = 0;
            _coordenada_y = 0;
        }

        public DireccionBEL()
        {
            this.Init();
        }

        public DireccionBEL(String nombre, int numero, int id_comuna, int coordenada_x, int coordenada_y)
        {
            //this._id_direccion = id_direccion;
            this._nombre = nombre;
            this._numero = numero;
            this._id_comuna = id_comuna;
            this._coordenada_x = coordenada_x;
            this._coordenada_y = coordenada_y;
        }
        #endregion

    }
}

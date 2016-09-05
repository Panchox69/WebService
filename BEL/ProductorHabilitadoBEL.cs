using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ProductorHabilitadoBEL
    {
    #region Atributos
        private int _rut;
        private char _dv;
        private String _nombre;
        private String _apellido;
        private DateTime _fecha;
        #endregion

        #region Propiedades

        public int Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        public char Dv
        {
            get { return _dv; }
            set { _dv = value; }
        }
        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public String Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public DateTime Fecha
        {
          get { return _fecha; }
          set { _fecha = value; }
        }    
        #endregion

        #region Contructores

        private void Init()
        {
            _rut = 0;
            _dv = ' ';
            _nombre = String.Empty;
            _apellido = String.Empty;
            _fecha = DateTime.MinValue;            
        }
        public ProductorHabilitadoBEL()
        {
            Init();
        }

        public ProductorHabilitadoBEL(int rut, char dv, String nombre, String apellido, DateTime fecha)
        {
            _rut = rut;
            _dv = dv;
            _nombre = nombre;
            _apellido = apellido;
            _fecha = fecha;            
        }
        #endregion
    }
}


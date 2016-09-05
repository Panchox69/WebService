using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ProductorBEL
    {
        #region Atributos
        private int _rut;
        private char _dv;
        private String _nombre;
        private String _apellido;
        private char _sexo;
        private int _id_direccionparticular;
        private int _celular;
        private String _correo;
        private int _id_direccionnegocio;
        private int _mismadireccion;      
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
        public char Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }  
        public int Id_direccionparticular
        {
            get { return _id_direccionparticular; }
            set { _id_direccionparticular = value; }
        }
        public int Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }
        public String Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public int Id_direccionnegocio
        {
          get { return _id_direccionnegocio; }
          set { _id_direccionnegocio = value; }
        }
        public int Mismadireccion
        {
          get { return _mismadireccion; }
          set { _mismadireccion = value; }
        } 
        #endregion

        #region Contructores

        private void Init()
        {
            _rut = 0;
            _dv = ' ';
            _nombre = String.Empty;
            _apellido = String.Empty;
            _sexo = ' ';
            _id_direccionparticular = 0;
            _celular = 0;
            _correo = String.Empty;  
            _id_direccionnegocio = 0;
            _mismadireccion = 0;
            
        }
        public ProductorBEL()
        {
            Init();
        }

        public ProductorBEL(int rut, char dv, String nombre, String apellido, char sexo, int id_direccionparticular, int celular, String correo, int id_comuna, int id_direccionnegocio, int mismadireccion )
        {
            _rut = rut;
            _dv = dv;
            _nombre = nombre;
            _apellido = apellido;
            _sexo = sexo;
            _id_direccionparticular = id_direccionparticular;
            _celular = celular;
            _correo = correo;
            _id_direccionnegocio = id_direccionnegocio;
            _mismadireccion = mismadireccion;

            
        }
        #endregion
    }
}

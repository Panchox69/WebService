using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ClienteBEL
    {
        #region Atributos
        private int _rut;
        private char _dv;
        private String _nombre;
        private String _apellido;
        private char _sexo;        
        private String _correo;
        private int _celular;
        private int _bloqueado;      
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
        public String Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public int Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }
        public int Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
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
            _correo = String.Empty;
            _celular = 0;
            _bloqueado = 0;
        }
        public ClienteBEL()
        {
            Init();
        }

        public ClienteBEL(int rut, char dv, String nombre, String apellido, char sexo, String correo, int celular, int bloqueado)
        {
            _rut = rut;
            _dv = dv;
            _nombre = nombre;
            _apellido = apellido;
            _sexo = sexo;
            _correo = correo;
            _celular = celular;
            _bloqueado = bloqueado;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class OrganizadorBEL
    {
        #region Atributos
        private int _rut;
        private char _dv;
        private String _nombreRazonSocial;
        private String _direccion;
        private String _correo;
        private int _idComuna;
        private int _idPerfil;
        private String _giro;
        private String _valido;
        private int _idFolio;
        private int _idEstado;
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
        public String NombreRazonSocial
        {
            get { return _nombreRazonSocial; }
            set { _nombreRazonSocial = value; }
        }
        public String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public String Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
       
        public int IdComuna
        {
            get { return _idComuna; }
            set { _idComuna = value; }
        }
        public int IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }
        public String Giro
        {
            get { return _giro; }
            set { _giro = value; }
        }
        public int IdFolio
        {
            get { return _idFolio; }
            set { _idFolio = value; }
        }
        public String Valido
        {
            get { return _valido; }
            set { _valido = value; }
        }

        public int IdEstado
        {
            get { return _idEstado; }
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

        #region Contructores

        private void Init()
        {
            _rut = 0;
            _dv = ' ';
            _nombreRazonSocial = String.Empty;
            _direccion = String.Empty;
            _correo = String.Empty;
            _idComuna = 0;
            _idPerfil = 0;
            _valido = String.Empty;
            _idFolio = 0;
            _giro = String.Empty;
        }
        public OrganizadorBEL()
        {
            Init();
        }

        public OrganizadorBEL(int rut, char dv, String nombre, String giro, String direccion, String correo, int idComuna, int idPerfil, String valido, int idFolio)
        {
            _rut = rut;
            _dv = dv;
            _nombreRazonSocial = nombre;
            _giro = giro;
            _direccion = direccion;
            _correo = correo;
            _idComuna = idComuna;
            _idPerfil = idPerfil;
            _valido = valido;
            _idFolio = idFolio;
        }
        #endregion
    }
}

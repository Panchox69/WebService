using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ClienteDireccionesBEL
    {

        #region Atributos
        private int _rut_cliente;
        private int _id_direccion;
        private char _primaria;
        #endregion

        #region Propiedades
        public int Rut_cliente
        {
          get { return _rut_cliente; }
          set { _rut_cliente = value; }
        }
        public int Id_direccion
        {
            get { return _id_direccion; }
            set { _id_direccion = value; }
        }
        public char Primaria
        {
            get { return _primaria; }
            set { _primaria = value; }
        }
        #endregion

        #region Contrusctores
        private void Init()
        {
            _rut_cliente = 0;
            _id_direccion = 0;
            _primaria = ' ';
        }

        public ClienteDireccionesBEL()
        {
            this.Init();
        }

        public ClienteDireccionesBEL(int rut_cliente, int id_direccion, char primaria)
        {
            this._rut_cliente = rut_cliente;
            this._id_direccion = id_direccion;
            this._primaria = primaria;
        }
        #endregion
    }
}

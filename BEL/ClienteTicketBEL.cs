using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ClienteTicketBEL
    {
        #region Atributos
        private int _clienteRut;
        private int _idTicket;
        private int _cantidad;
        private String _regalo;
        private int _total;
        private String _correo;
        private int _habilitado;
        #endregion

        #region Propiedades
        public int IdTicket
        {
            get { return _idTicket; }
            set { _idTicket = value; }
        }
        public int ClienteRut
        {
            get { return _clienteRut; }
            set { _clienteRut = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        public String Regalo
        {
            get { return _regalo; }
            set { _regalo= value; }
        }
        public int Total
        {
            get { return _total; }
            set { _total= value; }
        }
        public String Correo
        {
            get { return _correo; }
            set { _correo= value; }
        }
        public int Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

        public String NombreEvento {get;set;}
        #endregion

        #region Constructores
        private void Init(){
            _clienteRut = 0;
            _idTicket = 0;
            _cantidad = 0;
            _total = 0;
            _regalo = String.Empty;
            _correo = String.Empty;
            _habilitado = 0;
        }

        public ClienteTicketBEL()
        {
            this.Init();
        }

        public ClienteTicketBEL(int clienteRut, int idTicket, int cantidad, int total,String regalo,String correo, int habilitado)
        {
            _clienteRut = clienteRut;
            _idTicket = idTicket;
            _cantidad = cantidad;
            _total = total;
            _regalo = regalo;
            _correo = correo;
            _habilitado = habilitado;
        }
        #endregion
    }
}

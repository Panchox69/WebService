using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TiposTicketBEL
    {
        #region Atributos
        private int _idTipoTicket;
        private int _idTipoAsiento;
        private int _precio;
        private int _idEvento;
        #endregion

        #region Propiedades
        public int IdTipoTicket
        {
            get { return _idTipoTicket; }
            set { _idTipoTicket = value; }
        }
        public int IdTipoAsiento
        {
            get { return _idTipoAsiento; }
            set { _idTipoAsiento = value; }
        }
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public int IdEvento
        {
            get { return _idEvento; }
            set { _idEvento = value; }
        }

        public String Descripcion
        {
            get
            {
                String desc = String.Empty;
                switch (IdTipoAsiento)
                {
                    case 1:
                        desc = "CANCHA";
                        break;
                    case 2:
                        desc = "PLATEA";
                        break;
                    case 3:
                        desc = "VIP";
                        break;
                    case 4:
                        desc = "GALERIA";
                        break;
                }
                return desc;
            }
        }
        #endregion

        #region Constructores
        private void Init(){
            _idTipoTicket = 0;
            _idTipoAsiento = 0;
            _precio = 0;
            _idEvento = 0;
        }

        public TiposTicketBEL()
        {
            this.Init();
        }

        public TiposTicketBEL(int idTipoTicket, int idTipoAsiento,int precio,int idEvento)
        {
            this._idTipoTicket = idTipoTicket;
            this._idTipoAsiento = idTipoAsiento;
            this._precio = precio;
            this._idEvento = idEvento;
        }
        #endregion
    }
}

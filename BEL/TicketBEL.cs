using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class TicketBEL
    {
        #region Atributos
        private int _idTicket;
        private int _idEvento;
        private int _idTipoTicket;
        private int _idAsiento;
        #endregion

        #region Propiedades
        public int IdTicket
        {
            get { return _idTicket; }
            set { _idTicket = value; }
        }
        public int IdEvento
        {
            get { return _idEvento; }
            set { _idEvento = value; }
        }
        public int IdTipoTicket
        {
            get { return _idTipoTicket; }
            set { _idTipoTicket = value; }
        }
        public int IdAsiento
        {
            get { return _idAsiento; }
            set { _idAsiento = value; }
        }
        #endregion

        #region Constructores
        private void Init(){
            _idAsiento = 0;
            _idTipoTicket = 0;
            _idTicket = 0;
            _idEvento = 0;
        }

        public TicketBEL()
        {
            this.Init();
        }

        public TicketBEL(int idTicket, int idTipoTicket, int idAsiento, int idEvento)
        {
            this._idAsiento = idAsiento;
            this._idTicket = idTicket;
            this._idTipoTicket = idTipoTicket;
            this._idEvento = idEvento;
        }
        #endregion
    }
}

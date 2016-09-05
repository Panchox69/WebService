using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class AsientoBEL
    {
        #region Atributos
        private int _idAsiento;
        private int _numero;
        private String _estado;
        private int _idEvento;
        private int _idTipoAsiento;
        #endregion

        #region Propiedades
        public int IdAsiento
        {
            get { return _idAsiento; }
            set { _idAsiento = value; }
        }
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public String Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public int IdEvento
        {
            get { return _idEvento; }
            set { _idEvento = value; }
        }
        public int IdTipoAsiento
        {
            get { return _idTipoAsiento; }
            set { _idTipoAsiento = value; }
        }

        public String TipoAsiento
        {
            get
            {
                String ret = String.Empty;
                switch (IdTipoAsiento)
                {
                    case 1:
                        ret = "CANCHA";
                        break;
                    case 2:
                        ret = "PLATEA";
                        break;
                    case 3:
                        ret = "VIP";
                        break;
                    case 4:
                        ret = "GALERIA";
                        break;
                }
                return ret;
            }
        }
        #endregion

        #region Constructores
        private void Init(){
            _idAsiento = 0;
            _numero = 0;
            _estado = String.Empty;
            _idEvento = 0;
            _idTipoAsiento = 0;
        }

        public AsientoBEL()
        {
            this.Init();
        }

        public AsientoBEL(int idAsiento, int numero, String estado, int idEvento, int idTipoAsiento)
        {
            this._idAsiento = idAsiento;
            this._numero = numero;
            this._estado = estado;
            this._idEvento = idEvento;
            this._idTipoAsiento = idTipoAsiento;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class EventoBEL
    {
        #region Atributos
        private int _idEvento;
        private int _asientosDisponibles;
        private String _descripcion;
        private int _idTipoEvento;
        private int _idRecinto;
        private int _rut;
        private String _estado;
        private String _nombre;
        private String _imagen;
        private DateTime _fecha;

     
        #endregion

        #region Propiedades
        public int IdEvento
        {
            get { return _idEvento; }
            set { _idEvento = value; }
        }

        public int AsientosDisponibles
        {
            get { return _asientosDisponibles; }
            set { _asientosDisponibles = value; }
        }

        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int IdTipoEvento
        {
            get { return _idTipoEvento; }
            set { _idTipoEvento = value; }
        }

        public int IdRecinto
        {
            get { return _idRecinto; }
            set { _idRecinto = value; }
        }

        public int Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }

        public String Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public String Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }
        public String EstadoDesc
        {
            get
            {
                String nom = String.Empty;
                if (Estado.Equals("E"))
                {
                    nom = "Eliminado";
                }
                else
                {
                    nom = "Activo";
                }
                return nom;
            }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha= value; }
        }
        public String NombreRecinto { get; set; }
        #endregion

        #region Constructores
        private void Init()
        {
            _idEvento = 0;
            _asientosDisponibles = 0;
            _descripcion = String.Empty;
            _idTipoEvento = 0;
            _idRecinto = 0;
            _rut = 0;
            _estado = String.Empty;
            _nombre = String.Empty;
            _imagen = String.Empty;
            _fecha = DateTime.Now;
        }

        public EventoBEL()
        {
            this.Init();
        }

        public EventoBEL(int IdEvento, int AsientosDisponibles, String Descripcion, int IdTipoEvento, int IdReciento, int Rut, string Estado, String Nombre,String imagen,DateTime fecha)
        {
            this._idEvento = IdEvento;
            this._asientosDisponibles = AsientosDisponibles;
            this._descripcion = Descripcion;
            this._idTipoEvento = IdTipoEvento;
            this._idRecinto = IdReciento;
            this._rut = Rut;
            this._estado = Estado;
            this._nombre = Nombre;
            this._imagen = imagen;
            this._fecha = fecha;
        }
        #endregion
    }
}

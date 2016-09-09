using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ImagenesBEL
    {
        #region Atributos
        private int _id_producto;
        private String _nombre;
        private String _descripcion;
        private int _orden;
        private DateTime _fecha;
        private String _ubicacion;
        #endregion

        #region Propiedades
        public int Id_producto
        {
          get { return _id_producto; }
          set { _id_producto = value; }
        }
        public String Nombre
        {
          get { return _nombre; }
          set { _nombre = value; }
        }
        public String Descripcion
        {
          get { return _descripcion; }
          set { _descripcion = value; }
        }
        public int Orden
        {
          get { return _orden; }
          set { _orden = value; }
        }        
        public DateTime Fecha
        {
          get { return _fecha; }
          set { _fecha = value; }
        }
        public String Ubicacion
        {
          get { return _ubicacion; }
          set { _ubicacion = value; }
        }
        #endregion

        #region Contrusctores
        private void Init()
        {
            _id_producto = 0;
            _nombre = String.Empty;;
            _descripcion = String.Empty;;
            _orden = 0;
            _fecha = DateTime.MinValue;
            _ubicacion = String.Empty;;
        }

        public ImagenesBEL()
        {
            this.Init();
        }

        public ImagenesBEL(int id_producto, String nombre, String descripcion, int orden, DateTime fecha, String ubicacion)
        {
            //this._id_direccion = id_direccion;
            this._id_producto = id_producto;
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._orden = orden;
            this._fecha = fecha;
            this._ubicacion = ubicacion;
        }
        #endregion
    }
}


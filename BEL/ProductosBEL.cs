using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEL
{
    public class ProductosBEL
    {
        #region Atributos
        private int _id_producto;        
        private int _rut_productor;
        private int _id_tipo_producto;
        private int _oferta;
        private String _descripcion_elaboracion;
        private int _id_direccion;
        private String _zona_cultivo;
        private int _stock;
        private int _precio_unitario;
        private int _id_medida;
        private int _id_tipo_cultivo;
        private int _activo;  
        #endregion

        #region Propiedades
        public int Id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }
        public int Rut_productor
        {
          get { return _rut_productor; }
          set { _rut_productor = value; }
        }
        public int Id_tipo_producto
        {
          get { return _id_tipo_producto; }
          set { _id_tipo_producto = value; }
        }
        public int Oferta
        {
          get { return _oferta; }
          set { _oferta = value; }
        }
        public String Descripcion_elaboracion
        {
          get { return _descripcion_elaboracion; }
          set { _descripcion_elaboracion = value; }
        }
        public int Id_direccion
        {
          get { return _id_direccion; }
          set { _id_direccion = value; }
        }
        public String Zona_cultivo
        {
          get { return _zona_cultivo; }
          set { _zona_cultivo = value; }
        }
        public int Stock
        {
          get { return _stock; }
          set { _stock = value; }
        }
        public int Precio_unitario
        {
          get { return _precio_unitario; }
          set { _precio_unitario = value; }
        }
        public int Id_medida
        {
          get { return _id_medida; }
          set { _id_medida = value; }
        }
        public int Id_tipo_cultivo
        {
          get { return _id_tipo_cultivo; }
          set { _id_tipo_cultivo = value; }
        }
        public int Activo
        {
          get { return _activo; }
          set { _activo = value; }
        }
        public String Ubicacion { get; set; }
        #endregion

        #region Contructores

        private void Init()
        {
            _rut_productor = 0;
            _id_tipo_producto = 0;
            _oferta = 0;
            _descripcion_elaboracion = String.Empty;
            _id_direccion = 0;
            _zona_cultivo = String.Empty;
            _stock = 0;
            _precio_unitario = 0;
            _id_medida = 0;
            _id_tipo_cultivo = 0;
            _activo = 0;            
        }
        public ProductosBEL()
        {
            Init();
        }

        public ProductosBEL(int rut_productor, int id_tipo_producto, int oferta, String descripcion_elaboracion, int id_direccion, String zona_cultivo, int stock, int precio_unitario, int id_medida, int id_tipo_cultivo, int activo)
        {
            this._rut_productor = rut_productor;
            this._id_tipo_producto =id_tipo_producto;
            this._oferta = oferta;
            this._descripcion_elaboracion = descripcion_elaboracion;
            this._id_direccion = id_direccion;
            this._zona_cultivo = zona_cultivo;
            this._stock = stock;
            this._precio_unitario = precio_unitario;
            this._id_medida = id_medida;
            this._id_tipo_cultivo = id_tipo_cultivo;
            this._activo = activo;            
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEL;

namespace BLL
{
    public class ProductorBLL
    {
        public void registroProductor(ProductorBEL productor)
        {
            fru.WebServicePruebaSoapClient servicio = new fru.WebServicePruebaSoapClient();
            servicio.Productor_Ins(productor.Rut, productor.Dv, productor.Nombre, productor.Apellido, productor.Sexo, productor.Id_direccionparticular, productor.Celular, productor.Correo, productor.Id_direccionnegocio, productor.Mismadireccion);
            
            //Falta webservice
            //servicio.registrarProductor(productor.Rut, productor.Dv, productor.Nombre, productor.Giro, productor.Sexo, productor.Id_direccionparticular, productor.Celular, productor.Correo, productor.Id_comuna, productor.Id_direccionnegocio, productor.Mismadireccion);
            
            //servicio.registrarUsuario(perBel.Usuario, perBel.Contrasena, perBel.IdTipoPerfil);
            //UsuarioBEL usuario = buscarUsuarios(perBel.Usuario, perBel.Contrasena);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALC;

namespace BLL
{
    public class ConexionBLL
    {
        private static Entidades conexionETicket;

        public static Entidades ConexionETicket
        {
            get
            {
                if (conexionETicket == null)
                {
                    conexionETicket = new Entidades();
                }

                return conexionETicket;
            }
        }

        public static Entidades getConexion()
        {
            Entidades conexion = new Entidades();
            return conexion;
        }
    }
}

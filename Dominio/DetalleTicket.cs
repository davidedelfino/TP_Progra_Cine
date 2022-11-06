using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Dominio
{
    internal class DetalleTicket
    {
        public double Costo { get; set; }
        public Butaca Butaca { get; set; }
        public Funcion Funcion { get; set; }

        public DetalleTicket(double costo, Butaca butaca, Funcion funcion)   
        {
            Costo = costo;
            Funcion = funcion;
            Butaca = butaca;
        }

        public DetalleTicket()
        {
            Costo = 0;
            Funcion = null;
            Butaca = null;
        }
    }
}

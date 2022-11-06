using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Dominio
{
    internal class Ticket
    {
        public List<DetalleTicket> Detalles { get; set; }
        public TipoPago Pago { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public void AgregarDetalle(DetalleTicket detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int posicion)
        {
            Detalles.RemoveAt(posicion);
        }

        public int CantidadDetalles()
        {
            return Detalles.Count;
        }

        public Ticket()
        {
            Detalles = new List<DetalleTicket>();
        }
    }

    
}

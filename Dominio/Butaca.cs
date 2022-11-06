using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Dominio
{
    internal class Butaca
    {

        public int IdSala { get; set; }
        public int Numero { get; set; }

        public Butaca()
        {
            IdSala = 0;
            Numero = 0;
        }

        public Butaca(int idSala, int numero)
        {
            IdSala = idSala;
            Numero = numero;    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Dominio
{
    internal class TipoSala
    {
        public int idTipoSala { get; set; }

        public TipoSala(int idTipoSala)
        {
            this.idTipoSala = idTipoSala;
        }

        public TipoSala()
        {
            idTipoSala = 0;
        }
    }
}

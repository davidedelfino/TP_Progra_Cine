using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Dominio
{
    internal class Pelicula
    {
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public TipoPelicula TipoPelicula { get; set; }

        public Pelicula()
        {
            Titulo = string.Empty;
            Duracion = 0;
            TipoPelicula = null;
        }
    }
}

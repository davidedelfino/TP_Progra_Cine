using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Dominio
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Dni { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public long Telefono { get; set; }

        public Cliente(string nombre,string apellido, long dni, string email, string calle, int altura, long telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            Calle = calle;
            Altura = altura;
            Telefono = telefono;    
        }

        public Cliente()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Dni = 0;
            Email = string.Empty;
            Calle = string.Empty;
            Altura = 0;
            Telefono = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBase.Csharp.Entidades
{
    public class Libro
    {
        public int ISBN { get; set; }
        public int idGenero { get; set; }
        public string titulo { get; set; }
        public DateTime publicacion { get; set; }
        public int calificacion { get; set; }
    }
}
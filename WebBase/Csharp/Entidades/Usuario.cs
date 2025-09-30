using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebBase.Csharp.Entidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string apodo { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
       
    }
}
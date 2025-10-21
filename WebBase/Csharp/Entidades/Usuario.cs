using System.ComponentModel.DataAnnotations;
namespace WebBase.Csharp.Entidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }          // <-- agregado/asegurado

        [Required, StringLength(50)]
        public string apodo { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100)]
        public string email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 6)]
        public string contrasena { get; set; } = string.Empty;
    }
}

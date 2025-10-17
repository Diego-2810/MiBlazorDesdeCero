using System.Data;
using Dapper;
using MySqlConnector;
using WebBase.Csharp.Entidades;

namespace WebBase.Csharp.dapper
{
    public class AdoDapper : IAdo
    {
        private readonly string _cs;
        public AdoDapper(string cs) => _cs = cs;

        private IDbConnection Conn() => new MySqlConnection(_cs);

        // ====== USUARIOS ======
        public void AltaUsuario(Usuario usuario)
        {
            const string sql = @"
                INSERT INTO usuarios (apodo, email, contrasena)
                VALUES (@apodo, @email, @contrasena);";
            using var db = Conn();
            db.Execute(sql, usuario);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            const string sql = "SELECT idUsuario, apodo, email, contrasena FROM usuarios ORDER BY idUsuario DESC;";
            using var db = Conn();
            return db.Query<Usuario>(sql).ToList();
        }

        public Usuario? ObtenerUsuario(int id)
        {
            const string sql = "SELECT idUsuario, apodo, email, contrasena FROM usuarios WHERE idUsuario = @id LIMIT 1;";
            using var db = Conn();
            return db.QueryFirstOrDefault<Usuario>(sql, new { id });
        }

        // ====== LIBROS/GENEROS (dejados como TODO para más tarde) ======
        public void AltaGenero(Genero genero) => throw new NotImplementedException();
        public List<Genero> ObtenerGenero() => throw new NotImplementedException();
        public Genero? ObtenerGenero(int id) => throw new NotImplementedException();

        public void AltaLibro(Libro libro) => throw new NotImplementedException();
        public List<Libro> ObtenerLibros() => throw new NotImplementedException();
        public Libro? ObtenerLibro(int id) => throw new NotImplementedException();
    }
}

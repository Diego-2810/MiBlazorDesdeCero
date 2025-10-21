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

        // Genero
        public void AltaGenero(Genero genero)
        {
            const string sql = "INSERT INTO Genero(idGenero, genero) VALUES (@idGenero, @genero);";
            using var db = Conn();
            db.Execute(sql, genero);
        }

        public List<Genero> ObtenerGenero()
        {
            const string sql = "SELECT idGenero, genero FROM Genero ORDER BY genero;";
            using var db = Conn();
            return db.Query<Genero>(sql).ToList();
        }

        public Genero? ObtenerGenero(int id)
        {
            const string sql = "SELECT idGenero, genero FROM Genero WHERE idGenero=@id LIMIT 1;";
            using var db = Conn();
            return db.QueryFirstOrDefault<Genero>(sql, new { id });
        }

        // Libro (ajusta tipos según tu DDL)
        public void AltaLibro(Libro libro)
        {
            const string sql = @"INSERT INTO Libro(ISBN, idAutor, idGenero, titulo, publicacion, calificacion)
                                VALUES (@ISBN, @idAutor, @idGenero, @titulo, @publicacion, @calificacion);";
            using var db = Conn();
            db.Execute(sql, libro);
        }

        public List<Libro> ObtenerLibros()
        {
            const string sql = @"SELECT ISBN, idAutor, idGenero, titulo, publicacion, calificacion FROM Libro
                                ORDER BY publicacion DESC;";
            using var db = Conn();
            return db.Query<Libro>(sql).ToList();
        }

        public Libro? ObtenerLibro(int id)
        {
            const string sql = @"SELECT ISBN, idAutor, idGenero, titulo, publicacion, calificacion
                                FROM Libro WHERE ISBN = @id LIMIT 1;";
            using var db = Conn();
            return db.QueryFirstOrDefault<Libro>(sql, new { id });
        }

    }
}

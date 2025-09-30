using WebBase.Csharp.Entidades;

namespace WebBase.Csharp.dapper;

public interface IAdo
{
    void AltaGenero(Genero genero);
    List<Genero> ObtenerGenero();
    Genero? ObtenerGenero(int id);
    void AltaLibro(Libro libro);
    List<Libro> ObtenerLibros();
    Libro? ObtenerLibro(int id);
    void AltaUsuario(Usuario usuario);
    List<Usuario> ObtenerUsuarios();
    Usuario? ObtenerUsuario(int id);

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBase.Csharp.Entidades;
using MySql.Data;
using MySqlConnector;
using System.Data;
using Dapper;

namespace WebBase.Csharp.dapper
{
    public class AdoDapper : IAdo
    {
        private readonly IDbConnection _conexion;

        public AdoDapper(IDbConnection conexion) => this._conexion = conexion;

        //Este constructor usa por defecto la cadena para un conector MySQL
        public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);

        public void AltaGenero(Genero genero)
        {
            string _queryAltaGenero =
                @"INSERT INTO Genero (idGenero, genero) VALUES (@unIdGenero,@unGenero)";
            _conexion.Execute(_queryAltaGenero, new { unIdGenero = genero.idGenero, unGenero = genero.genero });
        }

        public void AltaLibro(Libro libro)
        {
            throw new NotImplementedException();
        }

        public void AltaUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Genero> ObtenerGenero()
        {
            throw new NotImplementedException();
        }

        public List<Libro> ObtenerLibros()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            throw new NotImplementedException();
        }

        public Genero? ObtenerGenero(int id)
        {
            throw new NotImplementedException();
        }

        public Libro? ObtenerLibro(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario? ObtenerUsuario(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
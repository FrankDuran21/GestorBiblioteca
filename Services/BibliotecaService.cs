using GestorBiblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestorBiblioteca.Services
{
    public class BibliotecaService
    {
        private List<Libro> libros = new List<Libro>();

        public List<Libro> ObtenerLibros()
        {
            return libros.OrderBy(l => l.Id).ToList();
        }

        public bool ExisteLibro(int id)
        {
            return libros.Any(l => l.Id == id);
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public bool ActualizarLibro(Libro libroActualizado)
        {
            var libro = libros.FirstOrDefault(l => l.Id == libroActualizado.Id);

            if (libro == null)
                return false;

            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.Anio = libroActualizado.Anio;
            libro.Disponible = libroActualizado.Disponible;

            return true;
        }

        public bool EliminarLibro(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
                return false;

            libros.Remove(libro);
            return true;
        }
    }
}
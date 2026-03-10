using GestorBiblioteca.Models;
using System.ComponentModel;
using System.Linq;

namespace GestorBiblioteca.Services
{
    public class BibliotecaService
    {
        public BindingList<Libro> Libros { get; set; } = new BindingList<Libro>();
        public BindingList<Usuario> Usuarios { get; set; } = new BindingList<Usuario>();
        public BindingList<Prestamo> Prestamos { get; set; } = new BindingList<Prestamo>();

        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
        }

        public BindingList<Libro> ObtenerLibros()
        {
            return Libros;
        }

        public bool ExisteLibro(int id)
        {
            return Libros.Any(l => l.Id == id);
        }

        public bool EliminarLibro(int id)
        {
            var libro = Libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
                return false;

            Libros.Remove(libro);
            return true;
        }

        public bool ActualizarLibro(Libro libroActualizado)
        {
            var libro = Libros.FirstOrDefault(l => l.Id == libroActualizado.Id);

            if (libro == null)
                return false;

            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.Anio = libroActualizado.Anio;
            libro.Disponible = libroActualizado.Disponible;

            return true;
        }
    }
}
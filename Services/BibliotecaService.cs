using GestorBiblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestorBiblioteca.Services
{
    public class BibliotecaService
    {
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
        }

        public List<Libro> ObtenerLibros()
        {
            return Libros;
        }

        public void EliminarLibro(int id)
        {
            var libro = Libros.FirstOrDefault(l => l.Id == id);
            if (libro != null)
            {
                Libros.Remove(libro);
            }
        }

        public void ActualizarLibro(Libro libroActualizado)
        {
            var libro = Libros.FirstOrDefault(l => l.Id == libroActualizado.Id);

            if (libro != null)
            {
                libro.Titulo = libroActualizado.Titulo;
                libro.Autor = libroActualizado.Autor;
                libro.Anio = libroActualizado.Anio;
                libro.Disponible = libroActualizado.Disponible;
            }
        }
    }
}
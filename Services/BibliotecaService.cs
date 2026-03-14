using GestorBiblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestorBiblioteca.Services
{
    public class BibliotecaService
    {
        // ==============================
        // LISTAS DE DATOS
        // ==============================

        private List<Libro> libros = new List<Libro>();
        private List<Usuario> usuarios = new List<Usuario>();


        // ==============================
        // CRUD DE LIBROS
        // ==============================

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


        // ==============================
        // CRUD DE USUARIOS
        // ==============================

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios.OrderBy(u => u.Id).ToList();
        }

        public bool ExisteUsuario(int id)
        {
            return usuarios.Any(u => u.Id == id);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool ActualizarUsuario(Usuario usuarioActualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioActualizado.Id);

            if (usuario == null)
                return false;

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Correo = usuarioActualizado.Correo;
            usuario.Activo = usuarioActualizado.Activo;

            return true;
        }

        public bool EliminarUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return false;

            usuarios.Remove(usuario);
            return true;
        }
    }
}
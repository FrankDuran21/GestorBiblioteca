using GestorBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorBiblioteca.Services
{
    public class BibliotecaService
    {
        private List<Libro> libros = new List<Libro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Prestamo> prestamos = new List<Prestamo>();

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

        // ==============================
        // CRUD DE PRÉSTAMOS
        // ==============================

        public List<Prestamo> ObtenerPrestamos()
        {
            return prestamos.OrderBy(p => p.Id).ToList();
        }

        public bool ExistePrestamo(int id)
        {
            return prestamos.Any(p => p.Id == id);
        }

        public bool RegistrarPrestamo(Prestamo prestamo)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == prestamo.IdUsuario);
            var libro = libros.FirstOrDefault(l => l.Id == prestamo.IdLibro);

            if (usuario == null || libro == null)
                return false;

            if (!usuario.Activo)
                return false;

            if (!libro.Disponible)
                return false;

            prestamos.Add(prestamo);
            libro.Disponible = false;

            libro.VecesPrestado++;
            usuario.CantidadPrestamos++;

            return true;
        }

        public bool RegistrarDevolucion(int idPrestamo)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.Id == idPrestamo);

            if (prestamo == null)
                return false;

            if (prestamo.Estado == "Devuelto")
                return false;

            prestamo.Estado = "Devuelto";
            prestamo.FechaDevolucion = DateTime.Now;

            var libro = libros.FirstOrDefault(l => l.Id == prestamo.IdLibro);
            if (libro != null)
                libro.Disponible = true;

            return true;
        }

        public List<Prestamo> ObtenerPrestamosPorUsuario(int idUsuario)
        {
            return prestamos
                .Where(p => p.IdUsuario == idUsuario)
                .OrderBy(p => p.Id)
                .ToList();
        }

        // ==============================
        // DATOS PARA GRÁFICAS
        // ==============================

        public List<Libro> ObtenerLibrosMasPrestados()
        {
            return libros
                .Where(l => l.VecesPrestado > 0)
                .OrderByDescending(l => l.VecesPrestado)
                .Take(5)
                .ToList();
        }

        public List<Usuario> ObtenerUsuariosMasActivos()
        {
            return usuarios
                .Where(u => u.CantidadPrestamos > 0)
                .OrderByDescending(u => u.CantidadPrestamos)
                .Take(5)
                .ToList();
        }

    }
}
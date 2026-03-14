namespace GestorBiblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = "";

        public string Autor { get; set; } = "";

        public int Anio { get; set; }

        public bool Disponible { get; set; }

        public int VecesPrestado { get; set; }

    }
}
using ApiLibros.Models;

namespace ApiLibros.Data
{
    public static class LibroRepositorio
    {
        private static List<Libro> libros = new List<Libro>();
        private static int nextId = 1;

        public static List<Libro> ObtenerTodos() => libros;

        public static Libro? ObtenerPorId(int id) => libros.FirstOrDefault(l => l.Id == id);

        public static void Agregar(Libro libro)
        {
            libro.Id = nextId++;
            libros.Add(libro);
        }

        public static void Actualizar(Libro libro)
        {
            var index = libros.FindIndex(l => l.Id == libro.Id);
            if (index != -1)
                libros[index] = libro;
        }

        public static void Eliminar(int id)
        {
            var libro = ObtenerPorId(id);
            if (libro != null)
                libros.Remove(libro);
        }
    }
}

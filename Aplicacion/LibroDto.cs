using System;

namespace Biblioteca.Aplicacion
{
    public class LibroDto
    {
        public int LibroId { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string Editorial { get; set; }
        public string LibroGuid { get; set; }
    }
}

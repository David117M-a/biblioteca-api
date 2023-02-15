using AutoMapper;
using Biblioteca.Modelo;

namespace Biblioteca.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Libro, LibroDto>();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using AutoMapper;
using Biblioteca.Modelo;
using Biblioteca.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Aplicacion
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<LibroDto>>
        {

        }

        public class Manejador : IRequestHandler<ListaAutor, List<LibroDto>>
        {
            private readonly ContextoLibro _context;
            private readonly IMapper _mapper;
            public Manejador(ContextoLibro context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<LibroDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var libros = await _context.Libro.ToListAsync();
                var libroDto = _mapper.Map<List<Libro>, List<LibroDto>>(libros);
                return libroDto;
            }
        }
    }
}

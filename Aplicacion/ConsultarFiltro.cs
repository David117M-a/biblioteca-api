using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using Biblioteca.Persistencia;
using System.Linq;
using Biblioteca.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Aplicacion
{
    public class ConsultarFiltro
    {
        public class LibroUnico : IRequest<LibroDto>
        {
            public string LibroGuid { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroDto>
        {
            private readonly ContextoLibro _context;
            public readonly IMapper _mapper;
            public Manejador(ContextoLibro context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<LibroDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _context.Libro.Where(p => p.LibroGuid == request.LibroGuid).FirstOrDefaultAsync();

                if (libro == null)
                {
                    throw new Exception("No se encuentra el autor");
                }

                var libroDto = _mapper.Map<Libro, LibroDto>(libro);
                return libroDto;
            }
        }
    }
}

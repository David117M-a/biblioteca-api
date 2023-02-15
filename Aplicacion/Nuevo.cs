using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using Biblioteca.Persistencia;
using Biblioteca.Modelo;
using FluentValidation;

namespace Biblioteca.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Autor { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public string Editorial { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Nombre).NotEmpty();
                RuleFor(p => p.Autor).NotEmpty();
                RuleFor(p => p.FechaPublicacion).NotEmpty();
                RuleFor(p => p.Editorial).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoLibro _context;
            public Manejador(ContextoLibro context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new Libro
                {
                    Nombre = request.Nombre,
                    Autor = request.Autor,
                    Editorial = request.Editorial,
                    FechaPublicacion = request.FechaPublicacion,
                    LibroGuid = Convert.ToString(Guid.NewGuid())
                };
                _context.Libro.Add(autorLibro);
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el autor del libro");
            }
        }
    }
}

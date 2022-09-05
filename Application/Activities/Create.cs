
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest 
        {
            public Activity Activity {get; set;}
        }




        public class Handler : IRequestHandler<Command>
        {
        private readonly DatabaseContext _context;
            public Handler(DatabaseContext context)
            {
            _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();

                /* Let the method caller know that the command has been executed */
                return Unit.Value;
            }
        }

    }
}
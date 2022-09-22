

using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                /* Fetch the activity from the database. No error checking at this stage of developemnt  */
                var activity = await _context.Activities.FindAsync(request.Id);

                /* Remove the activity from memory and track changes */
                _context.Remove(activity);

                /* Save and write changes to the database */
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }

    }
}
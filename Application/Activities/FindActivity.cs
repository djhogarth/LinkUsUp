
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class FindActivity
    {

    public class Query : IRequest<Activity> 
    {
        public Guid Id { get; set; }

    }

        public class Handler : IRequestHandler<Query, Activity>
        {
        private readonly DatabaseContext _context;
        
        public Handler(DatabaseContext context)
        {
            _context = context;
        }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.FindAsync(request.Id);
            }
        }

    }
}
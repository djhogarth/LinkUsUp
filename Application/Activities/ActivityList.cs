
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class ActivityList
    {
        public class Query : IRequest<List<Activity>> {}
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
        private readonly DatabaseContext _context;
            public Handler(DatabaseContext context)
            {
            _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }


    }
}
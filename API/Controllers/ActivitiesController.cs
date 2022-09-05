
using Domain;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IMediator _mediator;
        
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;            
        }

        [HttpGet]

        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _mediator.Send(new ActivityList.Query());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new FindActivity.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity (Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
        }

    }
}
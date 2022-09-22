
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

        [HttpPut("{id}")]

        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            /*The activity from the body of the request won't necessariliy contain
             the correct ID, therefore we pass it the root parameter's ID before it is
             sent to the handler */
            activity.Id = id;

            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }

    }
}
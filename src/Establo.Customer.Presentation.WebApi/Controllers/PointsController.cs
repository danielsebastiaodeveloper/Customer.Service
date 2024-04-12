using Core.Application.Features.PointsTransaction.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        // Implement the PointsController using the MediatR library and best practices of RESTful APIs
        private readonly IMediator mediator;

        public PointsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] InsertPointCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Created();

        }

    }
}

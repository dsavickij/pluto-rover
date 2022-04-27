using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlumGuide.Exercises.PlutoRover.Features.Movement;
using PlumGuide.Exercises.PlutoRover.SDK.DTOs;
using PlumGuide.Exercises.PlutoRover.SDK.Result;

namespace PlumGuide.Exercises.PlutoRover.Controllers;

[ApiController]
[Route("pluto-rover")]
public class PlutoRoverController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlutoRoverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("move")]
    public async Task<OperationResult<PositionDTO>> MoveAsync([FromBody] string commandSequence)
    {
        return await _mediator.Send(new MovementRequest { CommandSequence = commandSequence });
    }
}

using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlumGuide.Exercises.PlutoRover.Features.Movement;
using PlumGuide.Exercises.PlutoRover.SDK.DTOs;
using PlumGuide.Exercises.PlutoRover.SDK.Result;

namespace PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover;

[ExcludeFromCodeCoverage]
public class PlutoRoverEndpointHandlers
{
    public async Task<OperationResult<PositionDTO>> MovementAsync(
        [FromBody] string commandSequence, [FromServices] IMediator mediator)
    {
        return await mediator.Send(new MovementRequest { CommandSequence = commandSequence });
    }
}

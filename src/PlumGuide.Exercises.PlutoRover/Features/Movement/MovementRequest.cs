using System.Diagnostics.CodeAnalysis;
using MediatR;
using PlumGuide.Exercises.PlutoRover.SDK.DTOs;
using PlumGuide.Exercises.PlutoRover.SDK.Result;

namespace PlumGuide.Exercises.PlutoRover.Features.Movement;

[ExcludeFromCodeCoverage]
public class MovementRequest : IRequest<OperationResult<PositionDTO>>
{
    public string CommandSequence { get; set; } = string.Empty;
}

using MediatR;
using PlumGuide.Exercises.PlutoRover.Common;
using PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;
using PlumGuide.Exercises.PlutoRover.SDK.DTOs;
using PlumGuide.Exercises.PlutoRover.SDK.Result;

namespace PlumGuide.Exercises.PlutoRover.Features.Movement;

public class MovementRequestHandler : OperationResults, IRequestHandler<MovementRequest, OperationResult<PositionDTO>>
{
    private readonly IRover _rover;

    public MovementRequestHandler(IRover rover) => _rover = rover;

    public async Task<OperationResult<PositionDTO>> Handle(MovementRequest request, CancellationToken cancellationToken)
    {
        foreach (var command in GetParsedCommands(request.CommandSequence))
        {
            await _rover.MoveAsync(command);
        }

        var position = await GetCurrentRoverPositionAsync();

        return Ok(position);
    }

    private async Task<PositionDTO> GetCurrentRoverPositionAsync()
    {
        var currentPosition = await _rover.GetPositionAsync();

        return new PositionDTO
        {
            X = currentPosition.X,
            Y = currentPosition.Y,
            Direction = (char)currentPosition.Direction
        };
    }

    private IEnumerable<MovementCommand> GetParsedCommands(string commandSequence)
    {
        foreach (MovementCommand command in commandSequence.ToUpperInvariant())
        {
            yield return Enum.IsDefined(command)
                ? command
                : throw new ArgumentException($"Command '{(char)command}' is not valid");
        }
    }
}

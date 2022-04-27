using MediatR;
using PlumGuide.Exercises.PlutoRover.Common;
using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
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
            await ExecuteMovementCommandAsync(command);
        }

        return Ok(await GetCurrentRoverPositionAsync());
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

    private async Task<Position> ExecuteMovementCommandAsync(MovementCommand command)
    {
        return command switch
        {
            MovementCommand.MoveForward => await _rover.MoveForwardAsync(),
            MovementCommand.MoveBackward => await _rover.MoveBackwardAsync(),
            MovementCommand.TurnLeft => await _rover.TurnLeftAsync(),
            MovementCommand.TurnRight => await _rover.TurnRightAsync(),
            _ => throw new ArgumentException($"Command '{command}' is not supoorted")
        };
    }
}

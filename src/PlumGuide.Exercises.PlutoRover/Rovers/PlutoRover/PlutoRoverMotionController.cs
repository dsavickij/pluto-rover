using Microsoft.EntityFrameworkCore;
using PlumGuide.Exercises.PlutoRover.DataAccess;
using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Features.Movement;
using PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;

namespace PlumGuide.Exercises.PlutoRover.Rovers.PlutoRover;

public class PlutoRoverMotionController : IMotionController
{
    private const int MovementIncrementSize = 1;

    private readonly PlutoRoverDbContext _ctx;

    public PlutoRoverMotionController(PlutoRoverDbContext dbcontext) => _ctx = dbcontext;

    public async Task<Position> ExecuteAsync(MovementCommand command)
    {
        var motion = command switch
        {
            MovementCommand.MoveForward => MoveForwardAsync(),
            MovementCommand.MoveBackward => MoveBackwardAsync(),
            MovementCommand.TurnLeft => TurnLeftAsync(),
            MovementCommand.TurnRight => TurnRightAsync(),
            _ => throw new NotImplementedException(),
        };

        return await motion;
    }

    public async Task<Position> MoveBackwardAsync()
    {
        var p = await GetCurrentPositionAsync();

        var newPosition = p.Direction switch
        {
            Direction.North => p with { Y = p.Y is PlutoGrid.YMin ? PlutoGrid.YMax : p.Y - MovementIncrementSize },
            Direction.East => p with { X = p.X is PlutoGrid.XMin ? PlutoGrid.XMax : p.X - MovementIncrementSize },
            Direction.West => p with { X = p.X is PlutoGrid.XMax ? PlutoGrid.XMin : p.X + MovementIncrementSize },
            Direction.South => p with { Y = p.Y is PlutoGrid.YMax ? PlutoGrid.YMin : p.Y + MovementIncrementSize },
            _ => throw new ArgumentException($"Direction '{p.Direction}' is not supported")
        };

        await SetPositionAsync(newPosition);

        return newPosition;
    }

    public async Task<Position> MoveForwardAsync()
    {
        var p = await GetCurrentPositionAsync();

        var newPosition = p.Direction switch
        {
            Direction.North => p with { Y = p.Y is PlutoGrid.YMax ? PlutoGrid.YMin : p.Y + MovementIncrementSize },
            Direction.East => p with { X = p.X is PlutoGrid.XMax ? PlutoGrid.XMin : p.X + MovementIncrementSize },
            Direction.West => p with { X = p.X is PlutoGrid.XMin ? PlutoGrid.XMax : p.X - MovementIncrementSize },
            Direction.South => p with { Y = p.Y is PlutoGrid.YMax ? PlutoGrid.YMin : p.Y - MovementIncrementSize },
            _ => throw new ArgumentException($"Direction '{p.Direction}' is not supported")
        };

        await SetPositionAsync(newPosition);

        return newPosition;
    }

    public async Task<Position> TurnLeftAsync()
    {
        var p = await GetCurrentPositionAsync();

        var newPosition = p.Direction switch
        {
            Direction.North => p with { Direction = Direction.West },
            Direction.East => p with { Direction = Direction.North },
            Direction.West => p with { Direction = Direction.South },
            Direction.South => p with { Direction = Direction.East },
            _ => throw new ArgumentException($"Direction '{p.Direction}' is not supported")
        };

        await SetPositionAsync(newPosition);

        return newPosition;
    }

    public async Task<Position> TurnRightAsync()
    {
        var p = await GetCurrentPositionAsync();

        var newPosition = p.Direction switch
        {
            Direction.North => p with { Direction = Direction.East },
            Direction.East => p with { Direction = Direction.South },
            Direction.West => p with { Direction = Direction.North },
            Direction.South => p with { Direction = Direction.West },
            _ => throw new ArgumentException($"Direction '{p.Direction}' is not supported")
        };

        await SetPositionAsync(newPosition);

        return newPosition;
    }

    private async Task<Position> GetCurrentPositionAsync() => await _ctx.Positions.AsNoTracking().SingleAsync();

    private async Task SetPositionAsync(Position position)
    {
        _ctx.Positions.Update(position);
        await _ctx.SaveChangesAsync();

        _ctx.Entry(position).State = EntityState.Detached;
    }
}

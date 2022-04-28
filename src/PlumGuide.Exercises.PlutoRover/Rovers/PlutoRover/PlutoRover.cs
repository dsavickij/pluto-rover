using Microsoft.EntityFrameworkCore;
using PlumGuide.Exercises.PlutoRover.DataAccess;
using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement;
using PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;

namespace PlumGuide.Exercises.PlutoRover.Rovers.PlutoRover;

public class PlutoRover : IRover
{
    private readonly PlutoRoverDbContext _ctx;
    private readonly IMotionController _motionController;

    public PlutoRover(PlutoRoverDbContext context, IMotionController motionController)
    {
        _ctx = context;
        _motionController = motionController;
    }

    public async Task<Position> GetPositionAsync() => await _ctx.Positions.AsNoTracking().SingleAsync();

    public async Task<Position> MoveAsync(MovementCommand command) => await _motionController.ExecuteAsync(command);
}

using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement;

namespace PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;

public interface IMotionController
{
    public Task<Position> ExecuteAsync(MovementCommand command);
}

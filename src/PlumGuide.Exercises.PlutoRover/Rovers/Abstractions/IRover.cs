using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement;

namespace PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;

public interface IRover
{
    Task<Position> GetPositionAsync();
    Task<Position> MoveAsync(MovementCommand command);
}

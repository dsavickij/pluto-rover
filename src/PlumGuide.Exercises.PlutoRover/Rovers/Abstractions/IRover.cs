using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Features.Movement;

namespace PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;

public interface IRover
{
    Task<Position> GetPositionAsync();
    Task<Position> MoveAsync(MovementCommand command);
}

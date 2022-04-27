using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;

namespace PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;

public interface IRover : IMovement
{
    Task<Position> GetPositionAsync();
}

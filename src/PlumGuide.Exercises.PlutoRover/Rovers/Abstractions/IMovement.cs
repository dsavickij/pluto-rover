using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;

namespace PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;

public interface IMovement
{
    Task<Position> MoveForwardAsync();
    Task<Position> MoveBackwardAsync();
    Task<Position> TurnLeftAsync();
    Task<Position> TurnRightAsync();
}

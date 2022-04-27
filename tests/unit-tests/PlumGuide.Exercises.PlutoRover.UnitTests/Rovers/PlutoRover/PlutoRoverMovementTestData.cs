using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Rovers.PlutoRover;
using System;
using System.Collections.Generic;

namespace PlumGuide.Exercises.PlutoRover.UnitTests.Rovers.PlutoRover;

public class PlutoRoverMovementTestData
{
    static Guid _positionId = new ("9ec8c794-fc28-4b5e-aae5-abe23e001a3a");

    public static IEnumerable<object[]> GetMoveForwardTestData()
    {
        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.North),
            new Position(_positionId, 0, 1, Direction.North)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.East),
            new Position(_positionId, 1, 0, Direction.East)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.West),
            new Position(_positionId, -1, 0, Direction.West)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.South),
            new Position(_positionId, 0, -1, Direction.South)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, PlutoGrid.YMax, Direction.North),
            new Position(_positionId, 0, PlutoGrid.YMin, Direction.North)
        };

        yield return new object[]
        {
            new Position(_positionId, PlutoGrid.XMax, 0, Direction.East),
            new Position(_positionId, PlutoGrid.XMin, 0, Direction.East)
        }
        ;
        yield return new object[]
        {
            new Position(_positionId, PlutoGrid.XMin, 0, Direction.West),
            new Position(_positionId, PlutoGrid.XMax, 0, Direction.West)
         };

        yield return new object[]
        {
            new Position(_positionId, 0, PlutoGrid.YMin, Direction.South),
            new Position(_positionId, 0, PlutoGrid.YMax, Direction.South)
        };
    }

    public static IEnumerable<object[]> GetMoveBackwardTestData()
    {
        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.North),
            new Position(_positionId, 0, -1, Direction.North)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.East),
            new Position(_positionId, -1, 0, Direction.East)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.West),
            new Position(_positionId, 1, 0, Direction.West)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.South),
            new Position(_positionId, 0, 1, Direction.South)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, PlutoGrid.YMax, Direction.North),
            new Position(_positionId, 0, PlutoGrid.YMax - 1, Direction.North)
        };

        yield return new object[]
        {
            new Position(_positionId, PlutoGrid.XMax, 0, Direction.East),
            new Position(_positionId, PlutoGrid.XMax - 1, 0, Direction.East)
        }
        ;
        yield return new object[]
        {
            new Position(_positionId, PlutoGrid.XMin, 0, Direction.West),
            new Position(_positionId, PlutoGrid.XMin + 1, 0, Direction.West)
         };

        yield return new object[]
        {
            new Position(_positionId, 0, PlutoGrid.YMin, Direction.South),
            new Position(_positionId, 0, PlutoGrid.YMin + 1, Direction.South)
        };
    }

    public static IEnumerable<object[]> GetTurnLeftTestData()
    {
        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.North),
            new Position(_positionId, 0, 0, Direction.West)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.East),
            new Position(_positionId, 0, 0, Direction.North)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.West),
            new Position(_positionId, 0, 0, Direction.South)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.South),
            new Position(_positionId, 0, 0, Direction.East)
        };
    }

    public static IEnumerable<object[]> GetTurnRightTestData()
    {
        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.North),
            new Position(_positionId, 0, 0, Direction.East)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.East),
            new Position(_positionId, 0, 0, Direction.South)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.West),
            new Position(_positionId, 0, 0, Direction.North)
        };

        yield return new object[]
        {
            new Position(_positionId, 0, 0, Direction.South),
            new Position(_positionId, 0, 0, Direction.West)
        };
    }
}

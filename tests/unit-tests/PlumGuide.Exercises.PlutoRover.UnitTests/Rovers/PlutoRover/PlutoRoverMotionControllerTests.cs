using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement;
using PlumGuide.Exercises.PlutoRover.Rovers.PlutoRover;
using System.Threading.Tasks;
using Xunit;

namespace PlumGuide.Exercises.PlutoRover.UnitTests.Rovers.PlutoRover;

public class PlutoRoverMotionControllerTests
{
    [Theory]
    [MemberData(nameof(PlutoRoverMotionControllerTestData.GetMoveForwardTestData), MemberType = typeof(PlutoRoverMotionControllerTestData))]
    public async Task When_MoveForwardCommandIsProvided_Then_MotionControllerExecutesMovementForward(
        Position startPosition, Position afterMovePosition)
    {
        // Arrange
        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        await dbContext.Positions.AddAsync(startPosition);
        await dbContext.SaveChangesAsync();

        dbContext.Entry(startPosition).State = EntityState.Detached;

        var sut = new PlutoRoverMotionController(dbContext);

        // Act
        var position = await sut.ExecuteAsync(MovementCommand.MoveForward);

        // Assert
        position.Should().Be(afterMovePosition);
    }

    [Theory]
    [MemberData(nameof(PlutoRoverMotionControllerTestData.GetMoveBackwardTestData), MemberType = typeof(PlutoRoverMotionControllerTestData))]
    public async Task When_MoveBackwardCommandIsProvided_Then_MotionControllerExecutesMovementBackward(
        Position startPosition, Position afterMovePosition)
    {
        // Arrange
        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        await dbContext.Positions.AddAsync(startPosition);
        await dbContext.SaveChangesAsync();

        dbContext.Entry(startPosition).State = EntityState.Detached;

        var sut = new PlutoRoverMotionController(dbContext);

        // Act
        var position = await sut.ExecuteAsync(MovementCommand.MoveBackward);

        // Assert
        position.Should().Be(afterMovePosition);
    }

    [Theory]
    [MemberData(nameof(PlutoRoverMotionControllerTestData.GetTurnLeftTestData), MemberType = typeof(PlutoRoverMotionControllerTestData))]
    public async Task When_TurnLeftCommandIsProvided_Then_MotionControllerExecutesTurnLeft(
        Position startPosition, Position afterMovePosition)
    {
        // Arrange
        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        await dbContext.Positions.AddAsync(startPosition);
        await dbContext.SaveChangesAsync();

        dbContext.Entry(startPosition).State = EntityState.Detached;

        var sut = new PlutoRoverMotionController(dbContext);

        // Act
        var position = await sut.ExecuteAsync(MovementCommand.TurnLeft);

        // Assert
        position.Should().Be(afterMovePosition);
    }

    [Theory]
    [MemberData(nameof(PlutoRoverMotionControllerTestData.GetTurnRightTestData), MemberType = typeof(PlutoRoverMotionControllerTestData))]
    public async Task When_TurnRightCommandIsProvided_Then_MotionControllerExecutesTurnRight(
        Position startPosition, Position afterMovePosition)
    {
        // Arrange
        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        await dbContext.Positions.AddAsync(startPosition);
        await dbContext.SaveChangesAsync();

        dbContext.Entry(startPosition).State = EntityState.Detached;

        var sut = new PlutoRoverMotionController(dbContext);

        // Act
        var position = await sut.ExecuteAsync(MovementCommand.TurnRight);

        // Assert
        position.Should().Be(afterMovePosition);
    }
}

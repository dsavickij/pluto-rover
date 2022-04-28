using AutoFixture;
using FluentAssertions;
using Moq;
using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement;
using PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;
using System.Threading.Tasks;
using Xunit;
using Rover = PlumGuide.Exercises.PlutoRover.Rovers.PlutoRover.PlutoRover;

namespace PlumGuide.Exercises.PlutoRover.UnitTests.Rovers.PlutoRover;

public class PlutoRoverTests
{
    private Fixture _fixture = new();

    [Fact]
    public async Task When_GetPositionAsyncIsCalled_Then_RoverCurrentPositionIsReturned()
    {
        // Arrange
        var motionController = new Mock<IMotionController>();

        var currentPosition = _fixture.Create<Position>();

        using var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        await dbContext.Positions.AddAsync(currentPosition);
        await dbContext.SaveChangesAsync();

        var sut = new Rover(dbContext, motionController.Object);

        // Act
        var position = await sut.GetPositionAsync();

        // Assert
        position.Should().Be(currentPosition);
    }

    [Fact]
    public async Task When_MoveForwardIsCalled_Then_MotionControllerExecutesMoveForwardCommand()
    {
        // Arrange
        var position = _fixture.Create<Position>();

        var motionController = new Mock<IMotionController>();

        motionController
            .Setup(x => x.ExecuteAsync(MovementCommand.MoveForward))
            .ReturnsAsync(position)
            .Verifiable();

        using var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        var sut = new Rover(dbContext, motionController.Object);

        // Act
        await sut.MoveAsync(MovementCommand.MoveForward);

        // Assert
        motionController.Verify();
    }

    [Fact]
    public async Task When_MoveBackwardIsCalled_Then_MotionControllerExecutesMoveBackwardCommand()
    {
        // Arrange
        var position = _fixture.Create<Position>();

        var motionController = new Mock<IMotionController>();

        motionController
            .Setup(x => x.ExecuteAsync(MovementCommand.MoveBackward))
            .ReturnsAsync(position)
            .Verifiable();

        using var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        var sut = new Rover(dbContext, motionController.Object);

        // Act
        await sut.MoveAsync(MovementCommand.MoveBackward);

        // Assert
        motionController.Verify();
    }

    [Fact]
    public async Task When_TurnLeftIsCalled_Then_MotionControllerExecutesTurnLeftCommand()
    {
        // Arrange
        var position = _fixture.Create<Position>();

        var motionController = new Mock<IMotionController>();

        motionController
            .Setup(x => x.ExecuteAsync(MovementCommand.TurnLeft))
            .ReturnsAsync(position)
            .Verifiable();

        using var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        var sut = new Rover(dbContext, motionController.Object);

        // Act
        await sut.MoveAsync(MovementCommand.TurnLeft);

        // Assert
        motionController.Verify();
    }

    [Fact]
    public async Task When_TurnRightIsCalled_Then_MotionControllerExecutesTurnRightCommand()
    {
        // Arrange
        var position = _fixture.Create<Position>();

        var motionController = new Mock<IMotionController>();

        motionController
            .Setup(x => x.ExecuteAsync(MovementCommand.TurnRight))
            .ReturnsAsync(position)
            .Verifiable();

        using var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

        var sut = new Rover(dbContext, motionController.Object);

        // Act
        await sut.MoveAsync(MovementCommand.TurnRight);

        // Assert
        motionController.Verify();
    }
}

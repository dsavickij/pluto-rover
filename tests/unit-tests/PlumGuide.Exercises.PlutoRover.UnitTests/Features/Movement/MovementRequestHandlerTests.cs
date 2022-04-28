using AutoFixture;
using FluentAssertions;
using Moq;
using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement;
using PlumGuide.Exercises.PlutoRover.Rovers.Abstractions;
using PlumGuide.Exercises.PlutoRover.SDK.DTOs;
using PlumGuide.Exercises.PlutoRover.SDK.Result;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlumGuide.Exercises.PlutoRover.UnitTests;

public class MovementRequestHandlerTests
{
    private Fixture _fixture = new Fixture();

    [Fact]
    public async Task When_ValidCommandSequenceIsSent_Then_ResponseIsNotNull()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveForwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveForward}{(char)MovementCommand.MoveForward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
    }

    [Fact]
    public async Task When_ValidCommandSequenceIsSent_Then_ResponseIsOfTypeOperationResultPositionDTO()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveForwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveForward}{(char)MovementCommand.MoveForward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().BeOfType<OperationResult<PositionDTO>>();
    }

    [Fact]
    public async Task When_ValidCommandSequenceIsSent_Then_ResponsePropertyIsSuccessIsTrue()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveForwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveForward}{(char)MovementCommand.MoveForward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task When_ValidCommandSequenceIsSent_Then_ResponseDataPropertyIsNotNull()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveForwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveForward}{(char)MovementCommand.MoveForward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task When_ValidCommandSequenceIsSent_Then_ResponseDataPropertyIsOfTypePositionDTO()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveForwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveForward}{(char)MovementCommand.MoveForward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Data.Should().BeOfType<PositionDTO>();
    }

    [Fact]
    public async Task When_ValidCommandSequenceIsSent_Then_ResponseDataPropertyValuesAreEquelToMocked()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveForwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveForward}{(char)MovementCommand.MoveForward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Data?.X.Should().Be(position.X);
        response.Data?.Y.Should().Be(position.Y);
        response.Data?.Direction.Should().Be((char)position.Direction);
    }

    [Fact]
    public async Task When_ValidMoveForwardCommandInCommandSequenceIsSent_Then_MoveForwardIsExecuted()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveForwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveForward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        rover.Verify();
        rover.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task When_ValidMoveBackwardCommandInCommandSequenceIsSent_Then_MoveBackwardIsExecuted()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.MoveBackwardAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.MoveBackward}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        rover.Verify();
        rover.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task When_ValidTurnLeftCommandInCommandSequenceIsSent_Then_TurnLeftIsExecuted()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.TurnLeftAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.TurnLeft}{(char)MovementCommand.TurnLeft}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        rover.Verify();
        rover.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task When_ValidTurnRightCommandInCommandSequenceIsSent_Then_TurnRightIsExecuted()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        rover.Setup(x => x.TurnRightAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.TurnRight}{(char)MovementCommand.TurnRight}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        rover.Verify();
        rover.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task When_ValidSeveralCommandsAreSentInCommandSequence_Then_CommandsAreExecutedCorrectlyInOrder()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var position = _fixture.Create<Position>();

        var commandExecutionSequence = new MockSequence();
        
        rover.InSequence(commandExecutionSequence)
            .Setup(x => x.TurnRightAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.InSequence(commandExecutionSequence)
            .Setup(x => x.TurnLeftAsync())
            .ReturnsAsync(position)
            .Verifiable();

        rover.Setup(x => x.GetPositionAsync())
            .ReturnsAsync(position)
            .Verifiable();

        var commandSequence = $"{(char)MovementCommand.TurnRight}{(char)MovementCommand.TurnLeft}";

        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        rover.Verify();
        rover.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task When_InvalidCommandsAreSentInCommandSequence_Then_ArgumentExceptionIsThrown()
    {
        // Arrange
        var rover = new Mock<IRover>();

        var invalidCommandSequence = "@#$%^&*";

        var request = new MovementRequest { CommandSequence = invalidCommandSequence };

        var sut = new MovementRequestHandler(rover.Object);

        // Act and assert
        var result = await sut.Awaiting(x => x.Handle(request, CancellationToken.None))
            .Should()
            .ThrowAsync<ArgumentException>();
    }
}

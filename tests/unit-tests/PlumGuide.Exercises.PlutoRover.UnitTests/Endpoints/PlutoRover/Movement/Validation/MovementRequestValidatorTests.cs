using FluentAssertions;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement;
using PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement.Validation;
using System.Linq;
using Xunit;

namespace PlumGuide.Exercises.PlutoRover.UnitTests.Features.Movement.Validation;

public class MovementRequestValidatorTests
{
    [Fact]
    public void When_ValidCommandSequenceIsValidated_Then_ThereIsNoValidationErrors()
    {
        // Arrange
        var commandSequence = $"{(char)MovementCommand.MoveForward}{(char)MovementCommand.MoveForward}";
        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestValidator();

        // Act
        var result = sut.Validate(request);
        
        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void When_EmptyCommandSequenceIsValidated_Then_ThereIsValidationError()
    {
        // Arrange
        var emptyCommandSequence = string.Empty;
        var request = new MovementRequest { CommandSequence = emptyCommandSequence };

        var sut = new MovementRequestValidator();

        // Act
        var result = sut.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.ErrorMessage == MovementRequestValidator.ErrorMessages.CommandSequenceIsNotProvided);
    }

    [Fact]
    public void When_NullCommandSequenceIsValidated_Then_ThereIsValidationError()
    {
        // Arrange
        string? emptyCommandSequence = null;
        var request = new MovementRequest { CommandSequence = emptyCommandSequence! };

        var sut = new MovementRequestValidator();

        // Act
        var result = sut.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.ErrorMessage == MovementRequestValidator.ErrorMessages.CommandSequenceIsNotProvided);
    }

    [Fact]
    public void When_CommandSequenceContainingInvalidCommandsIsValidated_Then_ThereAreValidationErrors()
    {
        // Arrange
        var invalidCommands = "$#$";
        var commandSequence = $"{(char)MovementCommand.MoveForward}" + invalidCommands;
        var request = new MovementRequest { CommandSequence = commandSequence };

        var sut = new MovementRequestValidator();

        // Act
        var result = sut.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(invalidCommands.Length);
        result.Errors.Should().Contain(
            x => invalidCommands.Any(ic => x.ErrorMessage == MovementRequestValidator.ErrorMessages.CommandIsInvalid(ic)));
    }
}

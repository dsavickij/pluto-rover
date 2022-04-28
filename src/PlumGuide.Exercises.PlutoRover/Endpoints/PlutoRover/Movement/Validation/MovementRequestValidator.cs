using FluentValidation;
using FluentValidation.Results;

namespace PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover.Movement.Validation;

public class MovementRequestValidator : AbstractValidator<MovementRequest>
{
    public static class ErrorMessages
    {
        public const string CommandSequenceIsNotProvided = "Command sequence is not provided";
        public static string CommandIsInvalid(char command) => $"Command '{command}' is invalid";
    }

    public MovementRequestValidator()
    {
        RegisterRules();
    }

    private void RegisterRules()
    {
        RuleFor(x => x.CommandSequence)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(ErrorMessages.CommandSequenceIsNotProvided)
            .NotEmpty()
            .WithMessage(ErrorMessages.CommandSequenceIsNotProvided)
            .ForEach(command => command.Custom((character, ctx) =>
            {
                if (!Enum.IsDefined((MovementCommand)char.ToUpper(character)))
                {
                    ctx.AddFailure(new ValidationFailure(
                        nameof(MovementRequest.CommandSequence),
                        ErrorMessages.CommandIsInvalid(character)));
                }
            }));
    }
}

using System.Diagnostics.CodeAnalysis;
using MediatR;
using PlumGuide.Exercises.PlutoRover.Registrations.MediatR.Behaviours;

namespace PlumGuide.Exercises.PlutoRover.Registrations.MediatR;

[ExcludeFromCodeCoverage]
public static class MediatorServiceCollectionExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}

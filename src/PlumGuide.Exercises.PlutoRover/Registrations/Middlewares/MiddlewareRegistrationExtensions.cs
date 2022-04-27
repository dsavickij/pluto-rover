using System.Diagnostics.CodeAnalysis;

namespace PlumGuide.Exercises.PlutoRover.Registrations.Middlewares;

[ExcludeFromCodeCoverage]
public static class MiddlewareRegistrationExtensions
{
    public static IApplicationBuilder UseRoverMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ValidationExceptionHandlingMiddleware>();

        return builder;
    }
}

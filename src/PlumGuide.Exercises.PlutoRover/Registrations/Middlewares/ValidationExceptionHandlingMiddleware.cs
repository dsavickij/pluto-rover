using System.Net;
using FluentValidation;
using PlumGuide.Exercises.PlutoRover.SDK.Result;

namespace PlumGuide.Exercises.PlutoRover.Registrations.Middlewares;

internal class ValidationExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var errors = ex.Errors.Select(x => new OperationError(GetCode(x.ErrorCode), x.ErrorMessage));

            await context.Response.WriteAsJsonAsync(new OperationResult(HttpStatusCode.BadRequest, errors));
        }
    }

    private HttpStatusCode GetCode(string errorCode)
    {
        return Enum.TryParse<HttpStatusCode>(errorCode, out var result)
            ? result
            : HttpStatusCode.BadRequest;
    }
}

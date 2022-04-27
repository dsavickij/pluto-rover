using System.Diagnostics.CodeAnalysis;
using System.Net;
using PlumGuide.Exercises.PlutoRover.SDK.Result;

namespace PlumGuide.Exercises.PlutoRover.Common;

[ExcludeFromCodeCoverage]
public abstract class OperationResults
{
    protected OperationResult Ok() => new (HttpStatusCode.OK);

    protected OperationResult<TResponse> Ok<TResponse>(TResponse response) => new (HttpStatusCode.OK, response);

    protected OperationResult BadRequest(OperationError error) => BadRequest(new[] { error });

    protected OperationResult BadRequest(IEnumerable<OperationError> errors) => new (HttpStatusCode.BadRequest, errors);

    protected OperationResult Forbidden() => new (HttpStatusCode.Forbidden);

    protected OperationResult NotFound() => new (HttpStatusCode.NotFound);

    protected OperationResult NotFound(string message) =>
        new (HttpStatusCode.NotFound, new OperationError(HttpStatusCode.NotFound, message));
}

[ExcludeFromCodeCoverage]
public abstract class OperationResults<TResponse> : OperationResults
    where TResponse : class
{
    protected OperationResult<TResponse> Ok(TResponse response) => new (HttpStatusCode.OK, response);
}

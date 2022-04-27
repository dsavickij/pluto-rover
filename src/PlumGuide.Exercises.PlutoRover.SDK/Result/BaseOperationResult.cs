using System.Net;

namespace PlumGuide.Exercises.PlutoRover.SDK.Result;

public interface IOperationResult
{
    IEnumerable<OperationError> Errors { get; }
    bool IsSuccess { get; }
    HttpStatusCode Code { get; }
}

public abstract record BaseOperationResult : IOperationResult
{
    protected BaseOperationResult(HttpStatusCode code, OperationError error) : this(code, new[] { error })
    {
    }

    protected BaseOperationResult(HttpStatusCode code, IEnumerable<OperationError> errors) : this(code)
    {
        Errors = errors;
    }

    protected BaseOperationResult(HttpStatusCode code)
    {
        Code = code;
        IsSuccess = code is >= HttpStatusCode.OK and < HttpStatusCode.MultipleChoices;
    }

    public IEnumerable<OperationError> Errors { get; } = Enumerable.Empty<OperationError>();

    public bool IsSuccess { get; }

    public HttpStatusCode Code { get; }
}

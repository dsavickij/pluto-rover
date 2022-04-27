using System.Net;
using System.Text.Json.Serialization;

namespace PlumGuide.Exercises.PlutoRover.SDK.Result;

public record OperationResult : BaseOperationResult
{
    public OperationResult(HttpStatusCode code) : base(code)
    {
    }

    public OperationResult(HttpStatusCode code, OperationError error) : base(code, error)
    {
    }

    [JsonConstructor]
    public OperationResult(HttpStatusCode code, IEnumerable<OperationError> errors) : base(code, errors)
    {
    }
}

public record OperationResult<T> : BaseOperationResult
{
    public OperationResult(HttpStatusCode code, T data) : base(code) => Data = data;

    public OperationResult(HttpStatusCode code, OperationError error) : base(code, error)
    {
    }

    [JsonConstructor]
    public OperationResult(HttpStatusCode code, IEnumerable<OperationError> errors) : base(code, errors)
    {
    }

    public OperationResult(HttpStatusCode code) : base(code)
    {
    }

    [JsonInclude]
    public T? Data { get; private set; }

    public static implicit operator OperationResult<T>(OperationResult result) => new(result.Code, result.Errors);
}

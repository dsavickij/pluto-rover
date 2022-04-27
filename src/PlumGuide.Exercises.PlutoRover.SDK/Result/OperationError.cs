using System.Net;

namespace PlumGuide.Exercises.PlutoRover.SDK.Result;

public record OperationError(HttpStatusCode Code, string Message)
{
}

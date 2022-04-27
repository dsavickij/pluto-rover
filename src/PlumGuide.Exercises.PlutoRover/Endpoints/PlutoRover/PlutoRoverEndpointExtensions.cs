using System.Diagnostics.CodeAnalysis;

namespace PlumGuide.Exercises.PlutoRover.Endpoints.PlutoRover;

[ExcludeFromCodeCoverage]
public static class PlutoRoverEndpointExtensions
{
    private const string ROUTE_PREFIX = "pluto-rover";
    private const string ENDPOINT_GROUP = "PlutoRover";

    private static readonly PlutoRoverEndpointHandlers _handlers = new ();

    public static void AddPlutoRoverEndpoints(this WebApplication app)
    {
        app.MapPost($"{ROUTE_PREFIX}/move", _handlers.MovementAsync).WithTags(ENDPOINT_GROUP);
    }
}

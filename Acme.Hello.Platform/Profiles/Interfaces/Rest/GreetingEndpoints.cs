using Acme.Hello.Platform.Profiles.Domain.Services;
using Acme.Hello.Platform.Profiles.Interfaces.Rest.Assemblers;
using Acme.Hello.Platform.Profiles.Interfaces.Rest.Resources;

namespace Acme.Hello.Platform.Profiles.Interfaces.Rest;

public static class GreetingEndpoints
{
    public static IEndpointRouteBuilder MapGreetingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/greetings")
            .WithTags("Greetings");

        group.MapGet("", (IGreetingCounter greetingCounter) =>
            {
                var response = new GetGreetingCountResponse(greetingCounter.TotalCount, greetingCounter.PersonalizedCount, greetingCounter.AnonymousCount);
                return Results.Ok(response);
            })
            .WithName("GetGreetingCount")
            .Produces<GetGreetingCountResponse>()
            .WithSummary("Retrieves the count of greetings made to any developer, broken down by personalized and anonymous.");

        group.MapPost("", (GreetDeveloperRequest request, IGreetingCounter greetingCounter) =>
            {
                var developer = DeveloperAssembler.ToEntityFromRequest(request);
                if (developer.IsAnonymous)
                {
                    greetingCounter.IncrementAnonymous();
                }
                else
                {
                    greetingCounter.IncrementPersonalized();
                }
                var response = GreetDeveloperAssembler.ToResponseFromEntity(developer);
                return Results.Created($"/api/v1/greetings/{developer.Id}", response);
            })
            .WithName("CreateGreeting")
            .Produces<GreetDeveloperResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithSummary("Creates a greeting for a developer, personalized or anonymous.");
        
        return app;
    }
}
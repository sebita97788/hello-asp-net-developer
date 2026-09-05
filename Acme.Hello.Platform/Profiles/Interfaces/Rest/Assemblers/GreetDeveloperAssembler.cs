using Acme.Hello.Platform.Profiles.Domain.Model.Entities;
using Acme.Hello.Platform.Profiles.Interfaces.Rest.Resources;

namespace Acme.Hello.Platform.Profiles.Interfaces.Rest.Assemblers;

/// <summary>
/// Assembler class to convert a Developer entity into a GreetDeveloperResponse.
/// </summary>
public static class GreetDeveloperAssembler
{
    /// <summary>
    /// Converts a Developer entity into a GreetDeveloperResponse: a personalized greeting when
    /// the developer revealed a name, an anonymous one otherwise. Every developer keeps its own
    /// identifier and full name either way, <see cref="Developer.GetFullName"/> is never null;
    /// only the message text differs.
    /// </summary>
    /// <param name="developer">The developer entity to convert.</param>
    /// <returns>A GreetDeveloperResponse with the personalized or anonymous greeting details.</returns>
    public static GreetDeveloperResponse ToResponseFromEntity(Developer developer) =>
        new(developer.Id, developer.GetFullName(),
            developer.IsAnonymous
                ? "Welcome Anonymous ASP.NET Developer"
                : $"Congrats {developer.GetFullName()}! You are an ASP.NET Developer");
}
using Acme.Hello.Platform.Profiles.Domain.Model.Entities;
using Acme.Hello.Platform.Profiles.Domain.Model.ValueObjects;
using Acme.Hello.Platform.Profiles.Interfaces.Rest.Resources;

namespace Acme.Hello.Platform.Profiles.Interfaces.Rest.Assemblers;

/// <summary>
/// Assembler class to convert a GreetDeveloperRequest into a Developer entity.
/// </summary>
public static class DeveloperAssembler
{
    /// <summary>
    /// Converts a GreetDeveloperRequest into a Developer entity: named when both first and
    /// last name are present, anonymous otherwise. A too-long name never reaches this point,
    /// <see cref="GreetDeveloperRequest"/>'s own validation already rejected it with a 400.
    /// </summary>
    /// <param name="request">The request containing the first and last names.</param>
    /// <returns>A named <see cref="Developer"/> when both names are present, an anonymous one otherwise.</returns>
    public static Developer ToEntityFromRequest(GreetDeveloperRequest request) =>
        !string.IsNullOrWhiteSpace(request.FirstName) && !string.IsNullOrWhiteSpace(request.LastName)
            ? new Developer(new PersonName(request.FirstName, request.LastName))
            : new Developer();
}
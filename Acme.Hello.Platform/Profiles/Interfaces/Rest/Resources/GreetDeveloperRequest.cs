using System.ComponentModel.DataAnnotations;

namespace Acme.Hello.Platform.Profiles.Interfaces.Rest.Resources;

/// <summary>
/// A record representing a request to greet a developer.
/// Both names are optional: leaving them out, or blank, greets the developer anonymously.
/// A name that is present but too long is still rejected.
/// </summary>
/// <param name="FirstName">The developer's first name, optional.</param>
/// <param name="LastName">The developer's last name, optional.</param>
public record GreetDeveloperRequest(
    [property: StringLength(35, ErrorMessage = "First name cannot exceed 35 characters")]
    string? FirstName,
    [property: StringLength(40, ErrorMessage = "Last name cannot exceed 40 characters")]
    string? LastName);
namespace Acme.Hello.Platform.Profiles.Interfaces.Rest.Resources;

/// <summary>
/// A record representing the response for a greeting request.
/// Contains the developer's ID, full name, and a personalized message.
/// </summary>
/// <param name="Id">The unique identifier of the developer, always present.</param>
/// <param name="FullName">The developer's full name, always present: the well-known "Anonymous ASP.NET Developer" for an anonymous greeting.</param>
/// <param name="Message">The greeting message.</param>
public record GreetDeveloperResponse(Guid Id, string FullName, string Message);
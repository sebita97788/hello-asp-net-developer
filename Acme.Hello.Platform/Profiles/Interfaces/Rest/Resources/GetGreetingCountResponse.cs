namespace Acme.Hello.Platform.Profiles.Interfaces.Rest.Resources;

/// <summary>
/// A record representing the response for a greeting count request.
/// </summary>
/// <param name="GreetingCount">The total number of greetings, personalized plus anonymous.</param>
/// <param name="PersonalizedCount">The number of personalized greetings.</param>
/// <param name="AnonymousCount">The number of anonymous greetings.</param>
public record GetGreetingCountResponse(int GreetingCount, int PersonalizedCount, int AnonymousCount);
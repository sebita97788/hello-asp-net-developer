namespace Acme.Hello.Platform.Profiles.Domain.Services;

/// <summary>
/// Domain service interface for tracking and retrieving greeting metrics, personalized and
/// anonymous counted separately.
/// </summary>
public interface IGreetingCounter
{
    /// <summary>
    /// Gets the current number of personalized greetings made to any developer.
    /// </summary>
    int PersonalizedCount { get; }

    /// <summary>
    /// Gets the current number of anonymous greetings.
    /// </summary>
    int AnonymousCount { get; }

    /// <summary>
    /// Gets the total number of greetings, personalized plus anonymous.
    /// </summary>
    int TotalCount { get; }

    /// <summary>
    /// Increments the personalized greeting count in a thread-safe manner.
    /// </summary>
    void IncrementPersonalized();

    /// <summary>
    /// Increments the anonymous greeting count in a thread-safe manner.
    /// </summary>
    void IncrementAnonymous();
}
namespace Acme.Hello.Platform.Profiles.Domain.Services.Internal;

public class GreetingCounter : IGreetingCounter
{
    private int _personalizedCount;
    private int _anonymousCount;
    
    public int PersonalizedCount => Volatile.Read(ref _personalizedCount);
    
    public int AnonymousCount => Volatile.Read(ref _anonymousCount);

    public int TotalCount => PersonalizedCount + AnonymousCount;
    
    public void IncrementPersonalized() => Interlocked.Increment(ref _personalizedCount);

    public void IncrementAnonymous() => Interlocked.Increment(ref _anonymousCount);
}
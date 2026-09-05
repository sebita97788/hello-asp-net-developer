namespace Acme.Hello.Platform.Profiles.Domain.Model.ValueObjects;

/// <summary>
/// Represents a person's name as a value object in the domain model.
/// Encapsulates first and last names with validation and trimming behavior.
/// </summary>
public readonly record struct PersonName
{
    /// <summary>
    /// The first name, trimmed of whitespace.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the first name is null or blank.</exception>
    public string FirstName
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value.Trim();
        }
    }

    /// <summary>
    /// The last name, trimmed of whitespace.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the last name is null or blank.</exception>
    public string LastName
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value.Trim();
        }
    }

    /// <summary>
    /// Prevents parameterless construction of <see cref="PersonName"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Always thrown because both names are required.</exception>
    public PersonName() => throw new InvalidOperationException("PersonName must be initialized with a first and a last name.");

    /// <summary>
    /// Initializes a new instance of PersonName with first and last names.
    /// </summary>
    /// <param name="firstName">The person's first name, it must not be null or blank.</param>
    /// <param name="lastName">The person's last name, it must not be null or blank.</param>
    /// <exception cref="ArgumentException">Thrown if either name is null or blank.</exception>
    public PersonName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    /// <summary>
    /// Returns the full name by concatenating first and last names with a space.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    /// <summary>
    /// The well-known name for a developer who did not provide one. Every person has a name,
    /// so a <see cref="Domain.Model.Entities.Developer"/> greeted without one still gets a real,
    /// valid <see cref="PersonName"/>, never a <c>null</c> one: they just didn't reveal theirs.
    /// </summary>
    public static readonly PersonName Anonymous = new("Anonymous", "ASP.NET Developer");
}
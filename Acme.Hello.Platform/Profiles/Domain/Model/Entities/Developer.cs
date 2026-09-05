using Acme.Hello.Platform.Profiles.Domain.Model.ValueObjects;

namespace Acme.Hello.Platform.Profiles.Domain.Model.Entities;

/// <summary>
/// Represents a Developer entity in the domain model, with an auto-generated ID and a name:
/// a developer greeted without providing one gets the well-known <see cref="PersonName.Anonymous"/>,
/// never a missing one.
/// </summary>
public class Developer
{
    /// <summary>
    /// Gets the unique identifier for the developer, a time-ordered UUID v7. Every developer
    /// gets one, named or anonymous.
    /// </summary>
    public Guid Id { get; } = Guid.CreateVersion7();

    /// <summary>
    /// Gets the developer's person name value object. Always present: <see cref="PersonName.Anonymous"/>
    /// stands in when the developer didn't provide one.
    /// </summary>
    public PersonName Name { get; }

    /// <summary>
    /// Gets a value indicating whether this developer didn't reveal a name.
    /// </summary>
    public bool IsAnonymous => Name == PersonName.Anonymous;

    /// <summary>
    /// Initializes a new instance of the Developer class with a name.
    /// </summary>
    /// <param name="name">The developer's person name value object.</param>
    public Developer(PersonName name)
    {
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the Developer class with first and last names.
    /// </summary>
    /// <param name="firstName">The developer's first name, it must not be null or blank.</param>
    /// <param name="lastName">The developer's last name, it must not be null or blank.</param>
    public Developer(string firstName, string lastName) : this(new PersonName(firstName, lastName))
    {
    }

    /// <summary>
    /// Initializes a new instance of the Developer class with no name provided: anonymous.
    /// </summary>
    public Developer() : this(PersonName.Anonymous)
    {
    }

    /// <summary>
    /// Returns the full name by delegating to the PersonName value object.
    /// </summary>
    public string GetFullName() => Name.FullName;
}
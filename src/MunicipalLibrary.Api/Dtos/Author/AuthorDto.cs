namespace MunicipalLibrary.Api.Dtos.Author;

/// <summary>
/// DTO for representing an author's public data.
/// </summary>
public class AuthorDto
{
    /// <summary>
    /// The unique identifier of the author.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The full name of the author.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// A brief biography of the author.
    /// </summary>
    public string? Biography { get; set; }

    /// <summary>
    /// The author's date of birth.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
}

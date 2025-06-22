namespace MunicipalLibrary.Api.Models;

/// <summary>
/// Represents an author entity in the library.
/// </summary>
public class Author
{
    #region Main Attributes

    /// <summary>
    /// The unique identifier for the author.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The full name of the author.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// A brief biography or description of the author. Can be null.
    /// </summary>
    public string? Biography { get; set; }

    /// <summary>
    /// The author's date of birth. Can be null if unknown.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// The author's date of death. Null if the author is alive or the date is
    /// unkown.
    /// </summary>
    public DateTime? DateOfDeath { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The collection of books associated with this author.
    /// </summary>
    public ICollection<Book> Books { get; set; } = [];

    #endregion
}

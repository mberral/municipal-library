using System.ComponentModel.DataAnnotations;

namespace MunicipalLibrary.Api.Dtos.Book;

/// <summary>
/// DTO used to create a new book.
/// </summary>
public class CreateBookDto
{
    /// <summary>
    /// The title of the new book. Required. Max 200 characters.
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The publisher of the new book. Required.
    /// </summary>
    [Required]
    public string Publisher { get; set; } = string.Empty;

    /// <summary>
    /// The publication year of the new book. Must be a valid year.
    /// </summary>
    [Range(1, 9999)]
    public int Year { get; set; }

    /// <summary>
    /// The ISBN of the new book. Required.
    /// </summary>
    [Required]
    public string Isbn { get; set; } = string.Empty;

    /// <summary>
    /// An optional description for the new book.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// An optional comma-separated string of genres.
    /// </summary>
    public string? Genres { get; set; }

    /// <summary>
    /// The optional total number of pages.
    /// </summary>
    public int? NumberOfPages { get; set; }

    /// <summary>
    /// The optional language of the book.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// A list of author IDs to associate with this book. Must contain at least one author ID.
    /// </summary>
    [Required]
    [MinLength(1)]
    public List<int> AuthorIds { get; set; } = [];
}

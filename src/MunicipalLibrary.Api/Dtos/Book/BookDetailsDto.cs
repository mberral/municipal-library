using MunicipalLibrary.Api.Dtos.Author;

namespace MunicipalLibrary.Api.Dtos.Book;

/// <summary>
/// Provides a detailed view of a single book, including all its properties and related authors.
/// </summary>
public class BookDetailsDto
{
    /// <summary>
    /// The unique identifier for the book.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The title of the book.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The name of the publisher.
    /// </summary>
    public string Publisher { get; set; } = string.Empty;

    /// <summary>
    /// The year the book was originally published.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// The International Standard Book Number (ISBN).
    /// </summary>
    public string Isbn { get; set; } = string.Empty;

    /// <summary>
    /// A short description or synopsis of the book.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// A comma-separated string of genres associated with the book.
    /// </summary>
    public string? Genres { get; set; }

    /// <summary>
    /// The total number of pages in the book.
    /// </summary>
    public int? NumberOfPages { get; set; }

    /// <summary>
    /// The language the book is written in.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// A list of DTOs representing the authors of the book.
    /// </summary>
    public List<AuthorDto> Authors { get; set; } = [];
}

namespace MunicipalLibrary.Api.Dtos.Book;

/// <summary>
/// Provides a summarized view of a book, typically for lists.
/// </summary>
public class BookSummaryDto
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
    /// A comma-separated string of the book's author names.
    /// </summary>
    public string Authors { get; set; } = string.Empty;
}

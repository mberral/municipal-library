using System.ComponentModel.DataAnnotations;

namespace MunicipalLibrary.Api.Models;

/// <summary>
/// Represents a book entity in the library's catalog.
/// </summary>
public class Book
{
    #region Main Attributes

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
    /// The year the book was published.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// The International Standard Book Number.
    /// </summary>
    public string Isbn { get; set; } = string.Empty;

    /// <summary>
    /// A short description or synopsis of the book. Can be null.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// A list of genres associated with the book. Can be null.
    /// </summary>
    public List<string>? Genres { get; set; }

    /// <summary>
    /// The total number of pages in the book. Can be null.
    /// </summary>
    public int? NumberOfPages { get; set; }

    /// <summary>
    /// The language the book is written in. Can be null.
    /// </summary>
    public string? Language { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The collection of authors who wrote this book.
    /// </summary>
    public ICollection<Author> Authors { get; set; } = [];

    #endregion
}

namespace MunicipalLibrary.Api.Models;

/// <summary>
/// Represents a loan transaction of a book to a user.
/// </summary>
public class Loan
{
    #region Main Attributes

    /// <summary>
    /// The unique identifier for the loan transaction.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The date when the book was loaned out.
    /// </summary>
    public DateTime LoanDate { get; set; }

    /// <summary>
    /// The date when the book is due to be returned.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// The actual date the book was returned. Null if not yet returned.
    /// </summary>
    public DateTime? ReturnDate { get; set; }

    #endregion

    #region Foreign Keys

    /// <summary>
    /// Foreign key for the User who borrowed the book.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Foreign key for the Book that was loaned.
    /// </summary>
    public int BookId { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The User associated with this loan.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// The Book associated with this loan.
    /// </summary>
    public Book Book { get; set; } = null!;

    #endregion
}

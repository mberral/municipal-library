namespace MunicipalLibrary.Api.Models;

/// <summary>
/// Represents a library user or member.
/// </summary>
public class User
{
    #region Main Attributes

    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The full name of the user.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The user's unique email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The unique library card number assigned to the user.
    /// </summary>
    public string LibraryCardNumber { get; set; } = string.Empty;

    /// <summary>
    /// The user's physical address. Can be null.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// The user's contact phone number. Can be null.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The date the user registered with the library.
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The collection of loans associated with this user, representing their
    /// borrowing history.
    /// </summary>
    public ICollection<Loan> Loans { get; set; } = [];

    #endregion
}

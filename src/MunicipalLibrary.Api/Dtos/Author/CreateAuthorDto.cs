using System.ComponentModel.DataAnnotations;

namespace MunicipalLibrary.Api.Dtos.Author;

/// <summary>
/// DTO for creating a new author.
/// </summary>
public class CreateAuthorDto
{
    /// <summary>
    /// The full name of the new author. This field is required.
    /// </summary>
    [Required]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// An optional biography for the new author.
    /// </summary>
    public string? Biography { get; set; }

    /// <summary>
    /// The optional date of birth for the new author.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
}

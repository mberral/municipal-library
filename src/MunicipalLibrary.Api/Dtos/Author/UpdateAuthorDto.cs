using System.ComponentModel.DataAnnotations;

namespace MunicipalLibrary.Api.Dtos.Author;

/// <summary>
/// DTO for updating an existing author.
/// </summary>
public class UpdateAuthorDto
{
    /// <summary>
    /// The updated full name of the author. This field is required.
    /// </summary>
    [Required]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The updated biography for the author. Can be set to null.
    /// </summary>
    public string? Biography { get; set; }

    /// <summary>
    /// The updated date of birth for the author. Can be set to null.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
}

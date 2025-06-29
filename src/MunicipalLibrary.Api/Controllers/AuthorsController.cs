using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalLibrary.Api.Data;
using MunicipalLibrary.Api.Dtos.Author;
using MunicipalLibrary.Api.Models;

namespace MunicipalLibrary.Api.Controllers;

/// <summary>
/// Handles all HTTP requests related to authors, providing CRUD operations.
/// </summary>
[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly MunicipalLibraryDbContext _context;

    /// <summary>
    /// Initializes a new instance of the AuthorsController class.
    /// </summary>
    /// <param name="context">The database context, injected by the dependency injection container.</param>
    public AuthorsController(MunicipalLibraryDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all authors.
    /// </summary>
    /// <returns>A list of authors.</returns>
    /// <response code="200">Returns the list of authors.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        var authors = await _context.Authors.ToListAsync();
        var authorDtos = authors.Select(author => new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Biography = author.Biography,
            DateOfBirth = author.DateOfBirth
        });
        return Ok(authorDtos);
    }

    /// <summary>
    /// Gets a specific author by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the author to retrieve.</param>
    /// <returns>The requested author.</returns>
    /// <response code="200">Returns the requested author.</response>
    /// <response code="404">If the author with the specified ID is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
            return NotFound();

        var authorDto = new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Biography = author.Biography,
            DateOfBirth = author.DateOfBirth
        };
        return Ok(authorDto);
    }

    /// <summary>
    /// Creates a new author.
    /// </summary>
    /// <param name="createAuthorDto">The data for the new author.</param>
    /// <returns>The newly created author.</returns>
    /// <response code="201">Returns the newly created author and a location header.</response>
    /// <response code="400">If the input data is invalid.</response>
    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthor(CreateAuthorDto createAuthorDto)
    {
        var author = new Author
        {
            Name = createAuthorDto.Name,
            Biography = createAuthorDto.Biography,
            DateOfBirth = createAuthorDto.DateOfBirth
        };

        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        var authorDto = new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Biography = author.Biography,
            DateOfBirth = author.DateOfBirth
        };

        return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, authorDto);
    }

    /// <summary>
    /// Updates an existing author.
    /// </summary>
    /// <param name="id">The ID of the author to update.</param>
    /// <param name="updateAuthorDto">The updated data for the author.</param>
    /// <response code="204">If the update was successful.</response>
    /// <response code="404">If the author with the specified ID is not found.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDto updateAuthorDto)
    {
        var authorToUpdate = await _context.Authors.FindAsync(id);

        if (authorToUpdate == null)
            return NotFound();

        authorToUpdate.Name = updateAuthorDto.Name;
        authorToUpdate.Biography = updateAuthorDto.Biography;
        authorToUpdate.DateOfBirth = updateAuthorDto.DateOfBirth;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a specific author.
    /// </summary>
    /// <param name="id">The ID of the author to delete.</param>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the author with the specified ID is not found.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var authorToDelete = await _context.Authors.FindAsync(id);

        if (authorToDelete == null)
            return NotFound();

        _context.Authors.Remove(authorToDelete);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalLibrary.Api.Data;
using MunicipalLibrary.Api.Dtos.Author;
using MunicipalLibrary.Api.Dtos.Book;
using MunicipalLibrary.Api.Models;

namespace MunicipalLibrary.Api.Controllers;

/// <summary>
/// Handles all HTTP requests related to books, including managing their relationships with authors.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly MunicipalLibraryDbContext _context;

    /// <summary>
    /// Initializes a new instance of the BooksController class.
    /// </summary>
    /// <param name="context">The database context, injected by the dependency injection container.</param>
    public BooksController(MunicipalLibraryDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all books in a summarized format.
    /// </summary>
    /// <returns>A list of summarized books.</returns>
    /// <response code="200">Returns the list of books.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookSummaryDto>>> GetBooks()
    {
        var books = await _context.Books
            .Include(b => b.Authors)
            .Select(b => new BookSummaryDto
            {
                Id = b.Id,
                Title = b.Title,
                Authors = string.Join(", ", b.Authors.Select(a => a.Name))
            })
            .ToListAsync();

        return Ok(books);
    }

    /// <summary>
    /// Gets the detailed information for a specific book.
    /// </summary>
    /// <param name="id">The ID of the book to retrieve.</param>
    /// <returns>The detailed data for the requested book.</returns>
    /// <response code="200">Returns the requested book.</response>
    /// <response code="404">If the book with the specified ID is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDetailsDto>> GetBook(int id)
    {
        var book = await _context.Books
            .Include(b => b.Authors)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
            return NotFound();

        var bookDto = new BookDetailsDto
        {
            Id = book.Id,
            Title = book.Title,
            Publisher = book.Publisher,
            Year = book.Year,
            Isbn = book.Isbn,
            Description = book.Description,
            Genres = book.Genres,
            NumberOfPages = book.NumberOfPages,
            Language = book.Language,
            Authors = book.Authors.Select(a => new AuthorDto { Id = a.Id, Name = a.Name }).ToList()
        };

        return Ok(bookDto);
    }

    /// <summary>
    /// Creates a new book and associates it with existing authors.
    /// </summary>
    /// <param name="createBookDto">The data for the new book, including a list of author IDs.</param>
    /// <returns>The newly created book's detailed view.</returns>
    /// <response code="201">Returns the newly created book.</response>
    /// <response code="400">If the input data is invalid or if any of the provided author IDs do not exist.</response>
    [HttpPost]
    public async Task<ActionResult<BookDetailsDto>> CreateBook(CreateBookDto createBookDto)
    {
        var authors = await _context.Authors.Where(a => createBookDto.AuthorIds.Contains(a.Id)).ToListAsync();

        if (authors.Count != createBookDto.AuthorIds.Count)
            return BadRequest("One or more author IDs are invalid.");

        var book = new Book
        {
            Title = createBookDto.Title,
            Publisher = createBookDto.Publisher,
            Year = createBookDto.Year,
            Isbn = createBookDto.Isbn,
            Description = createBookDto.Description,
            Genres = createBookDto.Genres,
            NumberOfPages = createBookDto.NumberOfPages,
            Language = createBookDto.Language,
            Authors = authors
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        var bookToReturn = new BookDetailsDto
        {
            Id = book.Id,
            Title = book.Title,
            Publisher = book.Publisher,
            Year = book.Year,
            Isbn = book.Isbn,
            Description = book.Description,
            Genres = book.Genres,
            NumberOfPages = book.NumberOfPages,
            Language = book.Language,
            Authors = book.Authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                Biography = a.Biography,
                DateOfBirth = a.DateOfBirth
            }).ToList()
        };

        return CreatedAtAction(nameof(GetBook), new { id = bookToReturn.Id }, bookToReturn);
    }

    /// <summary>
    /// Updates an existing book, including its associated authors.
    /// </summary>
    /// <param name="id">The ID of the book to update.</param>
    /// <param name="updateBookDto">The updated data for the book.</param>
    /// <response code="204">If the update was successful.</response>
    /// <response code="400">If any of the provided author IDs do not exist.</response>
    /// <response code="404">If the book with the specified ID is not found.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updateBookDto)
    {
        var bookToUpdate = await _context.Books
            .Include(b => b.Authors)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (bookToUpdate == null)
            return NotFound();

        bookToUpdate.Title = updateBookDto.Title;
        bookToUpdate.Publisher = updateBookDto.Publisher;
        bookToUpdate.Year = updateBookDto.Year;
        bookToUpdate.Isbn = updateBookDto.Isbn;
        bookToUpdate.Description = updateBookDto.Description;
        bookToUpdate.Genres = updateBookDto.Genres;
        bookToUpdate.NumberOfPages = updateBookDto.NumberOfPages;
        bookToUpdate.Language = updateBookDto.Language;

        var newAuthors = await _context.Authors
            .Where(a => updateBookDto.AuthorIds.Contains(a.Id))
            .ToListAsync();

        if (newAuthors.Count != updateBookDto.AuthorIds.Count)
            return BadRequest("One or more author IDs are invalid.");

        bookToUpdate.Authors = newAuthors;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a specific book.
    /// </summary>
    /// <param name="id">The ID of the book to delete.</param>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the book with the specified ID is not found.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var bookToDelete = await _context.Books.FindAsync(id);

        if (bookToDelete == null)
            return NotFound();

        _context.Books.Remove(bookToDelete);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

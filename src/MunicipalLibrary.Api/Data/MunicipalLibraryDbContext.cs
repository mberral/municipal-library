using Microsoft.EntityFrameworkCore;
using MunicipalLibrary.Api.Models;

namespace MunicipalLibrary.Api.Data;

/// <summary>
/// The database context for the Municipal Library application.
/// It acts as the main bridge between the C# entity models and the database.
/// </summary>
public class MunicipalLibraryDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MunicipalLibraryDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public MunicipalLibraryDbContext(DbContextOptions<MunicipalLibraryDbContext> options)
        : base(options)
    {
    }

    #region DbSets

    /// <summary>
    /// Gets or sets the DbSet for Books. This represents the 'Books' table in the database.
    /// </summary>
    public DbSet<Book> Books { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for Authors. This represents the 'Authors' table in the database.
    /// </summary>
    public DbSet<Author> Authors { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for Users. This represents the 'Users' table in the database.
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for Loans. This represents the 'Loans' table in the database.
    /// </summary>
    public DbSet<Loan> Loans { get; set; } = null!;

    #endregion

    /// <summary>
    /// Configures the model and its relationships using the ModelBuilder API.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- Configuration for Book Entity ---
        modelBuilder.Entity<Book>(entity =>
        {
            // Explicitly configure the many-to-many relationship with Author.
            entity.HasMany(b => b.Authors)
                  .WithMany(a => a.Books);
        });
    }
}

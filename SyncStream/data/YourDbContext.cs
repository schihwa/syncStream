using Microsoft.EntityFrameworkCore;

public class YourDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<VideoState> VideoStates { get; set; }
    public DbSet<PartyManagement> PartyManagements { get; set; }

    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            // Sets the primary key for the Client entity.
            entity.HasKey(e => e.Id);

            // Creates an index on the PartyId column to improve query performance.
            entity.HasIndex(e => e.PartyId);

            // Configures the Name property as required with a maximum length of 255 characters.
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);

            // Configures the IsHost property as required with a default value of false.
            entity.Property(e => e.IsHost).IsRequired();

            // Configures the Picture property as required with a maximum length of 2048 characters.
            entity.Property(e => e.Picture).IsRequired().HasMaxLength(2048);
        });

        modelBuilder.Entity<VideoState>(entity =>
        {
            // Creates an index on the PartyId column to improve query performance.
            entity.HasIndex(e => e.PartyId);
        });
    }
}
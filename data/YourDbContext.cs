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
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.PartyId).HasDatabaseName("idx_clients_partyId");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.IsHost).IsRequired().HasDefaultValue(false);
            entity.Property(e => e.Picture).IsRequired().HasMaxLength(2048);
        });

        modelBuilder.Entity<VideoState>(entity =>
        {
            entity.HasIndex(e => e.PartyId).HasDatabaseName("idx_videoState_partyId");
            entity.HasIndex(e => new { e.PartyId, e.Status }).HasDatabaseName("idx_videoState_partyId_status");
            entity.Property(e => e.VideoUrl).IsRequired().HasMaxLength(2048);
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.Time).IsRequired();
        });

        modelBuilder.Entity<PartyManagement>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.HostId).HasDatabaseName("idx_partyManagement_hostId");
            entity.Property(e => e.NumberOfPeople).IsRequired().HasDefaultValue(0);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
        });
    }
}

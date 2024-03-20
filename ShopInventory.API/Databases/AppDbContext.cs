using Microsoft.EntityFrameworkCore;
using ShopInventory.API.Databases.Models;

namespace ShopInventory.API.Databases;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artigo> Artigos { get; set; }

    public virtual DbSet<ArtigoMoedum> ArtigoMoeda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=ShopInventoryContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artigo>(entity =>
        {
            entity.HasKey(e => e.Artigo1).HasName("Artigo01");

            entity.HasIndex(e => e.CodBarras, "Artigo02").HasFillFactor(90);

            entity.Property(e => e.VersaoUltAct)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.ArtigoPaiNavigation).WithMany(p => p.InverseArtigoPaiNavigation).HasConstraintName("Artigo_Artigo_FK");
        });

        modelBuilder.Entity<ArtigoMoedum>(entity =>
        {
            entity.HasKey(e => new { e.Artigo, e.Unidade, e.Moeda }).HasName("ArtigoMoeda01");

            entity.Property(e => e.VersaoUltAct)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.ArtigoNavigation).WithMany(p => p.ArtigoMoeda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ArtigoMoeda_Artigo_FK");
        });
    }
}

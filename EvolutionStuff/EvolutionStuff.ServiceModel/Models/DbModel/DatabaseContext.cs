using Microsoft.EntityFrameworkCore;

namespace EvolutionStuff.ServiceModel.Models.DbModel;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressDb> Addresses { get; set; }

    public virtual DbSet<CompanyDb> Companies { get; set; }

    public virtual DbSet<GeoDb> Geos { get; set; }

    public virtual DbSet<UserDb> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FA63DF46B");
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(u => u.Address)
                  .WithOne(a => a.User)
                  .HasForeignKey<AddressDb>(a => a.Id)
                  .HasConstraintName("FK_User_Address");
            entity.HasOne(u => u.Company)
                  .WithOne(c => c.User)
                  .HasForeignKey<CompanyDb>(c => c.Id)
                  .HasConstraintName("FK_User_Company");
        });

        modelBuilder.Entity<AddressDb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3213E83F1B17CD10");
            entity.Property(e => e.Id).ValueGeneratedNever();

            // One-to-One relationship with User
            entity.HasOne(a => a.User)
                  .WithOne(u => u.Address)
                  .HasForeignKey<AddressDb>(a => a.Id)
                  .HasConstraintName("FK_Address_User");

            // One-to-One relationship with Geo

            entity.HasOne(a => a.Geo)
                  .WithOne(g => g.Address)
                  .HasForeignKey<GeoDb>(g => g.Id)
                  .HasConstraintName("FK_Address_Geo");

        });

        modelBuilder.Entity<CompanyDb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3213E83FD088738F");
            entity.Property(e => e.Id).ValueGeneratedNever();
            /*
            // One-to-One relationship with User
            entity.HasOne(c => c.User)
                  .WithOne(u => u.Company)
                  .HasForeignKey<Company>(c => c.UserId)
                  .HasConstraintName("FK_Company_User");
            */
        });




        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

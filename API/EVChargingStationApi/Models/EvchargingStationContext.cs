using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EVChargingStationApi.Models;

public partial class EvchargingStationContext : DbContext
{
    public EvchargingStationContext()
    {
    }

    public EvchargingStationContext(DbContextOptions<EvchargingStationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChargingSocket> ChargingSockets { get; set; }

    public virtual DbSet<EvSite> EvSites { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCharging> UserChargings { get; set; }

    public virtual DbSet<VUserReciept> VUserReciepts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MEHUL-LPT\\SQLEXPRESS;Database=EVChargingStation;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChargingSocket>(entity =>
        {
            entity.HasKey(e => e.ChargingSocketId).HasName("PK__Charging__4DD869904AFB2EE2");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Site).WithMany(p => p.ChargingSockets)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChargingS__SiteI__4F7CD00D");
        });

        modelBuilder.Entity<EvSite>(entity =>
        {
            entity.HasKey(e => e.SiteId).HasName("PK__EvSites__B9DCB96338F5E115");

            entity.Property(e => e.ChargesPerHr).HasColumnType("numeric(6, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.SiteName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C20B28961");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserCharging>(entity =>
        {
            entity.HasKey(e => e.UserChargingId).HasName("PK__UserChar__FF29DBCEC842622B");

            entity.ToTable("UserCharging");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.ChargingSocket).WithMany(p => p.UserChargings)
                .HasForeignKey(d => d.ChargingSocketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserCharg__Charg__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.UserChargings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserCharg__UserI__5535A963");
        });

        modelBuilder.Entity<VUserReciept>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vUserReciept");

            entity.Property(e => e.ChargesPerHr).HasColumnType("numeric(6, 2)");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.SiteName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("numeric(21, 6)");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

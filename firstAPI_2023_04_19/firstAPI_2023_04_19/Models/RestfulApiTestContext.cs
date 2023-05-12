using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace firstAPI_2023_04_19.Models;

public partial class RestfulApiTestContext : DbContext
{
    public RestfulApiTestContext()
    {
    }

    public RestfulApiTestContext(DbContextOptions<RestfulApiTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InfoMessage> InfoMessages { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InfoMessage>(entity =>
        {
            entity.ToTable("infoMessage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Text)
                .HasMaxLength(50)
                .HasColumnName("text");

            entity.HasOne(d => d.Staff).WithMany(p => p.InfoMessages)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_infoMessage_staff");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable("staff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .HasColumnName("department");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

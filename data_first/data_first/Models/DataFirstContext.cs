using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace data_first.Models;

public partial class DataFirstContext : DbContext
{
    public DataFirstContext()
    {
    }

    public DataFirstContext(DbContextOptions<DataFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LUUBAOQUOC\\MSSQLSERVER2022;Initial Catalog=data_first;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khoa__3214EC07F7D8BA15");

            entity.ToTable("Khoa");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TenKhoa).HasMaxLength(50);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lop__3214EC07B8620107");

            entity.ToTable("Lop");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TenLop).HasMaxLength(50);

            entity.HasOne(d => d.Khoa).WithMany(p => p.Lops)
                .HasForeignKey(d => d.KhoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lop__KhoaId__398D8EEE");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SinhVien__3214EC070FB42C40");

            entity.ToTable("SinhVien");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.HoTen).HasMaxLength(50);

            entity.HasOne(d => d.Lop).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.LopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SinhVien__LopId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace firtApiProject.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<hamper> hampers { get; set; } = null!;
        public virtual DbSet<order> orders { get; set; } = null!;
        public virtual DbSet<product> products { get; set; } = null!;
        public virtual DbSet<user> users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=54321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<hamper>(entity =>
            {
                entity.ToTable("hamper");

                entity.Property(e => e.imgurl).HasColumnType("character varying");

                entity.Property(e => e.productName).HasColumnType("character varying");
            });

            modelBuilder.Entity<order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.imgurl).HasColumnType("character varying");
            });

            modelBuilder.Entity<product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.imgurl).HasColumnType("character varying");

                entity.Property(e => e.kdv).HasColumnType("character varying");

                entity.Property(e => e.productCode).HasColumnType("character varying");

                entity.Property(e => e.productName).HasColumnType("character varying");
            });

            modelBuilder.Entity<user>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.email).HasColumnType("character varying");

                entity.Property(e => e.name).HasColumnType("character varying");

                entity.Property(e => e.password).HasColumnType("character varying");

                entity.Property(e => e.phoneNumber).HasColumnType("character varying");

                entity.Property(e => e.role).HasColumnType("character varying");

                entity.Property(e => e.surname).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SignalAspCore2_Mohammadpour.Models
{
    public partial class DBMohammadpour : DbContext
    {
        public DBMohammadpour()
        {
        }

        public DBMohammadpour(DbContextOptions<DBMohammadpour> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<TblAccount> TblAccount { get; set; }
        public virtual DbSet<TblAccountOperation> TblAccountOperation { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblSignalrusers> TblSignalrusers { get; set; }
        public virtual DbSet<TblTel> TblTel { get; set; }

        // Unable to generate entity type for table 'dbo.report'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\server2017;Initial Catalog=DBMohammadpour;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Family)
                    .HasColumnName("family")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Tel).HasColumnName("tel");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasColumnType("image");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.ToTable("tblAccount");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(50);

                entity.Property(e => e.TblEmployeeId).HasColumnName("TblEmployee_Id");

                entity.HasOne(d => d.TblEmployee)
                    .WithMany(p => p.TblAccount)
                    .HasForeignKey(d => d.TblEmployeeId)
                    .HasConstraintName("FK_tblAccount_tblEmployee");
            });

            modelBuilder.Entity<TblAccountOperation>(entity =>
            {
                entity.ToTable("tblAccountOperation");

                entity.Property(e => e.OperationType).HasColumnName("operationType");

                entity.Property(e => e.Operationamount).HasColumnName("operationamount");

                entity.Property(e => e.Operationdate)
                    .HasColumnName("operationdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TblAccountId).HasColumnName("TblAccount_Id");

                entity.HasOne(d => d.TblAccount)
                    .WithMany(p => p.TblAccountOperation)
                    .HasForeignKey(d => d.TblAccountId)
                    .HasConstraintName("FK_tblAccountOperation_tblAccount");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.ToTable("tblEmployee");

                entity.Property(e => e.Family)
                    .HasColumnName("family")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Tel).HasColumnName("tel");
            });

            modelBuilder.Entity<TblSignalrusers>(entity =>
            {
                entity.ToTable("tblSignalrusers");

                entity.Property(e => e.ConnectionId).HasColumnName("connectionId");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblTel>(entity =>
            {
                entity.ToTable("tblTel");

                entity.HasIndex(e => e.Tel)
                    .HasName("NonClusteredIndex-20180712-032741")
                    .IsUnique();

                entity.Property(e => e.TblEmployeeId).HasColumnName("TblEmployee_Id");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(50);

                entity.HasOne(d => d.TblEmployee)
                    .WithMany(p => p.TblTel)
                    .HasForeignKey(d => d.TblEmployeeId)
                    .HasConstraintName("FK_tblTel_tblEmployee");
            });
        }
    }
}

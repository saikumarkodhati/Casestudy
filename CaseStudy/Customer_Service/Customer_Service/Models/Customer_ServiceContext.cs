using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Customer_Service.Models
{
    public partial class Customer_ServiceContext : DbContext
    {
        public Customer_ServiceContext()
        {
        }

        public Customer_ServiceContext(DbContextOptions<Customer_ServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerService> CustomerServices { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<TblLogin> TblLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET841;Initial Catalog=Customer_Service;User ID=sa;password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CustomerService>(entity =>
            {
                entity.ToTable("CustomerService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.ToTable("ServiceRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.ToTable("Tbl_Admin");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.ToTable("TblLogin");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

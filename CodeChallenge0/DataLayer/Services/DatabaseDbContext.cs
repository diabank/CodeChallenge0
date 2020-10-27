using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge0.Models.DbModel;

namespace CodeChallenge0.DataLayer.Services
{
    /// <summary>
    /// Database Db Context for EF Core
    /// </summary>
    public partial class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext()
        {
        }

        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblServiceOrder> TblServiceOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tblEmplo__C134C9C105AB9094");

                entity.ToTable("tblEmployee");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasColumnName("jobTitle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasColumnName("nickName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.YearsAtCompany).HasColumnName("yearsAtCompany");
            });

            modelBuilder.Entity<TblServiceOrder>(entity =>
            {
                entity.HasKey(e => e.ServiceOrderId)
                    .HasName("PK__tblServi__5C6287710FE9BF81");

                entity.ToTable("tblServiceOrder");

                entity.Property(e => e.ServiceOrderId).HasColumnName("serviceOrderId");

                entity.Property(e => e.DateAssigned)
                    .HasColumnName("dateAssigned")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDate)
                    .HasColumnName("dueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.ServiceDescription)
                    .HasColumnName("serviceDescription")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblServiceOrder)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__tblServic__emplo__34C8D9D1");
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetCoreAPI.Models
{
    public partial class DBFirstContext : DbContext
    {
        public virtual DbSet<EmpMaster> EmpMaster { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=MYLTOP;Database=DBFirst;User ID=sa;Password=Thiru@123;");
        //            }
        //        }

        //##passed into the context by dependency injection
        public DBFirstContext(DbContextOptions<DBFirstContext> options)
            : base(options)
            { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpMaster>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId)
                    .HasColumnName("Row_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpAddress)
                    .HasColumnName("Emp_Address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .HasColumnName("Emp_Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDepartment)
                    .HasColumnName("Emp_Department")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDob)
                    .HasColumnName("Emp_DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpExpriance).HasColumnName("Emp_Expriance");

                entity.Property(e => e.EmpFname)
                    .HasColumnName("Emp_FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLname)
                    .HasColumnName("Emp_LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpMaritalstatus)
                    .HasColumnName("Emp_Maritalstatus")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpProfilestatus).HasColumnName("Emp_Profilestatus");

                entity.Property(e => e.EmpRole)
                    .HasColumnName("Emp_Role")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpStatus).HasColumnName("Emp_Status");
            });
        }
    }
}

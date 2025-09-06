using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MedBock.DBEntities;

public partial class MedBockContext : DbContext
{
    public MedBockContext()
    {
    }

    public MedBockContext(DbContextOptions<MedBockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<DoctorDiscipline> DoctorDisciplines { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<Doctore> Doctores { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Ahmad-Faisal;Database=MedBock;Trusted_Connection=True;User Id=sa;password=20182018aa123;Integrated Security=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("Admin_Id");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(250);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.HasIndex(e => new { e.DoctorId, e.StartAt, e.EndAt }, "IX_Appointment_Doctor_Start");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Booked");

            entity.HasOne(d => d.Discipline).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DisciplineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Discpline");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Doctores");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Patient");
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.DisciplineId).HasName("PK_Discpline");

            entity.ToTable("Discipline");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<DoctorDiscipline>(entity =>
        {
            entity.ToTable("DoctorDiscipline");

            entity.HasIndex(e => new { e.DoctorId, e.DisciplineId }, "UQ_Doctor_Discipline").IsUnique();

            entity.HasOne(d => d.Discipline).WithMany(p => p.DoctorDisciplines)
                .HasForeignKey(d => d.DisciplineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorDiscipline_Discpline");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorDisciplines)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorDiscipline_Doctores");
        });

        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.ToTable("DoctorSchedule");

            entity.Property(e => e.DoctorScheduleId).ValueGeneratedNever();
            entity.Property(e => e.PersonId).HasColumnName("Person_Id");

            entity.HasOne(d => d.Person).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorSchedule_Doctores");
        });

        modelBuilder.Entity<Doctore>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK_Doctores_1");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("Person_Id");
            entity.Property(e => e.Bio).HasMaxLength(1000);
            entity.Property(e => e.LicenseFile).HasColumnName("License_File");
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(100)
                .HasColumnName("License_Number");
            entity.Property(e => e.Specialty).HasMaxLength(150);
            entity.Property(e => e.WorkHours).HasColumnName("Work_Hours");

            entity.HasOne(d => d.Person).WithOne(p => p.Doctore)
                .HasForeignKey<Doctore>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctores_Person");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.ToTable("Patient");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("Person_Id");

            entity.HasOne(d => d.Person).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_Person");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.HasIndex(e => e.Email, "UQ_Person_Email").IsUnique();

            entity.Property(e => e.PersonId).HasColumnName("Person_Id");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

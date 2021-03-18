using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BiografAPI.Web.Models
{
    public partial class BiografContext : DbContext
    {
        public BiografContext()
        {
        }

        public BiografContext(DbContextOptions<BiografContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoria { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ReservationType> ReservationTypes { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<SeatReserved> SeatReserveds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AEVH696\\SQLEXPRESS01;Database=Biograf;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.ToTable("Auditorium");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Director)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DurationMin).HasColumnName("Duration_Min");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Movie__GenreID__286302EC");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeePaidId).HasColumnName("EmployeePaidID");

                entity.Property(e => e.EmployeeReservedId).HasColumnName("EmployeeReservedID");

                entity.Property(e => e.ReservationContactName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ReservationTypeId).HasColumnName("ReservationTypeID");

                entity.Property(e => e.ScreeningId).HasColumnName("ScreeningID");

                entity.HasOne(d => d.EmployeePaid)
                    .WithMany(p => p.ReservationEmployeePaids)
                    .HasForeignKey(d => d.EmployeePaidId)
                    .HasConstraintName("FK__Reservati__Emplo__44FF419A");

                entity.HasOne(d => d.EmployeeReserved)
                    .WithMany(p => p.ReservationEmployeeReserveds)
                    .HasForeignKey(d => d.EmployeeReservedId)
                    .HasConstraintName("FK__Reservati__Emplo__4316F928");

                entity.HasOne(d => d.ReservationType)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ReservationTypeId)
                    .HasConstraintName("FK__Reservati__Reser__440B1D61");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ScreeningId)
                    .HasConstraintName("FK__Reservati__Scree__4222D4EF");
            });

            modelBuilder.Entity<ReservationType>(entity =>
            {
                entity.ToTable("ReservationType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.ToTable("Screening");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AuditoriumId).HasColumnName("AuditoriumID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.ScreeningStart).HasColumnType("datetime");

                entity.HasOne(d => d.Auditorium)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.AuditoriumId)
                    .HasConstraintName("FK__Screening__Audit__38996AB5");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Screening__Movie__37A5467C");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AuditoriumId).HasColumnName("AuditoriumID");

                entity.HasOne(d => d.Auditorium)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.AuditoriumId)
                    .HasConstraintName("FK__Seat__Auditorium__3B75D760");
            });

            modelBuilder.Entity<SeatReserved>(entity =>
            {
                entity.ToTable("SeatReserved");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.ScreeningId).HasColumnName("ScreeningID");

                entity.Property(e => e.SeatId).HasColumnName("SeatID");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.SeatReserveds)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK__SeatReser__Reser__48CFD27E");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.SeatReserveds)
                    .HasForeignKey(d => d.ScreeningId)
                    .HasConstraintName("FK__SeatReser__Scree__49C3F6B7");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.SeatReserveds)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("FK__SeatReser__SeatI__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

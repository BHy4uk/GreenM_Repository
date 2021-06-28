using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class test_DBContext : DbContext
    {
        public test_DBContext()
        {
        }

        public test_DBContext(DbContextOptions<test_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConcurrentLoginSession> ConcurrentLoginSessions { get; set; }
        public virtual DbSet<DevicesRegistration> DevicesRegistrations { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<TotalAccumulatedDuration> TotalAccumulatedDurations { get; set; }
        public virtual DbSet<UnexpectedLogged> UnexpectedLoggeds { get; set; }
        public virtual DbSet<UsersDevicesLogged> UsersDevicesLoggeds { get; set; }
        public virtual DbSet<UsersRegistration> UsersRegistrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=test_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ConcurrentLoginSession>(entity =>
            {
                entity.HasKey(e => e.LogSessId)
                    .HasName("PK_Concurrent_login_session");

                entity.ToTable("Concurrent_login_sessions");

                entity.Property(e => e.LogSessId).HasColumnName("log_sess_id");

                entity.Property(e => e.MaximumConcurSess).HasColumnName("Maximum_concur_sess");

                entity.Property(e => e.SessDurId).HasColumnName("sess_dur_id");
            });

            modelBuilder.Entity<DevicesRegistration>(entity =>
            {
                entity.HasKey(e => e.DeviceRegId)
                    .HasName("PK_Devices_registrationn");

                entity.ToTable("Devices_registration");

                entity.Property(e => e.DeviceRegId).HasColumnName("Device_reg_id");

                entity.Property(e => e.MonthId).HasColumnName("Month_id");

                entity.Property(e => e.RegisteredUsers).HasColumnName("Registered_users");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsersRegId).HasColumnName("Users_reg_id");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.DevicesRegistrations)
                    .HasForeignKey(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_registration_Month");

                entity.HasOne(d => d.MonthNavigation)
                    .WithMany(p => p.DevicesRegistrations)
                    .HasForeignKey(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_registration_Users_registration");
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.ToTable("Month");

                entity.Property(e => e.MonthId).HasColumnName("Month_id");

                entity.Property(e => e.Month1)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Month");
            });

            modelBuilder.Entity<TotalAccumulatedDuration>(entity =>
            {
                entity.HasKey(e => e.SessDurId);

                entity.ToTable("Total_accumulated_duration");

                entity.Property(e => e.SessDurId).HasColumnName("sess_dur_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TotalSessionDuration).HasColumnName("Total_session_duration");

                entity.Property(e => e.TotalSessionDurationForHour).HasColumnName("Total_session_duration_for_hour");
            });

            modelBuilder.Entity<UnexpectedLogged>(entity =>
            {
                entity.HasKey(e => e.UnexpectedId);

                entity.ToTable("Unexpected_logged");

                entity.Property(e => e.UnexpectedId).HasColumnName("unexpected_id");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoggedId).HasColumnName("logged_id");

                entity.Property(e => e.LoginTs)
                    .HasColumnType("datetime")
                    .HasColumnName("Login_TS");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("User_name");

                entity.HasOne(d => d.Logged)
                    .WithMany(p => p.UnexpectedLoggeds)
                    .HasForeignKey(d => d.LoggedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unexpected_logged_Users_devices_logged");
            });

            modelBuilder.Entity<UsersDevicesLogged>(entity =>
            {
                entity.HasKey(e => e.LoggedId);

                entity.ToTable("Users_devices_logged");

                entity.Property(e => e.LoggedId).HasColumnName("logged_id");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Device_Name");

                entity.Property(e => e.LoginTs)
                    .HasColumnType("datetime")
                    .HasColumnName("Login_TS");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("User_Name");
            });

            modelBuilder.Entity<UsersRegistration>(entity =>
            {
                entity.HasKey(e => e.MonthId)
                    .HasName("PK_Users_registration_1");

                entity.ToTable("Users_registration");

                entity.Property(e => e.MonthId)
                    .ValueGeneratedNever()
                    .HasColumnName("Month_id");

                entity.Property(e => e.RegisteredUsers).HasColumnName("Registered_users");

                entity.Property(e => e.UserRegId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("User_reg_id");

                entity.HasOne(d => d.Month)
                    .WithOne(p => p.UsersRegistration)
                    .HasForeignKey<UsersRegistration>(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_registration_Month");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

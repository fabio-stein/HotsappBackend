using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hotsapp.Data.Model
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectionFlow> ConnectionFlow { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VirtualNumber> VirtualNumber { get; set; }
        public virtual DbSet<VirtualNumberData> VirtualNumberData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=sonorisdev;database=hotsapp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectionFlow>(entity =>
            {
                entity.ToTable("connection_flow");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_connection_flow_UserId");

                entity.Property(e => e.Id).HasColumnType("char(36)");

                entity.Property(e => e.ConfirmCode).HasColumnType("varchar(255)");

                entity.Property(e => e.CountryCode).HasColumnType("int(11)");

                entity.Property(e => e.CreateDateUtc)
                    .HasColumnName("CreateDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorMessage).HasColumnType("varchar(255)");

                entity.Property(e => e.IsActive).HasColumnType("tinyint(1)");

                entity.Property(e => e.IsSuccess).HasColumnType("tinyint(1)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConnectionFlow)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_connection_flow_UserId");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_message_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DateTimeUtc)
                    .HasColumnName("DateTimeUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Error).HasColumnType("tinyint(1)");

                entity.Property(e => e.ExternalNumber).HasColumnType("varchar(255)");

                entity.Property(e => e.InternalNumber).HasColumnType("varchar(255)");

                entity.Property(e => e.IsInternal).HasColumnType("tinyint(1)");

                entity.Property(e => e.Processed)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_message_UserId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_payment_UserId");

                entity.Property(e => e.Id).HasColumnType("char(36)");

                entity.Property(e => e.Amount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.DateTimeUtc)
                    .HasColumnName("DateTimeUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaypalOrderId).HasColumnType("varchar(255)");

                entity.Property(e => e.SubscriptionId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_UserId");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("refresh_token");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_RefreshToken_UserId");

                entity.Property(e => e.Id).HasColumnType("varchar(32)");

                entity.Property(e => e.IsRevoked)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_UserId");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_subscription_UserId2");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreateDateUtc)
                    .HasColumnName("CreateDateUTC")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'utc_timestamp()'");

                entity.Property(e => e.EndDateUtc)
                    .HasColumnName("EndDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaypalRefId).HasColumnType("varchar(255)");

                entity.Property(e => e.StartDateUtc)
                    .HasColumnName("StartDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subscription_UserId2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Disabled)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FirebaseUid)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<VirtualNumber>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("PRIMARY");

                entity.ToTable("virtual_number");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("FK_virtual_number_OwnerId");

                entity.Property(e => e.Number).HasColumnType("varchar(255)");

                entity.Property(e => e.LastCheckUtc)
                    .HasColumnName("LastCheckUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.OwnerId).HasColumnType("int(11)");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.VirtualNumber)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_virtual_number_OwnerId");
            });

            modelBuilder.Entity<VirtualNumberData>(entity =>
            {
                entity.ToTable("virtual_number_data");

                entity.HasIndex(e => e.Number)
                    .HasName("FK_virtual_number_data_Number");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.InsertDateUtc)
                    .HasColumnName("InsertDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Number).HasColumnType("varchar(255)");

                entity.HasOne(d => d.NumberNavigation)
                    .WithMany(p => p.VirtualNumberData)
                    .HasForeignKey(d => d.Number)
                    .HasConstraintName("FK_virtual_number_data_Number");
            });
        }
    }
}

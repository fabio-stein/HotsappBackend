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

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageReceived> MessageReceived { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Phoneservice> Phoneservice { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

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
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SentDateUtc)
                    .HasColumnName("SentDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<MessageReceived>(entity =>
            {
                entity.ToTable("message_received");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FromNumber)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ReceiveDateUtc)
                    .HasColumnName("ReceiveDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToNumber).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_payment_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.DateTimeUtc)
                    .HasColumnName("DateTimeUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaypalOrderId).HasColumnType("varchar(255)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payment_UserId");
            });

            modelBuilder.Entity<Phoneservice>(entity =>
            {
                entity.ToTable("phoneservice");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreateDateUtc)
                    .HasColumnName("CreateDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
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

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction");

                entity.HasIndex(e => e.PaymentId)
                    .HasName("FK_transaction_PaymentId");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_transaction_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.DateTimeUtc)
                    .HasColumnName("DateTimeUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_transaction_PaymentId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FirebaseUid)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("user_account");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(8,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserAccount)
                    .HasForeignKey<UserAccount>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_account_UserId");
            });
        }
    }
}

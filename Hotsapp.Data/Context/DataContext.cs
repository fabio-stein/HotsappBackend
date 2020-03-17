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

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignContact> CampaignContact { get; set; }
        public virtual DbSet<ConnectionFlow> ConnectionFlow { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VirtualNumber> VirtualNumber { get; set; }
        public virtual DbSet<VirtualNumberData> VirtualNumberData { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }
        public virtual DbSet<WalletTransaction> WalletTransaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=hotsapp.censknzoa6og.us-east-1.rds.amazonaws.com;port=3306;user=admin;password=MMPY0DyZvVX5LVrm5V;database=hotsapp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("campaign");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("FK_table1_OwnerId");

                entity.Property(e => e.Id).HasColumnType("char(36)");

                entity.Property(e => e.CreateDateUtc)
                    .HasColumnName("CreateDateUTC")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'utc_timestamp()'");

                entity.Property(e => e.IsCanceled)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsComplete)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsPaused)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MessageToSend)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OwnerId).HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_table1_OwnerId");
            });

            modelBuilder.Entity<CampaignContact>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CampaignId })
                    .HasName("PRIMARY");

                entity.ToTable("campaign_contact");

                entity.HasIndex(e => e.CampaignId)
                    .HasName("FK_campaign_contact_CampaignId");

                entity.HasIndex(e => e.MessageId)
                    .HasName("FK_campaign_contact_MessageId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CampaignId).HasColumnType("char(36)");

                entity.Property(e => e.IsSuccess)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MessageId).HasColumnType("int(11)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Processed)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignContact)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_campaign_contact_CampaignId");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.CampaignContact)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("FK_campaign_contact_MessageId");
            });

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

                entity.HasIndex(e => e.DateTimeUtc)
                    .HasName("IDX_message_DateTimeUTC");

                entity.HasIndex(e => e.InternalNumber)
                    .HasName("IDX_message_InternalNumber");

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

                entity.Property(e => e.ErrorCode).HasColumnType("varchar(255)");

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
                    .HasName("FK_subscription_UserId");

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
                    .HasConstraintName("FK_subscription_UserId");
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

                entity.Property(e => e.Error).HasColumnType("varchar(255)");

                entity.Property(e => e.LastCheckUtc)
                    .HasColumnName("LastCheckUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.OwnerId).HasColumnType("int(11)");

                entity.Property(e => e.RetryCount)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

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

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("wallet");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(8,2)")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<WalletTransaction>(entity =>
            {
                entity.ToTable("wallet_transaction");

                entity.Property(e => e.Id).HasColumnType("char(36)");

                entity.Property(e => e.Amount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.DateTimeUtc)
                    .HasColumnName("DateTimeUTC")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'utc_timestamp()'");

                entity.Property(e => e.PaymentId).HasColumnType("char(36)");

                entity.Property(e => e.WalletId).HasColumnType("int(11)");
            });
        }
    }
}

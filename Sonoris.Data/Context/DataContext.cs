using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sonoris.Data.Model
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

        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<PlaylistMedia> PlaylistMedia { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=sonorisdev;database=sonoris");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("channel", "sonoris");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_Channel_Owner");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Channel)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Channel_Owner");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("media", "sonoris");

                entity.HasIndex(e => e.ChannelId)
                    .HasName("FK_Media_Channel");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ChannelId).HasColumnType("int(11)");

                entity.Property(e => e.DurationSeconds).HasColumnType("int(11)");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Media_Channel");
            });

            modelBuilder.Entity<PlaylistMedia>(entity =>
            {
                entity.ToTable("playlist_media", "sonoris");

                entity.HasIndex(e => e.ChannelId)
                    .HasName("FK_PlaylistMedia_ChannelId");

                entity.HasIndex(e => e.MediaId)
                    .HasName("FK_PlaylistMedia_MediaId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ChannelId).HasColumnType("int(11)");

                entity.Property(e => e.EndDateUtc).HasColumnName("EndDateUTC");

                entity.Property(e => e.MediaId).HasColumnType("int(11)");

                entity.Property(e => e.StartDateUtc).HasColumnName("StartDateUTC");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.PlaylistMedia)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistMedia_ChannelId");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.PlaylistMedia)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistMedia_MediaId");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("refresh_token", "sonoris");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_RefreshToken_UserId");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsRevoked)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "sonoris");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FirebaseUid)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}

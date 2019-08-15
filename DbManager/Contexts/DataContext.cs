using System;
using DbManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbManager.Contexts
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
        public virtual DbSet<ChannelPlaylist> ChannelPlaylist { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("User ID=postgres;Password=samplux;Host=localhost;Port=5432;Database=sonoris;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.HasKey(e => e.ChId)
                    .HasName("channel_pkey");

                entity.HasOne(d => d.ChOwnerNavigation)
                    .WithMany(p => p.Channel)
                    .HasForeignKey(d => d.ChOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("channel_ch_owner_fkey");
            });

            modelBuilder.Entity<ChannelPlaylist>(entity =>
            {
                entity.HasKey(e => e.CplId)
                    .HasName("channel_playlist_pkey");

                entity.HasOne(d => d.CplChannelNavigation)
                    .WithMany(p => p.ChannelPlaylist)
                    .HasForeignKey(d => d.CplChannel)
                    .HasConstraintName("channel_playlist_cpl_channel_fkey");

                entity.HasOne(d => d.CplMediaNavigation)
                    .WithMany(p => p.ChannelPlaylist)
                    .HasForeignKey(d => d.CplMedia)
                    .HasConstraintName("channel_playlist_cpl_media_fkey");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenId)
                    .HasName("genre_pkey");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.MedId)
                    .HasName("media_pkey");

                entity.HasOne(d => d.MedChannelNavigation)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.MedChannel)
                    .HasConstraintName("media_med_channel_fkey");

                entity.HasOne(d => d.MedTypeNavigation)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.MedType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("media_med_type_fkey");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.HasKey(e => e.MtId)
                    .HasName("media_type_pkey");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokId)
                    .HasName("refresh_token_pkey");

                entity.Property(e => e.TokId).ValueGeneratedNever();

                entity.HasOne(d => d.TokUserNavigation)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.TokUser)
                    .HasConstraintName("refresh_token_tok_user_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsrId)
                    .HasName("user_pkey");
            });
        }
    }
}

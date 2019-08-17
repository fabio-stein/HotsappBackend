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
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=sonorisdata.csgrxoop9tel.sa-east-1.rds.amazonaws.com;port=3306;user=Sonoris;password=oQxQTlNZB9JqTJPqxWpL;database=sonoris");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("Channel", "sonoris");

                entity.HasIndex(e => e.Owner)
                    .HasName("FK_Channel_Owner");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Owner).HasColumnType("int(11)");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Channel)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Channel_Owner");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("Media", "sonoris");

                entity.HasIndex(e => e.Channel)
                    .HasName("FK_Media_Channel");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Channel).HasColumnType("int(11)");

                entity.Property(e => e.DurationSeconds).HasColumnType("int(11)");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ChannelNavigation)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.Channel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Media_Channel");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "sonoris");

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

using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Streamer> Streamer { get; set; }

        public virtual DbSet<Channel> Channel { get; set; }


    }
}

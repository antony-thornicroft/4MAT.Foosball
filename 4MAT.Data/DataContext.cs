using System;
using Microsoft.EntityFrameworkCore;

namespace _4MAT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Game> Games { get; set; }

    }
}

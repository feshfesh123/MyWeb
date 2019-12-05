using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TFTB.Data.Entities;

namespace TFTB.Data.Context
{
    public class TFTDbContext : DbContext
    {
        public TFTDbContext(DbContextOptions<TFTDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Join> Joins { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Result> Results { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Join>()
                .HasKey(c => new { c.MatchId, c.UserId });
            modelBuilder.Entity<Request>()
               .HasKey(c => new { c.MatchId, c.UserId });
        }
    }
}

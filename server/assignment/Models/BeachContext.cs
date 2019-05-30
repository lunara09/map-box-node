using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class BeachContext : DbContext
    {
        public BeachContext(DbContextOptions options)
    : base(options)
        {
        }
        public virtual DbSet<BeachEf> Beach { get; set; }
        public virtual DbSet<CoordinatesEf> Geometry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<CoordinatesEf>()
            //    .HasMany(e => e.Beach)
            //    .WithOne(e => e.Geometry)
            //    .HasForeignKey(e => e.GeometryId);
        }
    }
}

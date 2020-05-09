using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HomeWork19
{
    public partial class ShopContext : DbContext
    {
        public virtual DbSet<AlifShop> AlifShop { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Shop;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlifShop>(entity =>
            {
                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Model).HasColumnType("nchar(10)");
            });
        }
    }
}

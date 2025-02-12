using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<Description> Description { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryCloth> CategoryCloths { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryCloth>()
                .HasOne(cc => cc.Cloth)
                .WithMany(c => c.CategoryCloths)
                .HasForeignKey(cc => cc.ClothId);
            modelBuilder.Entity<CategoryCloth>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.CategoryCloths)
                .HasForeignKey(cc => cc.CategoryId);

            modelBuilder.Entity<CategoryCloth>().HasKey(cc => new { cc.ClothId, cc.CategoryId });

            List<IdentityRole> roles = [
                new(){
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new(){
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            ];
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
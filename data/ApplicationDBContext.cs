using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.models;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

    public DbSet<Cloth> Cloth { get; set; }
    public DbSet<Description> Description { get; set;}
    }
}
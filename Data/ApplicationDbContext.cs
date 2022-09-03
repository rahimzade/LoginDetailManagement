using Microsoft.EntityFrameworkCore;
using LoginDetailManagement.Entities;
using System;

namespace LoginDetailManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<LoginDetail> LoginDetail { get; set; }
    }
}

using Estate_Manager.API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Estate> Estates { get; set; }

        public DbSet<Road> Roads { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeOwner> HomeOwners { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Occupant> Occupants { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserEstate>().HasKey(u => new
            {
                u.EstateId,
                u.UserId
            });

            builder.Entity<IdentityRole>().HasData(
             new IdentityRole
             {
                 Id = "1",
                 Name = "Administrator",
                 NormalizedName = "ADMINISTRATOR"
             },
             new IdentityRole
             {
               Id = "2",
               Name = "Supervisor",
               NormalizedName = "SUPERVISOR"
             },
             new IdentityRole
             {
                Id = "3",
                Name = "User",
                NormalizedName = "USER"
             }
            );
        }

    }
}
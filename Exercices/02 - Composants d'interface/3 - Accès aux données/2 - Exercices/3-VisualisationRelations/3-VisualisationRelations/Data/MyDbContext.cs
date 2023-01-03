using _3_VisualisationRelations.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_VisualisationRelations.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Content> Contents { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}

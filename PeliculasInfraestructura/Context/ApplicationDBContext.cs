using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliculasCore.Entities;

namespace PeliculasInfraestructura.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Gender>? Genders { get; set; }
        public DbSet<Actor>? Actors { get; set; }
    }
}

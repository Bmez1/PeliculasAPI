using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Repositories;
using PeliculasInfraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasInfraestructura.Repositories
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
